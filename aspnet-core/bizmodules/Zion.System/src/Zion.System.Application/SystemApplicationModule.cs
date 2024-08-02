using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using LINGYUN.Abp.UI.Navigation;

namespace Zion.System;
[DependsOn(
    typeof(AbpUINavigationModule),//用于生成菜单
    typeof(SystemDomainModule),
    typeof(SystemApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class SystemApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        GloableGuidGenerator.InitMySQLGUID();

        context.Services.AddAutoMapperObjectMapper<SystemApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<SystemApplicationModule>(validate: true);
        });
    }
}
