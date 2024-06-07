using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.ChatApp.Groups
{
    public class GroupUserAppServicecs : CrudAppService<
        GroupUser,
        GroupUserDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateGroupUser>, IGroupUserAppService
    {
        public GroupUserAppServicecs(IRepository<GroupUser, Guid> repository) : base(repository)
        {
        }
    }
}
