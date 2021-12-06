namespace ApartmentRentingSystem.Domain.Specifications.Landlords
{
    using System;
    using System.Linq.Expressions;
    using Domain.Models.Landlords;

    public class LandlordByIdSpecification : Specification<Landlord>
    {
        private readonly int? id;

        public LandlordByIdSpecification(int? id)
        {
            this.id = id;
        }
        
        protected override bool Include => this.id != null;
        
        public override Expression<Func<Landlord, bool>> ToExpression()
        {
            return landlord => landlord.Id == this.id;
        }
    }
}