using ApartmentRentingSystem.Application.Features.Landlords;

namespace ApartmentRentingSystem.Application.Features.Identity.Commands.LoginUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;
    using MediatR;

    public class LoginUserCommand : UserInputModel, IRequest<Result<LoginOutputModel>>
    {
        public LoginUserCommand(string email, string password)
            : base(email, password)
        {
        }

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<LoginOutputModel>>
        {
            private readonly IIdentity identity;
            private readonly ILandlordRepository landlordRepository;

            public LoginUserCommandHandler(
                IIdentity identity, 
                ILandlordRepository landlordRepository)
            {
                this.identity = identity;
                this.landlordRepository = landlordRepository;
            }

            public async Task<Result<LoginOutputModel>> Handle(
                LoginUserCommand request,
                CancellationToken cancellationToken)
            {
                var result = await this.identity.Login(request);

                if (!result.Succeeded)
                {
                    return result.Errors;
                }

                var user = result.Data;

                var dealerId = await this.landlordRepository.GetLandlordId(user.UserId, cancellationToken);

                return new LoginOutputModel(user.Token, dealerId);
            }
        }
    }
}