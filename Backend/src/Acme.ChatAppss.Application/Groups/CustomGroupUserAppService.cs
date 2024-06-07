using Acme.ChatAppss.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.ChatApp.Groups
{
    public class CustomGroupUserAppService : ApplicationService
    {
        private readonly ChatAppssDbContext _context;
        public CustomGroupUserAppService(ChatAppssDbContext context) 
        {
            _context = context;
        }

        public async Task<ListResultDto<GroupUserDto>> GetUser(string GroupId)
        {
            var user = _context.GroupUsers.Where(u => u.GroupId.ToString() == GroupId);

            var users = user
                .Select(u => new GroupUserDto
                {
                    Id = u.Id,
                    GroupId = u.GroupId,
                    UserId = u.UserId

                }).ToList();

            return new ListResultDto<GroupUserDto>(users);
        }

    }
}
