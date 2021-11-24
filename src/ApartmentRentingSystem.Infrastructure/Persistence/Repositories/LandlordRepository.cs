using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using ApartmentRentingSystem.Domain.Exceptions;
using ApartmentRentingSystem.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApartmentRentingSystem.Infrastructure.Persistence.Repositories
{
    using Application.Features.Landlords;
    using Domain.Models.Landlords;

    internal class LandlordRepository : DataRepository<Landlord>, ILandlordRepository
    {
        public LandlordRepository(ApartmentRentalDbContext db)
            : base(db)
        {
        }

        public Task<int> GetLandlordId(
            string userId,
            CancellationToken cancellationToken = default)
        {
            return this.FindByUser(userId, user => user.Landlord!.Id, cancellationToken);
        }

        public Task<Landlord> FindByUser(string userId, CancellationToken cancellationToken = default)
        {
            return this.FindByUser(userId, user => user.Landlord!, cancellationToken);
        }

        private async Task<T> FindByUser<T>(
            string userId,
            Expression<Func<User, T>> selector,
            CancellationToken cancellationToken = default)
        {
            var dealerData = await this
                .Data
                .Users
                .Where(u => u.Id == userId)
                .Select(selector)
                .FirstOrDefaultAsync(cancellationToken);

            if (dealerData == null)
            {
                throw new InvalidLandlordException("This user is not a landlord.");
            }

            return dealerData;
        }
    }
}