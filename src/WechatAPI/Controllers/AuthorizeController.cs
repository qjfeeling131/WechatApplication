using System.Threading.Tasks;
using Abp.DoNetCore;
using Abp.DoNetCore.Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WechatAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizeController : BaseController
    {
        private readonly Abp.DoNetCore.Application.Abstracts.IAuthorizationService _authorizeService;


        public AuthorizeController(Abp.DoNetCore.Application.Abstracts.IAuthorizationService authorizeService)
        {
            _authorizeService = authorizeService;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Authorize([FromBody]ApplicationUser userInfo)
        {
            var result = await _authorizeService.AuthorizationUser(userInfo);
            return Ok(result);
        }
    }
}
