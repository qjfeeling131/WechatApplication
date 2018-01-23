using System;
using Newtonsoft.Json;

namespace Abp.DoNetCore.Application.Dtos.Order
{
    public class LineItemDto
    {
        [JsonIgnore]
        public Guid OrderId { get; set; }
        public Guid FriendlyId { get; set; }
        [JsonIgnore]
        public Guid ItemId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal FixedPrice { get; set; }
        public double Quantity { get; set; }
        public string Remark { get; set; }

    }
}
