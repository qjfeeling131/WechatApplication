using Abp.DoNetCore.Domain;
using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WechatAPI.Core.MimeoDBContext
{
    public class WechatContext : AbpDbContext
    {
        public DbSet<User> ws_user { get; set; }
        public DbSet<Role> ws_role { get; set; }
        public DbSet<UserInfo> ws_user_info { get; set; }
        public DbSet<UserRole> ws_user_role { get; set; }
        public DbSet<Permission> ws_permission { get; set; }
        public DbSet<RolePermission> ws_role_permission { get; set; }
        public DbSet<LineItem> ws_line_item { get; set; }
        public DbSet<Item> ws_item { get; set; }
        public DbSet<Recieve> ws_recieve { get; set; }
        public DbSet<Order> ws_order { get; set; }
        public DbSet<Receipt> ws_receipt { get; set; }
        public WechatContext(DbContextOptions<WechatContext> options):base(options)
        {
        }

    }
}
