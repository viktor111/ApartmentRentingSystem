using ApartmentRentingSystem.Application.Features.ApartmentAds.Commands.Common;
using FluentValidation;

namespace ApartmentRentingSystem.Application.Features.ApartmentAds.Commands.Create
{
    public class CreateApartmentAdCommandValidator : AbstractValidator<CreateApartmentAdCommand>
    {
        public CreateApartmentAdCommandValidator(IApartmentAdRepository apartmentAdRepository)
        {
            this.Include(new ApartmentAdCommandValidator<CreateApartmentAdCommand>(apartmentAdRepository));
        }
    }
}