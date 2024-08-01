using Zion.Product.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Zion.Product;

public abstract class ProductController : AbpControllerBase
{
    protected ProductController()
    {
        LocalizationResource = typeof(ProductResource);
    }
}
