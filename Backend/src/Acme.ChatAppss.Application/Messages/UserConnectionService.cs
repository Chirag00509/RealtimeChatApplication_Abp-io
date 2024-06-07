using StackExchange.Redis;
using System;
using System.Threading.Tasks;
using Volo.Abp.Users;

namespace Acme.ChatApp.Messages
{
    public class UserConnectionService : IUserConnectionService
    {
        private readonly IDatabase _redisDb;
        private readonly ICurrentUser _currentUser;

        public UserConnectionService(ConnectionMultiplexer multiplexer, ICurrentUser currentUser)
        {
            _redisDb = multiplexer.GetDatabase();
            _currentUser = currentUser;
        }

        public async Task AddConnectionAsync(string userId, string connectionId)
        {
            await _redisDb.StringSetAsync(userId, connectionId);
        }

        public async Task<string> GetConnectionIdAsync(string userId)
        {
            return await _redisDb.StringGetAsync(userId);
        }
    }
}
