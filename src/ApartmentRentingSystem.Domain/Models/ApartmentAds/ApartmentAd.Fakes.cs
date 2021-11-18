namespace ApartmentRentingSystem.Domain.Models.ApartmentAds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Bogus;
    using FakeItEasy;

    public class ApartmentAdFakes
    {
        public class ApartmentAdClassDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type)
            {
                return type == typeof(ApartmentAd);
            }

            public object? Create(Type type)
            {
                return Data.GetApartmentAd();
            }

            public Priority Priority => Priority.Default;
        }

        public static class Data
        {
            public static IEnumerable<ApartmentAd> GetApartmentAds(int count = 10)
            {
                var result = Enumerable
                    .Range(1, count)
                    .Select(i => GetApartmentAd(i))
                    .Concat(Enumerable
                        .Range(count + 1, count * 2)
                        .Select(i => GetApartmentAd(i, false))).
                    ToList();

                return result;
            }

            public static ApartmentAd GetApartmentAd(int id = 1, bool isAvailable = true)
            {
                var options = new Faker<Options>()
                    .CustomInstantiator(f => new Options(
                        f.Random.Bool(),
                        f.Random.Bool(),
                        f.Random.Bool(),
                        f.Random.Bool(),
                        f.Random.Bool(),
                        f.Random.Bool(),
                        f.Random.Bool(),
                        f.Random.Bool(),
                        f.Random.Bool(),
                        f.Random.Bool(),
                        f.Random.Bool(),
                        f.Random.Bool(),
                        f.Random.Bool(),
                        f.Random.Bool()))
                    .Generate();

                var rooms = new Faker<Rooms>()
                    .CustomInstantiator(f => new Rooms(
                        f.Random.Number(1, 9),
                        f.Random.Number(1, 9),
                        f.Random.Number(1, 9),
                        f.Random.Number(1, 9)))
                    .Generate();

                var address = new Faker<Address>()
                    .CustomInstantiator(f => new Address(
                        f.Random.String(11),
                        f.Random.String(11),
                        f.Random.String(11)
                    ))
                    .Generate();

                var result = new Faker<ApartmentAd>()
                    .CustomInstantiator(f => new ApartmentAd(f.Random.String(11),
                        address,
                        f.Random.String(11), f.Random.Decimal(1, 100), f.Random.Int(1, 100), options, rooms,
                        isAvailable))
                    .Generate()
                    .SetId(id);

                return result;
            }
        }
    }
}