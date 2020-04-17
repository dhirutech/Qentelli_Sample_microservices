using AssociaServices.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssociaServices.Repositories.Interfaces
{
    public interface IProfileRepository
    {
        Task<UserAccount> GetLogedInUserProfile(string userName, string password);
        Task<bool> AddLogin(AppaAccessLog appaAccessLog);
        Task<bool> UpdateLogin(AppaAccessLog appaAccessLog);
        Task<UserAccount> GetUserProfile(Guid userId);
    }
}
