using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Acme.ChatApp.Messages
{
    public interface IUserConnectionService
    {
        Task<string> GetConnectionIdAsync(string userId);
        Task AddConnectionAsync(string userId, string connectionId);
    }
}
