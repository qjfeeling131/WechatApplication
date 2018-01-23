using Abp.DoNetCore.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Abp.DoNetCore
{
    public static class AbpApplicationBuilderExtensions
    {
       
        public static void UserAbp(this IApplicationBuilder app, IConfigurationRoot configuration)
        {
            app.UseAuthentication();      
        }
        private static void InitializeAbp(IApplicationBuilder app)
        {
            var abpBootstrapper = app.ApplicationServices.GetRequiredService<AbpBootstrapper>();
            abpBootstrapper.Initialize();
        }
    }
}
