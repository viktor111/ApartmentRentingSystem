using System.Threading;
using System.Threading.Tasks;
using ApartmentRentingSystem.Application.Common;
using ApartmentRentingSystem.Application.Contracts;
using ApartmentRentingSystem.Application.Features.ApartmentAds.Commands.Common;
using ApartmentRentingSystem.Application.Features.Landlords;
using MediatR;

namespace ApartmentRentingSystem.Application.Features.ApartmentAds.Commands.Delete
{
    public class DeleteApartmentAdCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteApartmentAdCommandHandler: IRequestHandler<DeleteApartmentAdCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IApartmentAdRepository apartmentAdRepository;
            private readonly ILandlordRepository landlordRepository;
            
            public DeleteApartmentAdCommandHandler(
                ICurrentUser currentUser,
                IApartmentAdRepository apartmentAdRepository,
                ILandlordRepository landlordRepository)
            {
                this.currentUser = currentUser;
                this.apartmentAdRepository = apartmentAdRepository;
                this.landlordRepository = landlordRepository;
            }
            
            public async Task<Result> Handle(
                DeleteApartmentAdCommand request,
                CancellationToken cancellationToken)
            {
                var landlordHasApartmnetAd = await this.currentUser.LandlordHasApartmentAd(
                    this.landlordRepository, 
                    request.Id,
                    cancellationToken);
                
                if(!landlordHasApartmnetAd)
                {
                    return landlordHasApartmnetAd;
                }
                
                return await this.apartmentAdRepository.Delete(
                    request.Id,
                    cancellationToken);
            }
        }
    }
}