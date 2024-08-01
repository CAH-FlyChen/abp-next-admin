using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Zion.System;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(SystemDomainSharedModule)
)]
public class SystemDomainModule : AbpModule
{

}
