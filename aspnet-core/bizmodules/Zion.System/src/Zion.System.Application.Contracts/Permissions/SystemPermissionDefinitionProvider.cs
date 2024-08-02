using Zion.System.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Zion.System.Permissions;

public class SystemPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SystemPermissions.GroupName, L("Permission:System"));

        var companyPermission = myGroup.AddPermission(SystemPermissions.Company.Default, L("Permission:Company"));
        companyPermission.AddChild(SystemPermissions.Company.Create, L("Permission:Create"));
        companyPermission.AddChild(SystemPermissions.Company.Update, L("Permission:Update"));
        companyPermission.AddChild(SystemPermissions.Company.Delete, L("Permission:Delete"));

        var regionPermission = myGroup.AddPermission(SystemPermissions.Region.Default, L("Permission:Region"));
        regionPermission.AddChild(SystemPermissions.Region.Create, L("Permission:Create"));
        regionPermission.AddChild(SystemPermissions.Region.Update, L("Permission:Update"));
        regionPermission.AddChild(SystemPermissions.Region.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SystemResource>(name);
    }
}
