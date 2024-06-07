using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Acme.ChatAppss;

[Dependency(ReplaceServices = true)]
public class ChatAppssBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ChatAppss";
}
