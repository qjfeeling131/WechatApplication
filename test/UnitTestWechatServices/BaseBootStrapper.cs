using Abp;
using Abp.Dependency;
using Abp.DoNetCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestWechatServices
{
    public abstract class BaseBootStrapper
    {
        protected readonly AbpBootstrapper _AbpBootStrapper = AbpBootstrapper.Create<TestServiceModule>(IocManager.Instance);

        public BaseBootStrapper()
        {
            _AbpBootStrapper.Initialize();
            _AbpBootStrapper.IocManager.BuildComponent();
            this.Init();
        }

        protected abstract void Init();
    }
}
