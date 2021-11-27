namespace ApartmentRentingSystem.Application.Features.ApartmentAds.Commands.Create
{
    using Common;
    using FluentValidation;

    public class CreateApartmentAdCommandValidator : AbstractValidator<CreateApartmentAdCommand>
    {
        public CreateApartmentAdCommandValidator(IApartmentAdRepository apartmentAdRepository)
        {
            this.Include(new ApartmentAdCommandValidator<CreateApartmentAdCommand>(apartmentAdRepository));
        }
    }
}