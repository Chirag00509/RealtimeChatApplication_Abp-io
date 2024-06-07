using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.ChatApp.Groups
{
    public interface IGroupUserAppService : ICrudAppService<
        GroupUserDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateGroupUser>
    {
    }
}
