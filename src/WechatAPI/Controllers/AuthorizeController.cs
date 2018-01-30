using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.DoNetCore;
using Abp.DoNetCore.Application;
using Abp.DoNetCore.Application.Dtos;
using Abp.DoNetCore.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WechatAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizeController : BaseController
    {
        private readonly Abp.DoNetCore.Application.IAuthorizationService _authorizeService;


        public AuthorizeController(Abp.DoNetCore.Application.IAuthorizationService authorizeService)
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
