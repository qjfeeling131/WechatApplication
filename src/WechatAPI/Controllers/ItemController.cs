using Abp.DoNetCore;
using Abp.DoNetCore.Application.Abstracts;
using Abp.DoNetCore.Application.Dtos.Order;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WechatAPI.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : BaseController
    {
        IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        /// <summary>
        /// Add the Item
        /// </summary>
        /// <param name="itemDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] ItemDto itemDto)
        {
            return (Ok(await _itemService.AddOrUpdateItemAsync(CurrentUser, itemDto, false)));
        }
        /// <summary>
        /// Update the Item
        /// </summary>
        /// <param name="itemDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateItem([FromBody] ItemDto itemDto)
        {
            return Ok(await _itemService.AddOrUpdateItemAsync(CurrentUser, itemDto, false));
        }

        /// <summary>
        /// Delete the Item
        /// </summary>
        /// <param name="itemDto"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> RemoveItem([FromBody] ItemDto itemDto)
        {
            return Ok(await _itemService.AddOrUpdateItemAsync(CurrentUser, itemDto, true));
        }
    }
}
