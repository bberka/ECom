using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.DTOs
{
    public class JwtToken
    {
        public string Token { get; set; } = null!;
        public long ExpireUnix { get; set; }
    }
}
