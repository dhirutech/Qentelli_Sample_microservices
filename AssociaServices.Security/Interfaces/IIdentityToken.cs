using System;

namespace AssociaServices.Security.Interfaces
{
    public class IIdentityToken
    {
        Guid UserId { get; }
        string Role { get; }
    }
}
