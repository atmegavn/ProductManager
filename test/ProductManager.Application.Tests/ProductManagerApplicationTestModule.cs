using Volo.Abp.Modularity;

namespace ProductManager;

[DependsOn(
    typeof(ProductManagerApplicationModule),
    typeof(ProductManagerDomainTestModule)
    )]
public class ProductManagerApplicationTestModule : AbpModule
{

}
