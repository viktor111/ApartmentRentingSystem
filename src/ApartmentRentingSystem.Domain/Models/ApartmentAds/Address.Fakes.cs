namespace ApartmentRentingSystem.Domain.Models.ApartmentAds
{
    using System;
    using Bogus;
    using FakeItEasy;

    public class AddressFakes
    {
        public class AddressClassDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type)
            {
                return type == typeof(Address);
            }

            public object? Create(Type type)
            {
                var result = new Faker<Address>()
                    .CustomInstantiator(f => new Address(
                        f.Random.String(11),
                        f.Random.String(11),
                        f.Random.String(11)
                    ))
                    .Generate();

                return result;
            }

            public Priority Priority => Priority.Default;
        }
    }
}