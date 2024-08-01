using Volo.Abp.Reflection;

namespace Zion.System.Permissions;

public class SystemPermissions
{
    public const string GroupName = "System";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(SystemPermissions));
    }
}
