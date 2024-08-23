using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Zion.Sales;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class SalesInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SalesInstallerModule>();
        });
    }
}
