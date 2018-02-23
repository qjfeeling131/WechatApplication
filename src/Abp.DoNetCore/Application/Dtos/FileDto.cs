using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.DoNetCore.Application.Dtos
{
    public class FileDto
    {
        public Guid Id { get; set; }

        public IFormFile FormFile { get; set; }
    }
}
