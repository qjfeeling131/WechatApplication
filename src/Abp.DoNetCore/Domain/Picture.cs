using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.DoNetCore.Domain
{
    public class Picture : Entity
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public string Path { get; set; }
    }
}
