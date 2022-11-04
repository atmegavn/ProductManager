using System.Threading.Tasks;

namespace ProductManager.Data;

public interface IProductManagerDbSchemaMigrator
{
    Task MigrateAsync();
}
