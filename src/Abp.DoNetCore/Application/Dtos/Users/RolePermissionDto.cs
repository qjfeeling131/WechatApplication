using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Abp.DoNetCore.Application.Dtos.Users
{
    public class RolePermissionDto
    {
        [Required]
        public Guid? RoleId { get; set; }
        [Required]
        public List<Guid?> PermissionIds { get; set; }
    }
}
