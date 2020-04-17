using AssociaServices.Interfaces;
using AssociaServices.Models;
using AssociaServices.Security.Interfaces;
using AssociaServices.Security.Logics;
using AssociaServices.Security.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AssociaServices.Controllers
{
    [Route("api/profile")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileLogic _profileLogic;
        private readonly IServiceHelper _helper;

        public ProfileController(IProfileLogic profileLogic, IServiceHelper helper)
        {
            _profileLogic = profileLogic;
            _helper = helper;
        }

        private IdentityToken InitializeToken()
        {
            var authorizationHeader = HttpContext.Request.Headers["Authorization"];
            return new IdentityToken(AuthenticationHeaderValue.Parse(authorizationHeader));
        }

        [ValidateAuthorization("Roles", "Administrator,L2User,L3User")]
        [HttpGet("getuserprofile")]
        public async Task<ActionResult> GetUserProfile()
        {
            var _token = InitializeToken();
            try
            {
                var result = await _profileLogic.GetUserProfile(_token.UserId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return _helper.CreateApiError(ex);
            }
        }
    }
}