using System;
using Abp.Domain.Entities;

namespace Abp.DoNetCore.Domain
{
    public class Customer:Entity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Guid RecieveId { get; set; }
        public string CardNo { get; set; }
        public int CardType { get; set; }
        public string Remark { get; set; }
    }
}
