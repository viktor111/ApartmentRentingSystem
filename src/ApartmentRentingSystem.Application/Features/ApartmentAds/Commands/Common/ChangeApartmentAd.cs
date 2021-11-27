namespace ApartmentRentingSystem.Application.Features.ApartmentAds.Commands.Common
{
    using System.Threading;
    using System.Threading.Tasks;
    using ApartmentRentingSystem.Application.Common;
    using Contracts;
    using Landlords;

    internal static class ChangeApartmentAdExtensions
    {
        public static async Task<Result> LandlordHasApartmentAd(
            this ICurrentUser currentUser,
            ILandlordRepository landlordRepository,
            int apartmentAdId,
            CancellationToken cancellationToken
        )
        {
            var landlordId = await landlordRepository
                .GetLandlordId(
                    currentUser.userId,
                    cancellationToken);

            var landlordHasApartmentAd = await landlordRepository
                .HasApartment(
                    landlordId,
                    apartmentAdId,
                    cancellationToken);

            return landlordHasApartmentAd
                ? Result.Success
                : "You cannot edit this apartment ad.";
        }
    }
}