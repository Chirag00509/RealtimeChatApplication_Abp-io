using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.ChatApp.Messages
{
    public class MessageDto : AuditedEntityDto<Guid>
    {
        public Guid Id {  get; set; }
        public Guid SenderId { get; set; }
        public Guid? ReceiverId { get; set; }
        public Guid? GroupId { get; set; }
        public string Content { get; set; }
    }
}
