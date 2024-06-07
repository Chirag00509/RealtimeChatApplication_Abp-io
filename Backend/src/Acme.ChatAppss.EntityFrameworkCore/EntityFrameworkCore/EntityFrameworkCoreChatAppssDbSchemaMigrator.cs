using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Acme.ChatAppss.Data;
using Volo.Abp.DependencyInjection;

namespace Acme.ChatAppss.EntityFrameworkCore;

public class EntityFrameworkCoreChatAppssDbSchemaMigrator
    : IChatAppssDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreChatAppssDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the ChatAppssDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ChatAppssDbContext>()
            .Database
            .MigrateAsync();
    }
}
