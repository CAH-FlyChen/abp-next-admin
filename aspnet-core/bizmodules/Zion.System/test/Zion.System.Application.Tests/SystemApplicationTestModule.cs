using Volo.Abp.Modularity;

namespace Zion.System;

[DependsOn(
    typeof(SystemApplicationModule),
    typeof(SystemDomainTestModule)
    )]
public class SystemApplicationTestModule : AbpModule
{

}
