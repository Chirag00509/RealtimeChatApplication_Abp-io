using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Acme.ChatAppss.Data;

/* This is used if database provider does't define
 * IChatAppssDbSchemaMigrator implementation.
 */
public class NullChatAppssDbSchemaMigrator : IChatAppssDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
