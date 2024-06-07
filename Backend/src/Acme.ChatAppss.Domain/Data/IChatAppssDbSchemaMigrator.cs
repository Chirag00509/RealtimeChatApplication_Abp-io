using System.Threading.Tasks;

namespace Acme.ChatAppss.Data;

public interface IChatAppssDbSchemaMigrator
{
    Task MigrateAsync();
}
