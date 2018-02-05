using System;
using Abp.Domain.Entities;
using Abp.DoNetCore.Common;

namespace Abp.DoNetCore.Domain
{
    public class Item : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public decimal PromotionPrice { get; set; }
        public ItemStatus Status { get; set; }
    }


}
