namespace ApartmentRentingSystem.Infrastructure.Identity
{
    using Domain.Exceptions;
    using Domain.Models.Landlords;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        internal User(string email)
            : base(email)
        {
            this.Email = email;
        }

        public Landlord? Landlord { get; private set; }

        public void BecomeLandlord(Landlord landlord)
        {
            if (this.Landlord != null)
            {
                throw new InvalidLandlordException($"User '{this.UserName}' is already a landlord.");
            }

            this.Landlord = landlord;
        }
    }
}