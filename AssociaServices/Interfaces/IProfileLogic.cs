using AssociaServices.Models;
using AssociaServices.Security.Models;
using System;
using System.Threading.Tasks;

namespace AssociaServices.Interfaces
{
    public interface IProfileLogic
    {
        Task<LoginUser> GetLogedInUserProfile(string userName, string password);
        Task<bool> AddLogin(Guid userId, string token, string refreshtoken);
        Task<bool> UpdateLogin(Guid userId, string token, string refreshtoken);
        Task<ResponseObject> GetUserProfile(Guid userId);
    }
}
