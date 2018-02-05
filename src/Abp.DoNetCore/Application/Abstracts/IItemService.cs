using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Abp.DoNetCore.Application.Dtos.Order;
using Abp.DoNetCore.Application.Dtos.Users;
using Abp.DoNetCore.Application.Dtos;
using System.IO;

namespace Abp.DoNetCore.Application.Abstracts
{
    public interface IItemService
    {
        /// <summary>
        /// Gets the items by page async.
        /// </summary>
        /// <returns>The items by page async.</returns>
        /// <param name="pageIndex">Page index, default value as 0</param>
        /// <param name="pageSize">Page size. default value as 500</param>
        /// <param name="currentUser">Current user.</param>
        Task<RESTResult> GetItemsByPageAsync(UserDto currentUser,int pageIndex = 0, int pageSize = 500);

        /// <summary>
        /// Get the details information for item
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        Task<RESTResult> GetItemDetailedByIdAsync(UserDto currentUser, Guid itemId);

        /// <summary>
        /// Get the picture of item;
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        Task<Stream> GetItemPictureAsync(Guid itemId);
        /// <summary>
        /// Adds or updates item async.
        /// </summary>
        /// <returns>The or update item async.</returns>
        /// <param name="currentUser">Current user.</param>
        /// <param name="item">Item.</param>
        /// <param name="isDeleted">If set to <c>true</c> is deleted.</param>
        Task<RESTResult> AddOrUpdateItemAsync(UserDto currentUser, ItemDto item, bool isDeleted);
    }
}
