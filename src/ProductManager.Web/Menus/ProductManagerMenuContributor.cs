using System.Threading.Tasks;
using ProductManager.Localization;
using ProductManager.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace ProductManager.Web.Menus;

public class ProductManagerMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var localizer = context.GetLocalizer<ProductManagerResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                ProductManagerMenus.Home,
                localizer["Menu:Home"],
                "~/",
                icon: "mdi mdi-home",
                order: 0
            )
        );

        context.Menu.AddItem(
            new ApplicationMenuItem("ProductManager", localizer["Menu:Human Resource Management"],icon: "mdi mdi-home").AddItem(new ApplicationMenuItem("Products",localizer["Menu:Profile"],url: "/Products", icon: "mdi mdi-account"))
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
    }
}
