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
using System.IO;
using Microsoft.Extensions.Options;
using Abp.DoNetCore.Common;
using Abp.Domain.Services;

namespace Abp.DoNetCore.Application
{
    public class ItemService : DomainService, IItemService
    {
        public IRepository<Item> _itemRepository;
        public IRepository<Picture> _pictureRepository;
        public IOptions<BaseOptions> _baseOptions;
        public ItemService(IRepository<Item> itemRepository, IRepository<Picture> pictureRepository, IOptions<BaseOptions> baseOptions)
        {
            _itemRepository = itemRepository;
            _pictureRepository = pictureRepository;
            _baseOptions = baseOptions;
        }

        public async Task<RESTResult> AddOrUpdateItemAsync(UserDto currentUser, ItemDto item, bool isDeleted)
        {
            RESTResult result = new RESTResult
            {
                Code = Common.RESTStatus.Failed,
                Message = "Set Item Failed"
            };
            if (isDeleted)
            {
                if (item.Id.Equals(Guid.Empty))
                {
                    throw new ArgumentException("Please input correct item data");
                }
                var itemEntity = await _itemRepository.GetAsync(item.Id);
                if (itemEntity != null)
                {
                    itemEntity.Name = item.Name;
                    itemEntity.Price = item.Price;
                    itemEntity.PromotionPrice = item.PromotionPrice;
                    itemEntity.Status = item.Status;
                    itemEntity.Unit = item.Unit;
                    await _itemRepository.UpdateAsync(itemEntity);
                    result.Code = RESTStatus.Success;
                    result.Message = "Set Item successfully";
                }
            }
            else
            {
                var itemEntity = Mapper.Map<ItemDto, Item>(item);
                itemEntity.Id = Guid.NewGuid();
                await _itemRepository.InsertAsync(itemEntity);
                result.Code = RESTStatus.Success;
                result.Message = "Set Item successfully";
            }

            return result;
        }

        public async Task<RESTResult> GetItemDetailedByIdAsync(UserDto currentUser, Guid itemId)
        {
            RESTResult result = new RESTResult
            {
                Code = Common.RESTStatus.Success,
                Message = "Get item detailed data successfully"
            };

            var itemEntity = await _itemRepository.GetAsync(itemId);
            var itemDto = Mapper.Map<Item, ItemDto>(itemEntity);
            //TODO: get pictures
            var pictureEntity = await _pictureRepository.GetAllListAsync(item => item.ItemId.Equals(itemId));
            pictureEntity.ForEach(pictureItem =>
            {
                itemDto.PictureLink.Add($"{_baseOptions.Value.Host}/{pictureItem.Id}");
            });
            result.Data = itemDto;

            return result;
        }

        public async Task<Stream> GetItemPictureAsync(Guid itemId)
        {
            var pictureEntity = await _pictureRepository.GetAsync(itemId);
            using (FileStream fs = new FileStream(pictureEntity.Path, FileMode.Open, FileAccess.Read))
            using (MemoryStream momeryStream = new MemoryStream())
            {
                await fs.CopyToAsync(momeryStream);
                return momeryStream;
            }
        }

        public async Task<RESTResult> GetItemsByPageAsync(UserDto currentUser, int pageIndex, int pageSize)
        {
            RESTResult result = new RESTResult
            {
                Code = Common.RESTStatus.Success
            };
            IList<ItemDto> itemDtos = null;
            //TODO: get items from paging
            var itemModels = (await _itemRepository.GetAllListAsync()).Take(pageIndex * pageSize).Skip(pageSize * (pageIndex - 1));
            if (itemModels.Count() > 0)
            {
                itemDtos = new List<ItemDto>();
                foreach (var item in itemModels)
                {
                    itemDtos.Add(Mapper.Map<Item, ItemDto>(item));
                }

            }
            return result;
        }
    }
}
