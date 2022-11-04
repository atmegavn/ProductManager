using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ProductManager.Data;

/* This is used if database provider does't define
 * IProductManagerDbSchemaMigrator implementation.
 */
public class NullProductManagerDbSchemaMigrator : IProductManagerDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
