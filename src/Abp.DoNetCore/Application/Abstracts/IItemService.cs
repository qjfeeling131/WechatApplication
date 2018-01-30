using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Abp.DoNetCore.Application.Dtos.Order;
using Abp.DoNetCore.Application.Dtos.Users;
using Abp.DoNetCore.Application.Dtos;

namespace Abp.DoNetCore.Application.Abstracts
{
    public interface IItemService
    {
        /// <summary>
        /// Gets the items by page async.
        /// </summary>
        /// <returns>The items by page async.</returns>
        /// <param name="pageIndex">Page index.</param>
        /// <param name="pageSize">Page size.</param>
        /// <param name="currentUser">Current user.</param>
        Task<IList<ItemDto>> GetItemsByPageAsync(int pageIndex, int pageSize, UserDto currentUser);
        /// <summary>
        /// Adds or updates item async.
        /// </summary>
        /// <returns>The or update item async.</returns>
        /// <param name="currentUser">Current user.</param>
        /// <param name="item">Item.</param>
        /// <param name="isDeleted">If set to <c>true</c> is deleted.</param>
        Task<RESTResult> AddOrUpdateItemAsync(UserDto currentUser,ItemDto item,bool isDeleted);
    }
}
