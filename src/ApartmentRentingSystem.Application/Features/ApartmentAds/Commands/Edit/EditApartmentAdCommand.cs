using System.Threading;
using System.Threading.Tasks;
using ApartmentRentingSystem.Application.Common;
using ApartmentRentingSystem.Application.Contracts;
using ApartmentRentingSystem.Application.Features.ApartmentAds.Commands.Common;
using ApartmentRentingSystem.Application.Features.Landlords;
using ApartmentRentingSystem.Domain.Models.ApartmentAds;
using MediatR;

namespace ApartmentRentingSystem.Application.Features.ApartmentAds.Commands.Edit
{
    public class EditApartmentAdCommand : ApartmentAdCommand<EditApartmentAdCommand> , IRequest<Result>
    {
        public class EditApartmentAdCommandHandler : IRequestHandler<EditApartmentAdCommand, Result>
        {
            
            private readonly IApartmentAdRepository apartmentAdRepository;
            private readonly ICurrentUser currentUser;
            private readonly ILandlordRepository landlordRepository;

            public EditApartmentAdCommandHandler(
                IApartmentAdRepository apartmentAdRepository, 
                ICurrentUser currentUser,
                ILandlordRepository landlordRepository)
            {
                this.apartmentAdRepository = apartmentAdRepository;
                this.currentUser = currentUser;
                this.landlordRepository = landlordRepository;
            }

            public async Task<Result> Handle(
                EditApartmentAdCommand request, 
                CancellationToken cancellationToken)
            {
                var landlordHasApartmentAd = await this.currentUser
                    .LandlordHasApartmentAd(
                        this.landlordRepository, 
                        request.Id, 
                        cancellationToken);
                if (!landlordHasApartmentAd)
                {
                    return landlordHasApartmentAd;
                }
                
                var apartmentAd = await this.apartmentAdRepository
                    .Find(request.Id, cancellationToken);

                apartmentAd
                    .UpdateTitle(request.Title)
                    .UpdateDescription(request.Description)
                    .UpdatePrice(request.Price)
                    .UpdateSquareMeters(request.SquareMeters)
                    .UpdateAddress(
                        request.Country, 
                        request.City,
                        request.Street)
                    .UpdateRooms(
                        request.NumberOfRooms,
                        request.NumberOfBathrooms,
                        request.NumberOfBedrooms,
                        request.NumberOfBalconies)
                    .UpdateOptions( request.HasFurniture,
                        request.HasParking,
                        request.HasGarden,
                        request.HasLift,
                        request.HasAirConditioner,
                        request.HasTv,
                        request.HasInternet,
                        request.HasPhone,
                        request.HasWashingMachine,
                        request.HasDishwasher,
                        request.HasRefrigerator,
                        request.HasMicrowave,
                        request.HasOven,
                        request.HasCoffeeMachine);
                
                await this.apartmentAdRepository.Save(apartmentAd, cancellationToken);
                
                return Result.Success;
            }
        }
    }
}