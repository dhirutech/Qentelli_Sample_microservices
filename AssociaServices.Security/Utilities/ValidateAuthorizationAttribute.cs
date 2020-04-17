using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AssociaServices.Security.Utilities
{
    public class ValidateAuthorizationAttribute : TypeFilterAttribute
    {
        public ValidateAuthorizationAttribute(string claimType, string claimValue)
          : base(typeof(ValidateAuthorizationFilter))
        {
            this.Arguments = new object[1]
            {
                new Claim(claimType, claimValue)
            };
        }
    }
}
