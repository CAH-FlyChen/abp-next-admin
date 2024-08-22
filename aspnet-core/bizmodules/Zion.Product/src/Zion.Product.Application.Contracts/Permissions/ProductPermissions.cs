using Volo.Abp.Reflection;

namespace Zion.Product.Permissions;

public class ProductPermissions
{
    public const string GroupName = "Product";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ProductPermissions));
    }
    public class Category
    {
        public const string Default = GroupName + ".Category";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    /// <summary>
    /// 产品品牌
    /// </summary>
    public class Brand
    {
        public const string Default = GroupName + ".Brand";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}
