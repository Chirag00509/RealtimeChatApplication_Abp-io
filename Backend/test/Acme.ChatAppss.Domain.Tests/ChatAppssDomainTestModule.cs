using Acme.ChatAppss.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Acme.ChatAppss;

[DependsOn(
    typeof(ChatAppssEntityFrameworkCoreTestModule)
    )]
public class ChatAppssDomainTestModule : AbpModule
{

}
