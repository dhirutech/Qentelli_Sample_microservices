using AssociaServices.Security.Models;
using System.Threading.Tasks;

namespace AssociaServices.Security.Interfaces
{
    public interface IAuthService
    {
        Task<AuthToken> GetAccessToken(UserDetail user);
    }
}
