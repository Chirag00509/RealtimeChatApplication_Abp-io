using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.ChatApp.Loggs
{
    public class Logg
    {
        public Guid Id { get; set; }
        public string Ip { get; set; }
        public string? Username { get; set; }
        public string? RequestBody { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
