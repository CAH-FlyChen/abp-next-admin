using Zion.Product.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Zion.Product.Permissions;

public class ProductPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ProductPermissions.GroupName, L("Permission:Product"));

        var categoryPermission = myGroup.AddPermission(ProductPermissions.Category.Default, L("Permission:Category"));
        categoryPermission.AddChild(ProductPermissions.Category.Create, L("Permission:Create"));
        categoryPermission.AddChild(ProductPermissions.Category.Update, L("Permission:Update"));
        categoryPermission.AddChild(ProductPermissions.Category.Delete, L("Permission:Delete"));

        var brandPermission = myGroup.AddPermission(ProductPermissions.Brand.Default, L("Permission:Brand"));
        brandPermission.AddChild(ProductPermissions.Brand.Create, L("Permission:Create"));
        brandPermission.AddChild(ProductPermissions.Brand.Update, L("Permission:Update"));
        brandPermission.AddChild(ProductPermissions.Brand.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ProductResource>(name);
    }
}
