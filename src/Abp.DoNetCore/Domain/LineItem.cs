using System;
using Abp.Domain.Entities;

namespace Abp.DoNetCore.Domain
{
    public class LineItem:Entity
    {
        public Guid OrderId { get; set; }
        public Guid FriendlyId { get; set; }
        public Guid ItemId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal FixedPrice { get; set;}
        public double Quantity { get; set; }
        public string Remark { get; set; }
    }
}
