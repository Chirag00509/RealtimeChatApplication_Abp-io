using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.ChatApp.Messages
{
    public class MessageAppService :
        CrudAppService<
            Message,
            MessageDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateDto>, IMessageAppService
    {
        public MessageAppService(IRepository<Message, Guid> repository)
        : base(repository)
        {

        }
    }
}
