using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Zion.System;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class SystemInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SystemInstallerModule>();
        });
    }
}
