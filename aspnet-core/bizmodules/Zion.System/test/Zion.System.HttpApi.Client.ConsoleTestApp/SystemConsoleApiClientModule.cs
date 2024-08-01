using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Zion.System;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SystemHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class SystemConsoleApiClientModule : AbpModule
{

}
