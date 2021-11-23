namespace ApartmentRentingSystem.Application.Features.Identity
{
    using System.Threading.Tasks;
    using Commands.LoginUser;
    using Commands;
    using Common;


    public interface IIdentity
    {
        Task<Result<IUser>> Register(UserInputModel userInput);

        Task<Result<LoginSuccessModel>> Login(UserInputModel userInput);
    }
}