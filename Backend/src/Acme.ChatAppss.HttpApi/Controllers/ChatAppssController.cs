using Acme.ChatAppss.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.ChatAppss.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ChatAppssController : AbpControllerBase
{
    protected ChatAppssController()
    {
        LocalizationResource = typeof(ChatAppssResource);
    }
}
