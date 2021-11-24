using System;
using System.Security.Claims;
using ApartmentRentingSystem.Application.Contracts;
using Microsoft.AspNetCore.Http;

namespace ApartmentRentingSystem.Web.Services
{
    public class CurrentUser : ICurrentUser
    {
        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext?.User;

            if (user == null)
            {
                throw new InvalidOperationException("No user found in the http context.");
            }
            
            this.userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        
        public string userId { get; }
    }
}