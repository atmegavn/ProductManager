using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace HD.ProfileManager.Web
{
    [Dependency(ReplaceServices = true)]
    public class ProfileManagerBrandingProvider: DefaultBrandingProvider
    {
        public override string AppName => "Human Resource Management";
    }
}
