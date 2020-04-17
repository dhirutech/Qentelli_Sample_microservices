using AssociaServices.Interfaces;
using AssociaServices.Models;
using AssociaServices.Repositories.Interfaces;
using AssociaServices.Repositories.Models;
using AssociaServices.Security.Interfaces;
using AssociaServices.Security.Models;
using AutoMapper;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AssociaServices.Logics
{
    public class ProfileLogic : IProfileLogic
    {
        private readonly IProfileRepository _profileRepo;
        private readonly IServiceHelper _helper;
        private readonly IMapper _mapper;

        public ProfileLogic(IMapper mapper, IProfileRepository profileRepo, IServiceHelper helper)
        {
            _mapper = mapper;
            _profileRepo = profileRepo;
            _helper = helper;
        }

        public async Task<LoginUser> GetLogedInUserProfile(string userName, string password)
        {
            var result = await _profileRepo.GetLogedInUserProfile(userName, password);
            var loginUser = _mapper.Map<LoginUser>(result);
            return loginUser;
        }

        public async Task<ResponseObject> GetUserProfile(Guid userId)
        {
            var result = await _profileRepo.GetUserProfile(userId);
            var loginUser = _mapper.Map<LoginUser>(result);
            return _helper.BuildResponse("Success", loginUser, "Profile Details fetched successfully!", (int)HttpStatusCode.OK);
        }

        public async Task<bool> AddLogin(Guid userId, string token, string refreshtoken)
        {
            var login = new AppaAccessLog()
            {
                Id = Guid.NewGuid(),
                Token = token,
                RefreshToken = refreshtoken,
                UserId = userId,
                IsActive = true,
                CreatedDateTime = DateTimeOffset.UtcNow,
                UpdatedDateTime = DateTimeOffset.UtcNow
            };
            return await _profileRepo.AddLogin(login);
        }

        public async Task<bool> UpdateLogin(Guid userId, string token, string refreshtoken)
        {
            var login = new AppaAccessLog()
            {
                Token = token,
                RefreshToken = refreshtoken,
                UserId = userId
            };
            return await _profileRepo.UpdateLogin(login);
        }
    }
}
