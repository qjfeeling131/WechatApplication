using Abp.DoNetCore;
using Abp.DoNetCore.Application.Abstracts;
using Abp.DoNetCore.Application.Dtos;
using Abp.DoNetCore.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WechatAPI.Controllers
{
    [Route("api/[controller]s")]
    [Authorize(Policy = MimeoOAPolicyType.PolicyName)]
    [Consumes("application/json", "application/json-patch+json", "multipart/form-data")]
    public class DigitalAssetController : BaseController
    {
        private readonly IItemService _itemService;
        public DigitalAssetController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost("uploadFiles")]
        [Produces("application/json")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size, filePath });

        }

        [HttpPost("uplaodDigitalFile")]
        [Produces("application/json")]
        public async Task<IActionResult> PostFile(IFormFile file)
        {
            return Ok();
        }

        [HttpPost("uplaodPicture")]
        public async Task<IActionResult> PostPicture(FileDto file)
        {
            return Ok(await _itemService.UploadItemPictureAsync(CurrentUser, file.FormFile, Guid.Parse("98a718bd-586b-41f7-9db4-de686d1f0fd2")));
        }

    }
}
