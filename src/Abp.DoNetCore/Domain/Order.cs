using System;
using Abp.Domain.Entities;

namespace Abp.DoNetCore.Domain
{
    public class Order:Entity
    {
        public Guid OwnerUserId { get; set; }
        public string FriendlyId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal FixedPrice { get; set; }
        public decimal Total { get; set; }
        public decimal DeliveryTotal { get; set; }
        public Guid ApplicationSubId { get; set; }
        public string Remark { get; set; }

    }
}
