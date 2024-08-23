using Volo.Abp.Modularity;

namespace Zion.Sales;

[DependsOn(
    typeof(SalesDomainModule),
    typeof(SalesTestBaseModule)
)]
public class SalesDomainTestModule : AbpModule
{

}
