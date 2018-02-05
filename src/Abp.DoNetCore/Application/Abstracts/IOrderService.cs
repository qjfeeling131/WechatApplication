using Abp.DoNetCore.Application.Dtos;
using Abp.DoNetCore.Application.Dtos.Order;
using Abp.DoNetCore.Application.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Abp.DoNetCore.Application.Abstracts
{
    public interface IOrderService
    {
        /// <summary>
        /// Get orders by paging
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<RESTResult>> GetOrdersByPagingAsync(UserDto currentUser, int pageIndex, int pageSize);

        


    }
}
