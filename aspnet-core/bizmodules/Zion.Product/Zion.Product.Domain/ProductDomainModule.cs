using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Zion.Product;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ProductDomainSharedModule)
)]
public class ProductDomainModule : AbpModule
{

}
