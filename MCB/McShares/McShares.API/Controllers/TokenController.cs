using McShares.API.Method;
using McShares.Core.Constant;
using McShares.Core.ViewModels;
using McShares.Core.ViewModels.Account;
using McShares.Services.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace McShares.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class TokenController : ControllerBase
    {
        #region Declare Variables
        private readonly IAccountService _accountService;
        public IConfiguration _configuration;
        #endregion

        #region Constructor
        public TokenController(IAccountService accountService, IConfiguration config)
        {
            _accountService = accountService;
            _configuration = config;
        }
        #endregion

        #region Method
        /// <summary>
        /// generate JWT token if user credential is valid
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("GenerateToken")]
        public async Task<IActionResult> GenerateToken(UserInfo userInfo)
        {
            if (userInfo != null)
            {
                DataProcessResponseModel response = await _accountService.ValidUser(userInfo);
                if (response.IsSuccess)
                {
                    var tokenString = CommonMethod.GenerateJSONWebToken(userInfo, _configuration);
                    return Ok(new { token = tokenString });
                }
                else
                {
                    return Unauthorized(Constants.INVALID_CREDENTIAL);
                }
            }
            else
            {
                return BadRequest();
            }
        }
      
        #endregion
    }
}
