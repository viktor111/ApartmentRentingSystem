namespace ApartmentRentingSystem.Infrastructure.Persistence.Repositories
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Contracts;
    using Domain.Common;

    internal class DataRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IAggregateRoot
    {
        private readonly ApartmentRentalDbContext db;

        public DataRepository(ApartmentRentalDbContext db)
        {
            this.db = db;
        }

        public IQueryable<TEntity> All()
        {
            return this.db.Set<TEntity>();
        }

        public Task<int> SaveChanges(CancellationToken cancellationToken = default)
        {
            return this.db.SaveChangesAsync(cancellationToken);
        }
    }
}