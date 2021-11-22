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
        private readonly ApartmentRentalDbContext db;

        protected DataRepository(ApartmentRentalDbContext db)
        {
            this.db = db;
        }

        protected IQueryable<TEntity> All()
        {
            return this.db.Set<TEntity>();
        }

        protected Task<int> SaveChanges(CancellationToken cancellationToken = default)
        {
            return this.db.SaveChangesAsync(cancellationToken);
        }
    }
}