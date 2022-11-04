using ProductManager.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ProductManager.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ProductManagerEntityFrameworkCoreModule),
    typeof(ProductManagerApplicationContractsModule)
    )]
public class ProductManagerDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
