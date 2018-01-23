using Abp.DoNetCore.Domain;
using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WechatAPI.Core.MimeoDBContext
{
    public class MimeoOAContext : AbpDbContext
    {
        public DbSet<User> mo_user { get; set; }
        public DbSet<Role> mo_role { get; set; }
        public DbSet<UserInfo> mo_user_info { get; set; }
        public DbSet<UserRole> mo_user_role { get; set; }
        public DbSet<Permission> mo_permission { get; set; }
        public DbSet<RolePermission> mo_role_permission { get; set; }
        public DbSet<LineItem> mo_line_item { get; set; }
        public DbSet<Item> mo_item { get; set; }
        public DbSet<Recieve> mo_recieve { get; set; }
        public DbSet<Order> mo_order { get; set; }
        public DbSet<Receipt> mo_receipt { get; set; }
        public MimeoOAContext(DbContextOptions<MimeoOAContext> options):base(options)
        {
        }

    }
}
