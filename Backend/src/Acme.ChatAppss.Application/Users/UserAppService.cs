using Microsoft.AspNetCore.Identity;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace Acme.ChatApp.Users
{
    public class UserAppService : ApplicationService
    {
        private readonly IIdentityUserAppService _userAppService;
        private readonly ICurrentUser _currentUser;

        public UserAppService(IIdentityUserAppService userAppService, ICurrentUser currentUser)
        {
            _userAppService = userAppService;
            _currentUser = currentUser;
        }

        public async Task<ListResultDto<UserProfile>> GetDetails()
        {
            var currentUserIdentifier = _currentUser.GetId();

            var users = await _userAppService.GetListAsync(new GetIdentityUsersInput());

            var filteredUsers = users.Items.Where(u => u.Id != currentUserIdentifier)
                 .Select(u => new UserProfile
                 {
                     Id = u.Id,
                     Name = u.UserName,
                     Email = u.Email
                 })
                .ToList();

            return new ListResultDto<UserProfile>(filteredUsers);
        }
    }
}
