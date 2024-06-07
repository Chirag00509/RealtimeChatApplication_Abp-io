using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.ChatApp.Groups
{
    public class Group : AuditedAggregateRoot<Guid>
    {
        public Guid Id { get; set; }
        public string GroupName { get; set; }
    }
}
