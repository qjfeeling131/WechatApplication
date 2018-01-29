using Abp.DoNetCore;
using Abp.DoNetCore.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WechatAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        // GET: /<controller>/
        [HttpGet()]
        [Authorize(Policy = MimeoOAPolicyType.PolicyName)]
        public IActionResult GetAllUsers()
        {
            return View();
        }


    }
}
