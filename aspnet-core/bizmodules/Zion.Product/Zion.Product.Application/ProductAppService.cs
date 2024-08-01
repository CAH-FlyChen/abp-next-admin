using Zion.Product.Localization;
using Volo.Abp.Application.Services;

namespace Zion.Product;

public abstract class ProductAppService : ApplicationService
{
    protected ProductAppService()
    {
        LocalizationResource = typeof(ProductResource);
        ObjectMapperContext = typeof(ProductApplicationModule);
    }
}
