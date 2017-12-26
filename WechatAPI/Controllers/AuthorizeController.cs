using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.DoNetCore;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WechatAPI.Controllers
{
    public class AuthorizeController : BaseController
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
