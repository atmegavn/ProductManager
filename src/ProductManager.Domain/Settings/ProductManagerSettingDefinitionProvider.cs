using Volo.Abp.Settings;

namespace ProductManager.Settings;

public class ProductManagerSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ProductManagerSettings.MySetting1));
    }
}
