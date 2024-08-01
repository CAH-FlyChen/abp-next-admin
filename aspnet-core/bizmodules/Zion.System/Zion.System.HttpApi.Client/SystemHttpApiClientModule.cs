using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Zion.System;

[DependsOn(
    typeof(SystemApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class SystemHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(SystemApplicationContractsModule).Assembly,
            SystemRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SystemHttpApiClientModule>();
        });

    }
}
