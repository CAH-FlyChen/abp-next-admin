using Zion.Sales.SalesContext;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Zion.Sales.EntityFrameworkCore;

[DependsOn(
    typeof(SalesDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class SalesEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<SalesDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
            options.AddRepository<ShoppingCart, ShoppingCartRepository>();
            options.AddRepository<ShoppingCartItem, ShoppingCartItemRepository>();
        });
    }
}
