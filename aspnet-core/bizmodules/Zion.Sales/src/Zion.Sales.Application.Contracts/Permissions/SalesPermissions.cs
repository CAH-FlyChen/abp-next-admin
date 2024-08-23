using Volo.Abp.Reflection;

namespace Zion.Sales.Permissions;

public class SalesPermissions
{
    public const string GroupName = "Sales";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(SalesPermissions));
    }
    public class ShoppingCart
    {
        public const string Default = GroupName + ".ShoppingCart";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    public class ShoppingCartItem
    {
        public const string Default = GroupName + ".ShoppingCartItem";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}
