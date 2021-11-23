namespace ApartmentRentingSystem.Startup.Specs
{
    using Application.Features.Identity.Commands.CreateUser;
    using Application.Features.Identity.Commands.LoginUser;
    using Infrastructure.Identity;
    using Web.Features;
    using FluentAssertions;
    using MyTested.AspNetCore.Mvc;
    using Xunit;


    public class IdentityControllerSpecs
    {
        [Fact]
        public void RegisterShouldHaveCorrectAttributes()
        {
            MyController<IdentityController>
                .Calling(c => c.Register(With.Default<CreateUserCommand>()))
                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Post));
        }

        [Fact]
        public void LoginShouldHaveCorrectAttributes()
        {
            MyController<IdentityController>
                .Calling(c => c.Login(With.Default<LoginUserCommand>()))
                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Post));
        }

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
                    .Login(new LoginUserCommand
                    {
                        Email = email,
                        Password = password
                    }))
                .Which()
                .ShouldReturn()
                .ActionResult<LoginOutputModel>(result => result
                    .Passing(model => model.Token.Should().Be(token)));
        }
    }
}