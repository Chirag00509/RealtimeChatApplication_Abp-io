using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.ChatApp.Loggs
{
    public class LoggDto
    {
        public string Id { get; set; }
        public string Ip { get; set; }

        public string Username { get; set; }

        public string RequestBody { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
