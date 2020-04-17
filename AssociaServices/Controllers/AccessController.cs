using AssociaServices.Interfaces;
using AssociaServices.Models;
using AssociaServices.Security.Interfaces;
using AssociaServices.Security.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AssociaServices.Controllers
{
    [Route("api/access")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AccessController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IProfileLogic _profileLogic;
        private readonly IServiceHelper _helper;

        public AccessController(IAuthService authService, IProfileLogic profileLogic, IServiceHelper helper)
        {
            _authService = authService;
            _profileLogic = profileLogic;
            _helper = helper;
        }

        [HttpPost("getaccesstoken")]
        public async Task<ActionResult> GetAccessToken(Login Login)
        {
            try
            {
                var result = await _profileLogic.GetLogedInUserProfile(Login.UserName, Login.Password);
                if (result == null)
                    return Unauthorized(_helper.BuildResponse("Error", null, "Invalid Credentials", (int)HttpStatusCode.Unauthorized));

                var loggedInUserDetail = new UserDetail()
                {
                    UserId = result.UserId,
                    UserName = result.UserName,
                    Password = result.Password,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Role = result.Role
                };
                var accessToken = await _authService.GetAccessToken(loggedInUserDetail);
                await _profileLogic.AddLogin(result.UserId, accessToken.Token, accessToken.Refreshtoken);
                if (accessToken == null)
                    return Unauthorized(_helper.BuildResponse("Error", null, "Invalid Credentials", (int)HttpStatusCode.Unauthorized));

                return Ok(accessToken);
            }
            catch (Exception ex)
            {
                return _helper.CreateApiError(ex);
            }
        }
    }
}
