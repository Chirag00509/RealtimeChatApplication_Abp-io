using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.ChatApp.Messages
{
    public class CreateUpdateDto
    {
        public string? SenderId { get; set; }
        public string? ReceiverId { get; set; }
        public string? GroupId { get; set; }
        public string content { get; set; }
        public DateTime Timestemp { get; set; }
    }
}
