using Zion.Product.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Zion.Product.ProductContext.Dtos;

namespace Zion.Product;

public abstract class ProductBaseController : AbpControllerBase
{
    protected ProductBaseController()
    {
        LocalizationResource = typeof(ProductResource);
    }
}
