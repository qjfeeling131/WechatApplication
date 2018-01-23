using System;
using Abp.Domain.Entities;

namespace Abp.DoNetCore.Domain
{
    public class ItemPicture:Entity
    {
        Guid ItemId { get; set; }
        string Path { get; set; }
        int Sort { get; set; }
    }

}
