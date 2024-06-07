using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Acme.ChatApp.Users
{
    public interface IUserAppService
    {
        Task<IEnumerable<UserProfile>> GetDetails();
    }
}
