using System;
using Newtonsoft.Json;

namespace Abp.DoNetCore.Application.Dtos.Order
{
    public class RecieveDto
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public string Address { get; set; }
    }
}
