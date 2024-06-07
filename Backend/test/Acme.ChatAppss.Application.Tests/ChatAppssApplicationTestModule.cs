using Volo.Abp.Modularity;

namespace Acme.ChatAppss;

[DependsOn(
    typeof(ChatAppssApplicationModule),
    typeof(ChatAppssDomainTestModule)
    )]
public class ChatAppssApplicationTestModule : AbpModule
{

}
