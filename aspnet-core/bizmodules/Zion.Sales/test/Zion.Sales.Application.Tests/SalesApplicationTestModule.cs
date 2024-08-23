using Volo.Abp.Modularity;

namespace Zion.Sales;

[DependsOn(
    typeof(SalesApplicationModule),
    typeof(SalesDomainTestModule)
    )]
public class SalesApplicationTestModule : AbpModule
{

}
