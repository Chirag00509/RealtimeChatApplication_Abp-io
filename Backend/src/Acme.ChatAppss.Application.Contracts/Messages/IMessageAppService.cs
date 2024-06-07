using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.ChatApp.Messages
{
    public interface IMessageAppService :
        ICrudAppService<
            MessageDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateDto>
    {
    }
}
