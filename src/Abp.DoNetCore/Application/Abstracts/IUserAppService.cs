using System;
using System.Threading.Tasks;
using Abp.DoNetCore.Application.Dtos;
using Abp.DoNetCore.Application.Dtos.Users;

namespace Abp.DoNetCore.Application.Abstracts
{
    public interface IUserAppService
    {
        Task<RESTResult> AddOrUpdateUserAsync(Guid currentUserId, Guid id, bool isAdd, RegisterUserDto input);

        Task<RESTResult> AddOrUpdateUserInfo(UserInfoDto userInfo, Guid userId);

        Task<bool> UpdateUserAsync(ApplicationUser input);

        Task<UserDto> GetUserInformationsAsync(string accountName);

        Task<RESTResult> RemoveUserAsync(Guid id);

        Task<RESTResult> GetUsers(UserDto currentUser, int pageIndex, int pageSize);

        Task<RESTResult> GetUserInformationByIdAsync(Guid userId);

        Task<bool> AuthorizationOfUser(ApplicationUser input);

        Task<bool> AddNewRoleAsync(Guid userId, RoleDto roleInfo);

        Task<RESTResult> UpdateRoleAsync(Guid currentUserId, bool isDeleted, RoleDto roleInfo);

        Task<bool> RemoveRoleAsync(Guid roleId);

        Task<RESTResult> GetRoles(UserDto currentUser, int pageIndex, int pageSize);

        Task<RESTResult> GetDepartmentsAsync(UserDto currentUser,int pageIndex, int pageSize);

        Task<RESTResult> AddOrUpdateDepartmentAsync(DepartmentDto departmentInfo, Guid userId, bool IsDeleted);

        Task<RESTResult> SetDeaprtmentAndRoleAsync(Guid userRoleId, Guid curretnUserId, Guid userId, Guid roleId, Guid departmentId);

        Task<RESTResult> AddOrUpdateUserDepartmentAsync(Guid curretnUserId, Guid userId, Guid departmentId);

        Task<RESTResult> AddOrUpdatePermissionAsync(PermissionDto permissionInfo, Guid currentUserId, bool IsDeleted);

        Task<RESTResult> GetPermissionByPagingAsync(Guid currentUserId, int pageIndex, int pageSize);

        Task<RESTResult> SetPermissionToRoleAsync(Guid currentUserId, RolePermissionDto rolePermissionInfo);

        Task<RESTResult> GetMenusToCurrentUser(Guid userId);
    }
}
