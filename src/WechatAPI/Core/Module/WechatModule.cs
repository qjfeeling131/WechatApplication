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
            builder.RegisterType<DefaultDbContextResolver<MimeoOAContext>>().As<IDbContextResolver>().InstancePerLifetimeScope();
            builder.RegisterType<AbpDbContextConfigurerAction<MimeoOAContext>>().As<IAbpDbContextConfigurer<MimeoOAContext>>().WithParameter(new NamedParameter("action", new Action<AbpDbContextConfiguration<MimeoOAContext>>(options=> { options.DbContextOptions.UseMySql(options.ConnectionString); })));
        }
    }
}
