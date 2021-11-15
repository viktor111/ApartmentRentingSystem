namespace ApartmentRentingSystem.Domain.Models.Landlords
{
    using System;
    using Common;
    using Bogus;
    using FakeItEasy;
    
    public class LandlordFakes
    {
        public class LandlordClassDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type)
            {
                return type == typeof(Landlord);
            }

            public object? Create(Type type)
            {
                return Data.GetLandlord(1);
            }

            public Priority Priority => Priority.Default;
        }

        public static class Data
        {
            public static Landlord GetLandlord(int id)
            {
                var phoneNumber = new Faker<PhoneNumber>()
                    .CustomInstantiator(f =>
                        new PhoneNumber("+342", f.Random.String(11)))
                    .Generate();

                var result = new Faker<Landlord>()
                    .CustomInstantiator(f =>
                        new Landlord(f.Random.String(11), phoneNumber))
                    .Generate()
                    .SetId(id);
                
                return result;
            }
        }
    }
}