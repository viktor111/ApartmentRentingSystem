using ApartmentRentingSystem.Application.Features.Identity.Commands.LoginUser;
using ApartmentRentingSystem.Infrastructure.Identity;
using ApartmentRentingSystem.Web.Features;
using FluentAssertions;
using MyTested.AspNetCore.Mvc;
using Xunit;

namespace ApartmentRentingSystem.Startup.Specs
{
    public class IdentityControllerSpecs
    {
        [Theory]
        [InlineData(
            IdentityFakes.TestEmail,
            IdentityFakes.ValidPassword,
            JwtTokenGeneratorFakes.ValidToken)]
        public void LoginShouldReturnTokenWhenUserEntersValidCredentials(string email, string password, string token)
        {
            MyPipeline
                .Configuration()
                .ShouldMap(request => request
                    .WithLocation("/Identity/Login")
                    .WithMethod(HttpMethod.Post)
                    .WithJsonBody(new
                    {
                        Email = email,
                        Password = password
                    }))
                .To<IdentityController>(c => c
                    .Login(new LoginUserCommand(email, password)))
                .Which()
                .ShouldReturn()
                .ActionResult<LoginOutputModel>(result => result
                    .Passing(model => model.Token.Should().Be(token)));
        }
    }
}