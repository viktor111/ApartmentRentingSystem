namespace ApartmentRentingSystem.Domain.Models.ApartmentAds
{
    using System;
    using Bogus;
    using FakeItEasy;

    public class RoomsFakes
    {
        public class ApartmentAdClassDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type)
            {
                return type == typeof(Rooms);
            }

            public object? Create(Type type)
            {
                var result = new Faker<Rooms>()
                    .CustomInstantiator(f => new Rooms(
                        f.Random.Number(1, 9),
                        f.Random.Number(1, 9),
                        f.Random.Number(1, 9),
                        f.Random.Number(1, 9)))
                    .Generate();

                return result;
            }

            public Priority Priority => Priority.Default;
        }
    }
}