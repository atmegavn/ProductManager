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
        context.Menu.AddItem(new ApplicationMenuItem(ProfileManagerMenus.Prefix, displayName: localizer["Profile Manager"], "~/ProfileManager", icon: "mdi mdi-file-account"));

        return Task.CompletedTask;
    }
}
