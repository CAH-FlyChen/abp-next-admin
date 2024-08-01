using Volo.Abp.Reflection;

namespace Zion.System.Permissions;

public class SystemPermissions
{
    public const string GroupName = "System";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(SystemPermissions));
    }
    public class Company
    {
        public const string Default = GroupName + ".Company";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}
