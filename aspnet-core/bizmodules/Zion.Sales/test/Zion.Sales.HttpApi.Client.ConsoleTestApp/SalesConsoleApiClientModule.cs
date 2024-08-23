using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Zion.Sales;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SalesHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class SalesConsoleApiClientModule : AbpModule
{

}
