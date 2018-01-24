using System;

using Abp;
using Abp.Dependency;
using Abp.DoNetCore;
using Xunit;

namespace UnitTestWechatServices
{
    public class UnitTestAuthorizeService
    {
        private readonly AbpBootstrapper _AbpBootStrapper = AbpBootstrapper.Create<AbpDoNetCoreModule>(IocManager.Instance);

        public UnitTestAuthorizeService()
        {

            _AbpBootStrapper.Initialize();

            _AbpBootStrapper.IocManager.BuildComponent();

        }
        [Fact]
        public void AuthorizationUser_ShouldGetTokenSuccessfully()

        {
        }

    }
}
