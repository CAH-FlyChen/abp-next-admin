using Volo.Abp.Modularity;

namespace Zion.Product;

[DependsOn(
    typeof(ProductDomainModule),
    typeof(ProductTestBaseModule)
)]
public class ProductDomainTestModule : AbpModule
{

}
