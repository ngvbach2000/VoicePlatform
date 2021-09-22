using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoicePlatform.Data.Application
{
    public class Authenticate
    {
        public Guid Id {  get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
    }
}
