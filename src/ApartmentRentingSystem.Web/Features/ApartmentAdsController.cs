namespace ApartmentRentingSystem.Web.Features
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Factories.Landlords;
    using Domain.Models.ApartmentAds;
    using Domain.Models.Landlords;


    [ApiController]
    [Route("api/[controller]")]
    public class ApartmentAdsController : ControllerBase
    {
        private static readonly Landlord landlord = new LandlordFactory()
            .WithName("TESTNAME")
            .WithPhoneNumber("+356", "08956713")
            .Build();

        [HttpGet]
        public IEnumerable<ApartmentAd> Get()
        {
            return landlord.ApartmentAds
                .Where(a => a.IsAvailable);
        }
    }
}