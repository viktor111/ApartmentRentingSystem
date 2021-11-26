namespace ApartmentRentingSystem.Application.Features.Landlords
{
    using Contracts;
    using Domain.Models.Landlords;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ILandlordRepository : IRepository<Landlord>
    {
        Task<int> GetLandlordId(string userId, CancellationToken cancellationToken = default);

        Task<Landlord> FindByUser(string userId, CancellationToken cancellationToken = default);
        
        Task<bool> HasApartment(int landlordId, int apartmentId, CancellationToken cancellationToken = default);
    }
}