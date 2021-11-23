namespace ApartmentRentingSystem.Application.Features.Identity
{
    using System.Threading.Tasks;
    using Commands.LoginUser;

    public interface IIdentity
    {
        Task<Result> Register(UserInputModel userInput);

        Task<Result<LoginSuccessModel>> Login(UserInputModel userInput);
    }
}