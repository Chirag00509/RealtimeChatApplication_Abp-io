using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.ChatAppss.Messages
{
    public class RequrstMessageDto
    {
        public string Content { get; set; }
        public Guid? ReceiverId { get; set; }
        public Guid? GroupId { get; set; }
    }
}
