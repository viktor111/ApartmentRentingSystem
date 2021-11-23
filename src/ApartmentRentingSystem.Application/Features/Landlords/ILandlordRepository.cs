namespace ApartmentRentingSystem.Application.Features.Landlords
{
    using Contracts;
    using Domain.Models.Landlords;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ILandlordRepository : IRepository<Landlord>
    {
        Task<int> GetLandlordId(string userId, CancellationToken cancellationToken = default);
    }
}