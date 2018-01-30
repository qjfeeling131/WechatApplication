using System;
using Abp.DoNetCore;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Configurations;
using Abp.Modules;
using Autofac;
using Microsoft.EntityFrameworkCore;
using WechatAPI.Core.MimeoDBContext;

namespace WechatAPI.Core.Module
{
    [DependsOn(typeof(AbpDoNetCoreModule))]
    public class WechatModule : AbpModule
    {
        public override void Initialize(ContainerBuilder builder)
        {
            builder.RegisterType<DefaultDbContextResolver<WechatContext>>().As<IDbContextResolver>().InstancePerLifetimeScope();
            builder.RegisterType<AbpDbContextConfigurerAction<WechatContext>>().As<IAbpDbContextConfigurer<WechatContext>>().WithParameter(new NamedParameter("action", new Action<AbpDbContextConfiguration<WechatContext>>(options=> { options.DbContextOptions.UseMySql(options.ConnectionString); })));
        }
    }
}
