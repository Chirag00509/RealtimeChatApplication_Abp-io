using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.ChatApp.Groups
{
    public class CreateUpdateGroupUser
    {
        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }

    }
}
