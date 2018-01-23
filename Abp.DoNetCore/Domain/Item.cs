using System;
using Abp.Domain.Entities;

namespace Abp.DoNetCore.Domain
{
    public class Item:Entity
    {
        public string Name { get; set; }
        public string Unit { get; set; }
    }
}
