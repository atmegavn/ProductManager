using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace ProductManager.Web;

[Dependency(ReplaceServices = true)]
public class ProductManagerBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "HDVietnam - HRM";
}
