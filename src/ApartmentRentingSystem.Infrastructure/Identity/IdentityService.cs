using ApartmentRentingSystem.Application.Features.Identity.Commands.LoginUser;

namespace ApartmentRentingSystem.Infrastructure.Identity
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Application;
    using Application.Contracts;
    using Application.Features.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;

    public class IdentityService : IIdentity
    {
        private const string InvalidErrorMessage = "Invalid credentials.";
        
        private readonly UserManager<User> userManager;
        private readonly ApplicationSettings applicationSettings;
        private readonly IJwtTokenGenerator jwtTokenGenerator;

        public IdentityService(
            UserManager<User> userManager, 
            IOptions<ApplicationSettings> applicationSettings,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            this.userManager = userManager;
            this.applicationSettings = applicationSettings.Value;
            this.jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<Result> Register(UserInputModel userInput)
        {
            var user = new User(userInput.Email);

            var identityResult = await this.userManager.CreateAsync(user, userInput.Password);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result.Success
                : Result.Failure(errors);
        }

        public async Task<Result<LoginSuccessModel>> Login(UserInputModel userInput)
        {
            var user = await this.userManager.FindByEmailAsync(userInput.Email);
            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, userInput.Password);
            if (!passwordValid)
            {
                return InvalidErrorMessage;
            }

            var token = this.jwtTokenGenerator.GenerateToken(user);

            return new LoginSuccessModel(user.Id, token);
        }
        
    }
}
