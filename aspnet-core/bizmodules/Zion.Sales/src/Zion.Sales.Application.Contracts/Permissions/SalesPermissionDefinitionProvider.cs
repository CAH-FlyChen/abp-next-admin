using Zion.Sales.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Zion.Sales.Permissions;

public class SalesPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SalesPermissions.GroupName, L("Permission:Sales"));

        var shoppingCartPermission = myGroup.AddPermission(SalesPermissions.ShoppingCart.Default, L("Permission:ShoppingCart"));
        shoppingCartPermission.AddChild(SalesPermissions.ShoppingCart.Create, L("Permission:Create"));
        shoppingCartPermission.AddChild(SalesPermissions.ShoppingCart.Update, L("Permission:Update"));
        shoppingCartPermission.AddChild(SalesPermissions.ShoppingCart.Delete, L("Permission:Delete"));

        var shoppingCartItemPermission = myGroup.AddPermission(SalesPermissions.ShoppingCartItem.Default, L("Permission:ShoppingCartItem"));
        shoppingCartItemPermission.AddChild(SalesPermissions.ShoppingCartItem.Create, L("Permission:Create"));
        shoppingCartItemPermission.AddChild(SalesPermissions.ShoppingCartItem.Update, L("Permission:Update"));
        shoppingCartItemPermission.AddChild(SalesPermissions.ShoppingCartItem.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SalesResource>(name);
    }
}
