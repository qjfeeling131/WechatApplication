using Abp;
using Abp.DoNetCore;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Configurations;
using Abp.Modules;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using WechatAPI.Core.MimeoDBContext;

namespace UnitTestWechatServices
{
    [DependsOn(typeof(AbpDoNetCoreModule))]
    public class TestServiceModule : AbpModule
    {
        public override void Initialize(ContainerBuilder builder)
        {
            Dictionary<DBSelector, string> dbConnections = new Dictionary<DBSelector, string>();
            dbConnections.Add(DBSelector.Master, "Server=127.0.0.1;port=3306;database=ordersystem;uid=root;pwd=123456");
            dbConnections.Add(DBSelector.Slave, "Server=127.0.0.1;port=3306;database=ordersystem;uid=root;pwd=123456");
            builder.RegisterInstance(new EFCoreDataBaseOptions { DbConnections = dbConnections }).SingleInstance();
            //builder.Register(ctx => ctx.Resolve<IOptions<EFCoreDataBaseOptions>>().Value).InstancePerLifetimeScope();
            builder.RegisterType<DefaultDbContextResolver<WechatContext>>().As<IDbContextResolver>().InstancePerLifetimeScope();

            builder.RegisterType<AbpDbContextConfigurerAction<WechatContext>>().As<IAbpDbContextConfigurer<WechatContext>>().WithParameter(new NamedParameter("action", new Action<AbpDbContextConfiguration<WechatContext>>(options => { options.DbContextOptions.UseMySql(options.ConnectionString); })));
        }
    }
}
