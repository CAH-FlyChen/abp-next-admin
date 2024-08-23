using Zion.Sales.Localization;
using Volo.Abp.Application.Services;

namespace Zion.Sales;

public abstract class SalesAppService : ApplicationService
{
    protected SalesAppService()
    {
        LocalizationResource = typeof(SalesResource);
        ObjectMapperContext = typeof(SalesApplicationModule);
    }
}
