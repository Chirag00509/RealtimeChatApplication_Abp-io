using Acme.ChatAppss.EntityFrameworkCore;
using Acme.ChatAppss.Messages;
using Microsoft.AspNetCore.Authorization;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Users;

namespace Acme.ChatApp.Messages
{
    public class MessageCustomService : ApplicationService
    {
        private readonly ICurrentUser _currentUser;

        private readonly ChatAppssDbContext _context;

        public MessageCustomService(ICurrentUser currentUser, ChatAppssDbContext context)
        {
            _currentUser = currentUser;
            _context = context;
        }

        public async Task<MessageDto> PostMessage(RequrstMessageDto message)
        {
            if (message == null)
            {
                return null;
            }
            //Guid senderId = new Guid(_currentUser.Id.ToString());

            Guid senderId = _currentUser.GetId();

            var messageEntity = new Message
            {
                Id = Guid.NewGuid(),
                SenderId = senderId,
                ReceiverId = message.ReceiverId,
                content = message.Content,
                GroupId = message.GroupId,
                Timestemp = DateTime.Now,
                CreationTime = DateTime.Now,
            };

            _context.Messages.Add(messageEntity);

            await _context.SaveChangesAsync();

            var messages = ObjectMapper.Map<Message, MessageDto>(messageEntity);

            return messages;
        }


        public async Task<ListResultDto<MessageDto>> GetMessages(Guid receiverId, DateTime before, int count)
        {
            var currentUserId = _currentUser.GetId();

            var messages = _context.Messages
              .Where(u => (u.SenderId == currentUserId && u.ReceiverId == receiverId && u.GroupId == null) ||
                          (u.SenderId == receiverId && u.ReceiverId == currentUserId && u.GroupId == null))
             //&&
             //(u.Timestemp >= before))
             //.OrderBy(u => u.Timestemp)
             //.Take(count)
             .Select(u => new MessageDto
             {
                 Id = u.Id,
                 SenderId = u.SenderId,
                 ReceiverId = u.ReceiverId,
                 Content = u.content,
                 GroupId = u.GroupId

             }).ToList();

            return new ListResultDto<MessageDto>(messages);
        }

        public async Task<List<MessageDto>> GetMessagesByGroupId(Guid GroupId)
        {
            var messages = _context.Messages.Where(u => u.GroupId == GroupId)
                .OrderBy(u => u.Timestemp)
                .ToList();

            var message = ObjectMapper.Map<List<Message>, List<MessageDto>>(messages);

            return message;
        }

        public async Task<ListResultDto<MessageDto>> SearchResult(string result)
        {
            var messages = _context.Messages.Where(u => u.content.Contains(result))
                 .Select(u => new MessageDto
                 {
                     Id = u.Id,
                     SenderId = u.SenderId,
                     ReceiverId = u.ReceiverId,
                     Content = u.content,
                 }).ToList();

            return new ListResultDto<MessageDto>(messages);

        }
    }
}
