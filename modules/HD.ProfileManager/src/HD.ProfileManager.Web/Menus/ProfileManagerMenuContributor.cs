using HD.ProfileManager.Localization;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace HD.ProfileManager.Web.Menus;

public class ProfileManagerMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var localizer = context.GetLocalizer<ProfileManagerResource>();
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(ProfileManagerMenus.Prefix, localizer["Human Resource Management"], icon: "mdi mdi-home")
            .AddItem(new ApplicationMenuItem(ProfileManagerMenus.Prefix, localizer["Employees"], url: "/Employees", icon: "mdi mdi-account"))
            .AddItem(new ApplicationMenuItem(ProfileManagerMenus.Prefix, localizer["Profiles"], url: "/Profiles", icon: "mdi mdi-file-account"))
            .AddItem(new ApplicationMenuItem(ProfileManagerMenus.Prefix, localizer["Organizations"], url: "/Organizations", icon: "mdi mdi-office-building"))
        );
        return Task.CompletedTask;
    }
}
