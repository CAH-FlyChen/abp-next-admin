using Zion.Product.Localization;
using Volo.Abp.Application.Services;

namespace Zion.Product;

public abstract class ProductModuleAppService : ApplicationService
{
    protected ProductModuleAppService()
    {
        LocalizationResource = typeof(ProductResource);
        ObjectMapperContext = typeof(ProductApplicationModule);
    }
}
