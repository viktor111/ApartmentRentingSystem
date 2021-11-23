namespace ApartmentRentingSystem.Application.Features.Identity.Commands.CreateUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;
    using MediatR;
    using Common;
    using Landlords;
    using Domain.Factories.Landlords;

    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {
        public string Name { get; set; } = default!;

        public string Number { get; set; } = default!;
        
        public string CountryCode { get; set; } = default!;

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
        {
            private readonly IIdentity identity;
            private readonly ILandlordFactory landlordFactory;
            private readonly ILandlordRepository landlordRepository;

            public CreateUserCommandHandler(IIdentity identity,
                ILandlordFactory landlordFactory,
                ILandlordRepository landlordRepository)
            {
                this.identity = identity;
                this.landlordFactory = landlordFactory;
                this.landlordRepository = landlordRepository;
            }

            public async Task<Result> Handle(
                CreateUserCommand request,
                CancellationToken cancellationToken)
            {
                var result = await this.identity.Register(request);

                if (!result.Succeeded)
                {
                    return result;
                }

                var user = result.Data;

                var landlord = this.landlordFactory
                    .WithName(request.Name)
                    .WithPhoneNumber(request.CountryCode, request.Number)
                    .Build();
                
                user.BecomeLandlord(landlord);
                
                await this.landlordRepository.Save(landlord);
                
                return result;
            }
        }
    }
}