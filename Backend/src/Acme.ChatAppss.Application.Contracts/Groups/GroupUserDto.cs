using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.ChatApp.Groups
{
    public class GroupUserDto : AuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }

    }
}
