using Acme.ChatAppss.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Acme.ChatAppss.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ChatAppssEntityFrameworkCoreModule),
    typeof(ChatAppssApplicationContractsModule)
    )]
public class ChatAppssDbMigratorModule : AbpModule
{
}
