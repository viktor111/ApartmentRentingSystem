namespace ApartmentRentingSystem.Web.Features
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using Domain.Models.ApartmentAds;
    using System.Linq;
    using Application.Contracts;
    using Application;
    using Microsoft.Extensions.Options;

    [ApiController]
    [Route("api/[controller]")]
    public class ApartmentAdsController : ControllerBase
    {
        private readonly IRepository<ApartmentAd> carAds;
        private readonly IOptions<ApplicationSettings> settings;


        public ApartmentAdsController(
            IRepository<ApartmentAd> carAds,
            IOptions<ApplicationSettings> settings)  
        {
            this.carAds = carAds;
            this.settings = settings;
        }

        [HttpGet]
        public object Get()
        {
            return new
            {
                Settings = this.settings.Value,
                CarAds = this.carAds
                .All()
                .Where(a => a.IsAvailable)
            };
            
            
        }
    }
}