using Abp.Domain.Repositories;
using Abp.DoNetCore.Application;
using Abp.DoNetCore.Application.Abstracts;
using Abp.DoNetCore.Application.Dtos.Order;
using Abp.DoNetCore.Application.Dtos.Users;
using Abp.DoNetCore.Common;
using Abp.DoNetCore.Domain;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestWechatServices
{
    public class UnitTestItemService : BaseBootStrapper
    {
        IRepository<Item> _itemRepository;
        IRepository<Picture> _pirctureRepository;
        Mock<IOptions<BaseOptions>> _mock_Options;
        protected override void Init()
        {
            _itemRepository = _AbpBootStrapper.IocManager.Resolve<IRepository<Item>>();
            _pirctureRepository = _AbpBootStrapper.IocManager.Resolve<IRepository<Picture>>();
            _mock_Options = new Mock<IOptions<BaseOptions>>();
            _mock_Options.Setup(c => c.Value).Returns(new BaseOptions { Host = "http:\\localhost" });
        }
        [Fact]
        public async Task AddItem_ShouldBeSuccessfully()
        {
            IItemService itemService = new ItemService(_itemRepository, _pirctureRepository, _mock_Options.Object);
            ItemDto test_itemDto = new ItemDto { Id = Guid.NewGuid(), Name = "test", Price = 1, Status = ItemStatus.Actived, Unit = "kg" };
            UserDto test_currentUser = new UserDto { };
            var result = await itemService.AddOrUpdateItemAsync(test_currentUser, test_itemDto, false);
            Assert.Equal(RESTStatus.Success, result.Code);
        }

        [Fact]
        public async Task UpdateItem_ShouldBeSuccessfully()
        {
            IItemService itemService = new ItemService(_itemRepository, _pirctureRepository, _mock_Options.Object);
            ItemDto test_itemDto = new ItemDto { Id = Guid.NewGuid(), Name = "test", Price = 1, Status = ItemStatus.Actived, Unit = "kg" };
            UserDto test_currentUser = new UserDto { };
            var result = await itemService.AddOrUpdateItemAsync(test_currentUser, test_itemDto, true);
            Assert.Equal(RESTStatus.Success, result.Code);
        }

        [Fact]
        public async Task GetItems_ShouldBeSuccessful()
        {
            IItemService itemService = new ItemService(_itemRepository, _pirctureRepository, _mock_Options.Object);
            UserDto test_currentUser = new UserDto { };
            var result = await itemService.GetItemsByPageAsync(test_currentUser);
            Assert.IsType(typeof(IEnumerable<ItemDto>), result.Data);
        }


    }
}
