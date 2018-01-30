using Abp;
using Abp.Dependency;
using Abp.DoNetCore;
using Abp.DoNetCore.Application;
using Abp.DoNetCore.Application.Dtos;
using Abp.DoNetCore.Common;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using Abp.DoNetCore.Application.Abstracts;

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
        public async Task AuthorizationUser_ShouldGetTokenSuccessfully()
        {
            ApplicationUser testUser = new ApplicationUser
            {
                AccountName = "admin",
                Password = "1234546"
            };
            RESTResult test_result = new RESTResult
            {
                Code = RESTStatus.Success,
                Data = "TokenString",
                Message = "Get Token Successfully"
            };
            JwtIssuerOptions testOptions = new JwtIssuerOptions
            {
                Audience = "test",
                ValidFor = TimeSpan.FromMinutes(60),
                Issuer = "test",
                Subject = "test_Subjct"
            };
            Mock<IUserAppService> mock_UserAppService = new Mock<IUserAppService>();
            Mock<IOptions<JwtIssuerOptions>> mock_Options = new Mock<IOptions<JwtIssuerOptions>>();
            mock_Options.Setup(it => it.Value).Returns(testOptions);
            mock_UserAppService.Setup(it => it.AuthorizationOfUser(testUser)).ReturnsAsync(true);
            IAuthorizationService authorizationService = new AuthorizationService(mock_UserAppService.Object, mock_Options.Object);
            var result = await authorizationService.AuthorizationUser(testUser);
            Assert.Equal(RESTStatus.Success, result.Code);
        }

    }
}
