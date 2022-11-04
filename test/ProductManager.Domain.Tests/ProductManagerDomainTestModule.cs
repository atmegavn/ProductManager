using ProductManager.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ProductManager;

[DependsOn(
    typeof(ProductManagerEntityFrameworkCoreTestModule)
    )]
public class ProductManagerDomainTestModule : AbpModule
{

}
