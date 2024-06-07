using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Acme.ChatApp.Groups
{
    public class GroupUser : AuditedAggregateRoot<Guid>
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public  Guid UserId { get; set; }
        public IdentityUser User { get; set; }

    }
}
