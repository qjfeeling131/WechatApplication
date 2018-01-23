using System;
using Abp.Domain.Entities;

namespace Abp.DoNetCore.Domain
{
    public class Recieve:Entity
    {
        public Guid UserId { get; set; }
        public string Address { get; set; }
    }
}
