using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Zion.Sales;

[DependsOn(
    typeof(SalesApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class SalesHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(SalesApplicationContractsModule).Assembly,
            SalesRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SalesHttpApiClientModule>();
        });

    }
}
