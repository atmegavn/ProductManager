using HD.ProfileManager.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace HD.ProfileManager.Permissions;

public class ProfileManagerPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ProfileManagerPermissions.GroupName, L("Permission:ProfileManager"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ProfileManagerResource>(name);
    }
}
