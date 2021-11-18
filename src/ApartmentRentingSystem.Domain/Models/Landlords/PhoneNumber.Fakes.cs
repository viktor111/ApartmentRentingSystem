using System;
using Bogus;
using FakeItEasy;

namespace ApartmentRentingSystem.Domain.Models.Landlords
{
    public class PhoneNumberFakes
    {
        public class PhoneNumberClassDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type)
            {
                return type == typeof(PhoneNumber);
            }

            public object? Create(Type type)
            {
                var result = new Faker<PhoneNumber>()
                    .CustomInstantiator(f =>
                        new PhoneNumber("+342", f.Random.String(11)))
                    .Generate();
                
                return result;
            }

            public Priority Priority => Priority.Default;
        }
    }
}