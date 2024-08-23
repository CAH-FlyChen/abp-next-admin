using Zion.Product.ProductContext;
using Zion.Product;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Zion.Product.ProductContext.EntityFrameworkCore;

[DependsOn(
    typeof(ProductDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class ProductEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<ProductDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
            options.AddRepository<Category, CategoryRepository>();
            options.AddRepository<Brand, BrandRepository>();
            options.AddRepository<Unit, UnitRepository>();
            options.AddRepository<Product, ProductRepository>();
        });
    }
}
