using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.DTOs.Response
{
    public class AdminLoginResponse
    {
        public AdminDto Admin { get; set; }
        public JwtToken Token { get; set; }
    }
}
