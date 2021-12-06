using System;
using System.Linq.Expressions;
using ApartmentRentingSystem.Domain.Models.Landlords;

namespace ApartmentRentingSystem.Domain.Specifications.Landlords
{
    public class LandlordByNameSpecification : Specification<Landlord>
    {
        private readonly string? name;

        public LandlordByNameSpecification(string? name)
        {
            this.name = name;
        }
        
        protected override bool Include => this.name != null;

        public override Expression<Func<Landlord, bool>> ToExpression()
        {
            return landlord => landlord.Name
                .ToLower()
                .Contains(this.name!.ToLower());
        }
    }
}