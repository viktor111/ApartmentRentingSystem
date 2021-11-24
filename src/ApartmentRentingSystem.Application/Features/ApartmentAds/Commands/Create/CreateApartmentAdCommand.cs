namespace ApartmentRentingSystem.Application.Features.ApartmentAds.Commands.Create
{
    using Common;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;
    using Landlords;
    using Domain.Factories.ApartmentAds;

    public class CreateApartmentAdCommand : ApartmentAdCommand<CreateApartmentAdCommand>,
        IRequest<CreateApartmentAdOutputModel>
    {
        public class CreateCarAdCommandHandler : IRequestHandler<CreateApartmentAdCommand, CreateApartmentAdOutputModel>
        {
            private readonly IApartmentAdFactory apartmentAdFactory;
            private readonly IApartmentAdRepository apartmentAdRepository;
            private readonly ILandlordRepository landlordRepository;
            private readonly ICurrentUser currentUser;

            public CreateCarAdCommandHandler(
                IApartmentAdFactory apartmentAdFactory,
                IApartmentAdRepository apartmentAdRepository,
                ILandlordRepository landlordRepository,
                ICurrentUser currentUser)
            {
                this.apartmentAdFactory = apartmentAdFactory;
                this.apartmentAdRepository = apartmentAdRepository;
                this.landlordRepository = landlordRepository;
                this.currentUser = currentUser;
            }

            public async Task<CreateApartmentAdOutputModel> Handle(
                CreateApartmentAdCommand request,
                CancellationToken cancellationToken)
            {
                var apartmentaAd = this.apartmentAdFactory
                    .WithTitle(request.Title)
                    .WithAddress(
                        request.Country,
                        request.City,
                        request.Street)
                    .WithDescription(request.Description)
                    .WithPrice(request.Price)
                    .WithSquareMeters(request.SquareMeters)
                    .WithRooms(
                        request.NumberOfRooms,
                        request.NumberOfBathrooms,
                        request.NumberOfBedrooms,
                        request.NumberOfBalconies)
                    .WithOptions(
                        request.HasFurniture,
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
                        request.HasCoffeeMachine)
                    .Build();

                var landlord = await this.landlordRepository
                    .FindByUser(this.currentUser.userId, cancellationToken);

                landlord.AddApartmentAd(apartmentaAd);

                await this.apartmentAdRepository.Save(apartmentaAd, cancellationToken);

                return new CreateApartmentAdOutputModel(apartmentaAd.Id);
            }
        }
    }
}