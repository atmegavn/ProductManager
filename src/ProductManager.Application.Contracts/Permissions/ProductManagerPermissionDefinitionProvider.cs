using ProductManager.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ProductManager.Permissions;

public class ProductManagerPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ProductManagerPermissions.GroupName);
        //Define your own permissions here. Example:
        myGroup.AddPermission(ProductManagerPermissions.MyPermission1, L("Permission:Index"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ProductManagerResource>(name);
    }
}
