using Volo.Abp.Reflection;

namespace HD.ProfileManager.Permissions;

public class ProfileManagerPermissions
{
    public const string GroupName = "ProfileManager";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ProfileManagerPermissions));
    }
}
