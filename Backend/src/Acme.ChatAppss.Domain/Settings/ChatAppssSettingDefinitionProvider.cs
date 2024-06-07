using Volo.Abp.Settings;

namespace Acme.ChatAppss.Settings;

public class ChatAppssSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ChatAppssSettings.MySetting1));
    }
}
