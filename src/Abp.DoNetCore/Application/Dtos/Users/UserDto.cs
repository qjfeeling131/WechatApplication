using Abp.AutoMapper;
using Abp.DoNetCore.Common;
using Abp.DoNetCore.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Abp.DoNetCore.Application.Dtos.Users
{
    [AutoMapFrom(typeof(User))]
    [DisplayName("user")]
    public class UserDto
    {
        public Guid? Id { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public string Phone { get; set; }
        public UserActiveStatus Actived { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public UserInfoDto UserInfo { get; set; }
        private List<RoleDto> _roles;
        public List<RoleDto> Roles
        {
            get
            {
                if (_roles == null)
                {
                    _roles = new List<RoleDto>();
                }
                return _roles;
            }
            set
            {
                _roles = value;
            }
        }
        public DepartmentDto Department { get; set; }
        private List<PermissionDto> _permissions;
        public List<PermissionDto> Permissions
        {
            get
            {
                if (_permissions == null)
                {
                    _permissions = new List<PermissionDto>();
                }
                return _permissions;
            }
            set
            {
                _permissions = value;
            }
        }

    }
}
