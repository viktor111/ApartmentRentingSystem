using System;
using System.Linq.Expressions;
using ApartmentRentingSystem.Domain.Exceptions;
using ApartmentRentingSystem.Infrastructure.Identity;

namespace ApartmentRentingSystem.Infrastructure.Persistence.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Features.ApartmentAds;
    using Application.Features.ApartmentAds.Queries.Search;
    using Domain.Models.ApartmentAds;
    using Microsoft.EntityFrameworkCore;

    internal class ApartmentAdRepository : DataRepository<ApartmentAd>, IApartmentAdRepository
    {
        public ApartmentAdRepository(ApartmentRentalDbContext db)
            : base(db)
        {
        }

        public async Task<IEnumerable<ApartmnetAdListingModel>> GetApartmentAdListings(
            string? title = default,
            CancellationToken cancellationToken = default)
        {
            var query = this.AllAvailable();

            return await query.Select(ap => new ApartmnetAdListingModel(
                    ap.Id,
                    ap.Title,
                    ap.Description,
                    ap.Price,
                    ap.SquareMeters,
                    ap.IsAvailable
                ))
                .ToListAsync(cancellationToken);
        }

        public Task<ApartmentAd> Find(int id, CancellationToken cancellationToken = default)
        {
            return this
                .All()
                .FirstOrDefaultAsync(a => a.Id == id,
                    cancellationToken);
        }


        public async Task<int> Total(CancellationToken cancellationToken = default)
        {
            return await this
                .AllAvailable()
                .CountAsync(cancellationToken);
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var apartmentAd = await this.Data.ApartmentAds
                .FindAsync(id, cancellationToken);

            if (apartmentAd == null)
            {
                return false;
            }

            this.Data.ApartmentAds
                .Remove(apartmentAd);

            await this.Data
                .SaveChangesAsync(cancellationToken);

            return true;
        }

        private IQueryable<ApartmentAd> AllAvailable()
            => this
                .All()
                .Where(a => a.IsAvailable);
    }
}