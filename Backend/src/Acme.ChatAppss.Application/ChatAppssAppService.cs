using System;
using System.Collections.Generic;
using System.Text;
using Acme.ChatAppss.Localization;
using Volo.Abp.Application.Services;

namespace Acme.ChatAppss;

/* Inherit your application services from this class.
 */
public abstract class ChatAppssAppService : ApplicationService
{
    protected ChatAppssAppService()
    {
        LocalizationResource = typeof(ChatAppssResource);
    }
}
