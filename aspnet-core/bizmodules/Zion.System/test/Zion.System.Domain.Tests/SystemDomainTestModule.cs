using Volo.Abp.Modularity;

namespace Zion.System;

[DependsOn(
    typeof(SystemDomainModule),
    typeof(SystemTestBaseModule)
)]
public class SystemDomainTestModule : AbpModule
{

}
