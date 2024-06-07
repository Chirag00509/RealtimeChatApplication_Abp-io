using Acme.ChatApp.Groups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Acme.ChatApp.Messages
{
    public class Message : AuditedAggregateRoot<Guid>
    {
        public Guid Id { get; set; }    
        public Guid SenderId { get; set; }
        public Guid? ReceiverId { get; set; }
        public Guid? GroupId { get; set; }
        public string content { get; set; }
        public Group? Group { get; set; }
        public IdentityUser Sender { get; set; }
        public IdentityUser? Receiver { get; set; }
        public DateTime Timestemp { get; set; }
    }
}
