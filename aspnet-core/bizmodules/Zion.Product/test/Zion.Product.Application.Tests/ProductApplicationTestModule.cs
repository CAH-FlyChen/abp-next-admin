using Volo.Abp.Modularity;

namespace Zion.Product;

[DependsOn(
    typeof(ProductApplicationModule),
    typeof(ProductDomainTestModule)
    )]
public class ProductApplicationTestModule : AbpModule
{

}
