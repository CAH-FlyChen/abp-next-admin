using Zion.Sales.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Zion.Sales;

public abstract class SalesController : AbpControllerBase
{
    protected SalesController()
    {
        LocalizationResource = typeof(SalesResource);
    }
}
