namespace ApartmentRentingSystem.Application.Features.ApartmentAds.Commands.Common

{
    using FluentValidation;
    using static Domain.Models.ModelConstants.ApartmentAds;
    using static Domain.Models.ModelConstants.Address;
    using static Domain.Models.ModelConstants.Rooms;

    public class ApartmentAdCommandValidator<TCommand> : AbstractValidator<ApartmentAdCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public ApartmentAdCommandValidator(IApartmentAdRepository apartmentAdRepository)

        {
            this.RuleFor(a => a.Title)
                .MinimumLength(MinTitleLength)
                .MaximumLength(MaxTitleLength)
                .NotEmpty();

            this.RuleFor(a => a.Description)
                .MinimumLength(MinDescriptionLength)
                .MaximumLength(MaxDescriptionLength)
                .NotEmpty();

            this.RuleFor(a => a.City)
                .MinimumLength(MinCityLength)
                .MaximumLength(MaxCityLength)
                .NotEmpty();

            this.RuleFor(a => a.Country)
                .MinimumLength(MinCountryLength)
                .MaximumLength(MaxCountryLength)
                .NotEmpty();

            this.RuleFor(a => a.Street)
                .MinimumLength(MinStreetLength)
                .MaximumLength(MaxStreetLength)
                .NotEmpty();

            this.RuleFor(a => a.Price)
                .InclusiveBetween(MinPrice, MaxPrice);

            this.RuleFor(a => a.SquareMeters)
                .InclusiveBetween(MinSquareMeters, MaxSquareMeters);


            this.RuleFor(a => a.NumberOfRooms)
                .InclusiveBetween(MinNumberOfRooms, MaxNumberOfRooms);

            this.RuleFor(a => a.NumberOfBathrooms)
                .InclusiveBetween(MinNumberOfBathrooms, MaxNumberOfBathrooms);

            this.RuleFor(a => a.NumberOfBedrooms)
                .InclusiveBetween(MinNumberOfBedrooms, MaxNumberOfBedrooms);

            this.RuleFor(a => a.NumberOfBalconies)
                .InclusiveBetween(MinNumberOfBalconies, MaxNumberOfBalconies);
        }
    }
}