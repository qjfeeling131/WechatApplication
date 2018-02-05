using Abp.DoNetCore.Common;
using System;
using System.Collections.Generic;

namespace Abp.DoNetCore.Application.Dtos.Order
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public decimal PromotionPrice { get; set; }
        public ItemStatus Status { get; set; }
        private List<string> _pictureLink;
        public List<string> PictureLink
        {
            get
            {
                if (_pictureLink == null)
                {
                    _pictureLink = new List<string>();
                }
                return _pictureLink;
            }
            set
            {
                _pictureLink = value;
            }
        }
    }
}
