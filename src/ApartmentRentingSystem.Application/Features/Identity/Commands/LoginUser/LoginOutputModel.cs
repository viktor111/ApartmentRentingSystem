namespace ApartmentRentingSystem.Application.Features.Identity.Commands.LoginUser
{
    public class LoginOutputModel
    {
        public LoginOutputModel(string token, int landlordId)
        {
            this.Token = token;
            this.LandlordId = landlordId;
        }
        
        public string Token { get; }
        
        public int LandlordId { get; }
    }
}