using Abp.DoNetCore;
using Abp.DoNetCore.Application.Abstracts;
using Abp.DoNetCore.Application.Dtos.Order;
using Abp.DoNetCore.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WechatAPI.Controllers
{
    [Route("api/[controller]s")]
    [Authorize(Policy = MimeoOAPolicyType.PolicyName)]
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
            return (Ok(await _itemService.AddOrUpdateItemAsync(CurrentUser, itemDto, true)));
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveItem(Guid id)
        {
            return Ok(await _itemService.RemoveItemAsync(id));
        }

        /// <summary>
        /// Get the item by paging
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet()]
        public async Task<IActionResult> GetItemByPage(int pageIndex, int pageSize)
        {
            return Ok(await _itemService.GetItemsByPageAsync(CurrentUser, pageIndex, pageSize));
        }

        /// <summary>
        /// Get detailed information by itemId
        /// </summary>
        /// <param name="id">Item id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemByDetailed(Guid id)
        {
            return Ok(await _itemService.GetItemDetailedByIdAsync(CurrentUser, id));
        }
    }
}
