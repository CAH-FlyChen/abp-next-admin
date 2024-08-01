using Zion.System.Localization;
using Volo.Abp.Application.Services;

namespace Zion.System;

public abstract class SystemAppService : ApplicationService
{
    protected SystemAppService()
    {
        LocalizationResource = typeof(SystemResource);
        ObjectMapperContext = typeof(SystemApplicationModule);
    }
}
