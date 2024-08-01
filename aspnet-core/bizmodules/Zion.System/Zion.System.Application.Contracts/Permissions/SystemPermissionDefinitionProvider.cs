using Zion.System.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Zion.System.Permissions;

public class SystemPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SystemPermissions.GroupName, L("Permission:System"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SystemResource>(name);
    }
}
