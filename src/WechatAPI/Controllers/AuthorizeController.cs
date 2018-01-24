using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.DoNetCore;
using Abp.DoNetCore.Application;
using Abp.DoNetCore.Application.Dtos;
using Abp.DoNetCore.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WechatAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizeController : BaseController
    {
        private readonly IAbpAuthorizationService _authorizeService;


        public AuthorizeController(IAbpAuthorizationService authorizeService){
            _authorizeService = authorizeService;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Authorize(ApplicationUser userInfo)
        {
           var result= _authorizeService.AuthorizationUser(userInfo);
            return Ok(result);
        }
    }
}
