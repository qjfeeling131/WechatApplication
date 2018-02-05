using Abp;
using Abp.Dependency;
using Abp.DoNetCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestWechatServices
{
    public class UnitTestOrderService
    {
        private readonly AbpBootstrapper _AbpBootStrapper = AbpBootstrapper.Create<AbpDoNetCoreModule>(IocManager.Instance);

        public UnitTestOrderService()
        {

            _AbpBootStrapper.Initialize();

            _AbpBootStrapper.IocManager.BuildComponent();

        }
        public void OrderService_ShouldGetOrders()
        {

        }
    }
}
