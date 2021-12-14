namespace ApartmentRentingSystem.Web.Common
{
    using Microsoft.AspNetCore.Authorization;

    using static Domain.Models.ModelConstants.Common;

    public class AuthorizeAdministratorAttribute : AuthorizeAttribute
    {
        public AuthorizeAdministratorAttribute() => this.Roles = AdministratorRoleName;
    }
}
