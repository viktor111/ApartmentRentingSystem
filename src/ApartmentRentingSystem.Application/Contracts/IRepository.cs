namespace ApartmentRentingSystem.Application.Contracts
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Common;

    public interface IRepository<out TEntity>
        where TEntity : IAggregateRoot
    {
    }
}