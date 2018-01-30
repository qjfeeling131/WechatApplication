using System;
using Abp.DoNetCore.Application.Abstracts;
using Abp.Domain.Repositories;
using Abp.DoNetCore.Domain;
using Abp.DoNetCore.Application.Dtos;
using Abp.DoNetCore.Application.Dtos.Order;
using Abp.DoNetCore.Application.Dtos.Users;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;

namespace Abp.DoNetCore.Application
{
    public class ItemService:IItemService
    {
        public IRepository<Item> _itemRepository;
        public ItemService(IRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<RESTResult> AddOrUpdateItemAsync(UserDto currentUser, ItemDto item, bool isDeleted)
        {
            RESTResult result = new RESTResult { 
                Code=Common.RESTStatus.Success,
                Message="Set Item Successfully"
            }; 
            if (isDeleted)
            {

            }

            return result;
        }

        public Task<IList<ItemDto>> GetItemsByPageAsync(int pageIndex, int pageSize, UserDto currentUser)
        {
            IList<ItemDto> itemDtos = null;
            //TODO: get items from paging
            var itemModels= _itemRepository.GetAll().Take((pageIndex - 1) * pageSize).Skip(pageSize).ToList();
            if (itemModels.Count()>0)
            {
                itemDtos = new List<ItemDto>();
                foreach (var item in itemModels)
                {
                    itemDtos.Add(Mapper.Map<Item, ItemDto>(item));
                }

            }
            return Task.FromResult(itemDtos);
        }
    }
}
