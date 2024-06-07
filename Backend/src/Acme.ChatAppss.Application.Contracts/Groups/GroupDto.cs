using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.ChatApp.Groups
{
    public class GroupDto : AuditedEntityDto<Guid>
    {
        public string GroupName { get; set; }
    }
}
