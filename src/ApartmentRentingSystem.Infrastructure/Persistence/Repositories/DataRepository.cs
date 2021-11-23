namespace ApartmentRentingSystem.Infrastructure.Persistence.Repositories
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Contracts;
    using Domain.Common;

    internal abstract class DataRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IAggregateRoot
    {
        protected DataRepository(ApartmentRentalDbContext db)
        {
            this.Data = db;
        }
        
        protected ApartmentRentalDbContext Data { get; }

        protected IQueryable<TEntity> All()
        {
            return this.Data.Set<TEntity>();
        }

        protected Task<int> SaveChanges(CancellationToken cancellationToken = default)
        {
            return this.Data.SaveChangesAsync(cancellationToken);
        }
    }
}