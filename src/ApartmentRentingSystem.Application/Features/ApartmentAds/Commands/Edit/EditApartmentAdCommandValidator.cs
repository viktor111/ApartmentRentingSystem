using ApartmentRentingSystem.Application.Features.ApartmentAds.Commands.Common;
using FluentValidation;

namespace ApartmentRentingSystem.Application.Features.ApartmentAds.Commands.Edit
{
    public class EditApartmentAdCommandValidator: AbstractValidator<EditApartmentAdCommand>
    {
        public EditApartmentAdCommandValidator(IApartmentAdRepository apartmentAdRepository)
        {
            this.Include(new ApartmentAdCommandValidator<EditApartmentAdCommand>(apartmentAdRepository));
        }
    }
}