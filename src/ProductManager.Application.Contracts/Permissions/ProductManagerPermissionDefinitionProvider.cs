using ProductManager.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ProductManager.Permissions;

public class ProductManagerPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ProductManagerPermissions.GroupName);
        //Define your own permissions here. Example:s
        myGroup.AddPermission(ProductManagerPermissions.List, L("Permission:Index"));
        myGroup.AddPermission(ProductManagerPermissions.Create, L("Permission:Create"));
        myGroup.AddPermission(ProductManagerPermissions.Edit, L("Permission:Edit"));
        myGroup.AddPermission(ProductManagerPermissions.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ProductManagerResource>(name);
    }
}
