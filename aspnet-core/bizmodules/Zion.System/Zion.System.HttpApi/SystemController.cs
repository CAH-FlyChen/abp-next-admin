using Zion.System.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Zion.System;

public abstract class SystemController : AbpControllerBase
{
    protected SystemController()
    {
        LocalizationResource = typeof(SystemResource);
    }
}
