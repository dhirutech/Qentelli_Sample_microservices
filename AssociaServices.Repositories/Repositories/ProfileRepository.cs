using AssociaServices.Repositories.Interfaces;
using AssociaServices.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssociaServices.Repositories.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        public async Task<bool> AddLogin(AppaAccessLog appaAccessLog)
        {
            using (var context = new testdbContext())
            {
                await context.AppaAccessLog.AddAsync(appaAccessLog);
                return await context.SaveChangesAsync() > 0;
            }
        }

        public async Task<UserAccount> GetLogedInUserProfile(string userName, string password)
        {
            using (var context = new testdbContext())
            {
                return await context.UserAccount
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password && u.IsActive);
            }
        }

        public async Task<UserAccount> GetUserProfile(Guid userId)
        {
            using (var context = new testdbContext())
            {
                return await context.UserAccount
                       .Include(u => u.Role)
                       .Include(u => u.Company)
                       .FirstOrDefaultAsync(u => u.Id == userId && u.IsActive);
            }
        }

        public async Task<bool> UpdateLogin(AppaAccessLog appaAccessLog)
        {
            using (var context = new testdbContext())
            {
                var login = await context.AppaAccessLog
                                   .FirstOrDefaultAsync(l => l.UserId == appaAccessLog.UserId && l.IsActive);
                if (login != null)
                {
                    login.Token = appaAccessLog.Token;
                    login.RefreshToken = appaAccessLog.RefreshToken;
                    login.UpdatedDateTime = DateTimeOffset.UtcNow;
                }
                return await context.SaveChangesAsync() > 0;
            }
        }
    }
}
