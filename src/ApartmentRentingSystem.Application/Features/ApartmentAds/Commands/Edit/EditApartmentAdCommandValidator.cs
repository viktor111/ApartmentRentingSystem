namespace ApartmentRentingSystem.Application.Features.ApartmentAds.Commands.Edit
{
    using Common;
    using FluentValidation;

    public class EditApartmentAdCommandValidator : AbstractValidator<EditApartmentAdCommand>
    {
        public EditApartmentAdCommandValidator(IApartmentAdRepository apartmentAdRepository)
        {
            this.Include(new ApartmentAdCommandValidator<EditApartmentAdCommand>(apartmentAdRepository));
        }
    }
}