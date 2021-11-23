namespace ApartmentRentingSystem.Application.Features.Identity.Commands
{
    public class UserInputModel
    {
        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;
    }
}