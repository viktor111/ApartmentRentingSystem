using System.Linq;
using ApartmentRentingSystem.Application.Contracts;

namespace ApartmentRentingSystem.Web.Features
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using Domain.Models.ApartmentAds;


    [ApiController]
    [Route("api/[controller]")]
    public class ApartmentAdsController : ControllerBase
    {
        private readonly IRepository<ApartmentAd> carAds;
        
        public ApartmentAdsController(IRepository<ApartmentAd> carAds)
        {
            this.carAds = carAds;
        }

        [HttpGet]
        public IEnumerable<ApartmentAd> Get()
        {
            return this.carAds
                .All()
                .Where(a => a.IsAvailable);
        }
    }
}