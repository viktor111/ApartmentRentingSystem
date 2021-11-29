using System.Threading;
using System.Threading.Tasks;
using ApartmentRentingSystem.Application.Common;
using ApartmentRentingSystem.Application.Contracts;
using ApartmentRentingSystem.Application.Features.ApartmentAds.Commands.Common;
using ApartmentRentingSystem.Application.Features.Landlords;
using MediatR;

namespace ApartmentRentingSystem.Application.Features.ApartmentAds.Commands.ChangeAvailability
{
    public class ChangeAvailabilityCommand : EntityCommand<int>, IRequest<Result>
    {
        public class ChangeAvailabilityCommandHandler : IRequestHandler<ChangeAvailabilityCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IApartmentAdRepository apartmentAdRepository;
            private readonly ILandlordRepository landlordRepository;

            public ChangeAvailabilityCommandHandler(
                ICurrentUser currentUser, 
                IApartmentAdRepository apartmentAdRepository,
                ILandlordRepository landlordRepository)
            {
                this.currentUser = currentUser;
                this.apartmentAdRepository = apartmentAdRepository;
                this.landlordRepository = landlordRepository;
            }

            public async Task<Result> Handle(
                ChangeAvailabilityCommand request,
                CancellationToken cancellationToken)
            {
                var landlordHasApartmentAd = await this.currentUser.LandlordHasApartmentAd(
                    this.landlordRepository, 
                    request.Id,
                    cancellationToken);

                if (!landlordHasApartmentAd)
                {
                    return landlordHasApartmentAd;
                }
                
                var apartmentAd = await this.apartmentAdRepository
                    .Find(request.Id, cancellationToken);
                
                apartmentAd.ChangeAvailability();
                
                await this.apartmentAdRepository.Save(apartmentAd, cancellationToken);
                
                return Result.Success;
            }
        }
    }
}