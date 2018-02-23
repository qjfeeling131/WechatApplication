using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.DoNetCore.Application.Abstracts;
using Abp.DoNetCore.Application.Dtos;
using Abp.DoNetCore.Application.Dtos.Order;
using Abp.DoNetCore.Application.Dtos.Users;
using Abp.DoNetCore.Common;
using Abp.DoNetCore.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<RESTResult> AddOrUpdateItemAsync(UserDto currentUser, ItemDto item, bool isNew)
        {
            RESTResult result = new RESTResult
            {
                Code = Common.RESTStatus.Failed,
                Message = "Set Item Failed"
            };
            if (!isNew)
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

        public async Task<RESTResult> RemoveItemAsync(Guid itemId)
        {
            RESTResult result = new RESTResult
            {
                Code = RESTStatus.Failed,
                Message = "Remove ITem Filaed"
            };

            var itemEntity = await _itemRepository.GetAsync(itemId);
            if (itemEntity == null)
            {
                result.Message = "Can not find the item, please input the correct id";
                return result;
            }
            //TODO:Remove the item, set the IsDeleted as true;
            itemEntity.IsDeleted = true;
            await _itemRepository.UpdateAsync(itemEntity);
            result.Code = RESTStatus.Success;
            result.Message = "Successed";
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

        public async Task<RESTResult> UploadItemPicture()
        {
            RESTResult result = new RESTResult
            {
                Code = RESTStatus.Success,
                Message = "Upload Successful"
            };
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
            var itemModels = (await _itemRepository.GetAllListAsync(c => c.IsDeleted = false)).Take(pageIndex * pageSize).Skip(pageSize * (pageIndex - 1));
            if (itemModels.Count() > 0)
            {
                itemDtos = new List<ItemDto>();
                foreach (var item in itemModels)
                {
                    itemDtos.Add(Mapper.Map<Item, ItemDto>(item));
                }
                result.Data = itemDtos;

            }
            return result;
        }

        public async Task<RESTResult> UploadItemPictureAsync(UserDto currentUser, IFormFile formFile, Guid itemId)
        {
            RESTResult result = new RESTResult { Code = RESTStatus.Success, Message = "Uplaod Successfully" };
            //TODO:Get the item entity from DB
            var itemEntity = _itemRepository.Get(itemId);
            if (itemEntity == null)
            {
                throw new ArgumentException("The itemId doesn't exist, please try agian");
            }
            List<Task> uploadTasks = new List<Task>();
            //TODO:Store the picture of item to physical memory
            var folder = Path.Combine(Utilities.GetFilePathOfStoring(), $"{currentUser.Id.ToString()}/{ itemId.ToString()}");
            Directory.CreateDirectory(folder);
            var physicalPath = Path.Combine(folder, $"{formFile.FileName}");
            if (File.Exists(physicalPath))
            {
                throw new InvalidOperationException("The file have been uplaod");
            }
            using (var stream = new FileStream(physicalPath, FileMode.CreateNew))
            {
                await formFile.CopyToAsync(stream);
                uploadTasks.Add(formFile.CopyToAsync(stream));
                uploadTasks.Add(_pictureRepository.InsertAndGetIdAsync(new Picture { ItemId = itemId, Name = formFile.FileName, ContentType = formFile.ContentType, Id = Guid.NewGuid(), Path = physicalPath }));
                try
                {

                    await Task.WhenAll(uploadTasks);
                }
                catch (Exception exc)
                {
                    foreach (var taskFault in uploadTasks.Where(t => t.IsFaulted))
                    {
                        //retry one time.
                        await taskFault;
                    }
                }
            }
            return result;
        }
    }
}
