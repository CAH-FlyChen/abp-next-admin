using Localization.Resources.AbpUi;
using Zion.System.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Zion.System;

[DependsOn(
    typeof(SystemApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class SystemHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(SystemHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<SystemResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
