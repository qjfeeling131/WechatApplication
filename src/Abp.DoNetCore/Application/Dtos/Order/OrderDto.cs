using System;
using Newtonsoft.Json;

namespace Abp.DoNetCore.Application.Dtos.Order
{
    public class OrderDto
    {
        [JsonIgnore]
        public Guid OwnerUserId { get; set; }
        public string FriendlyId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal FixedPrice { get; set; }
        public decimal Total { get; set; }
        public decimal DeliveryTotal { get; set; }
        [JsonIgnore]
        public Guid ApplicationSubId { get; set; }
        public string Remark { get; set; }
    }
}
