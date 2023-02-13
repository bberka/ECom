using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.DTOs.Response
{
    public class AdminDto
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public byte TwoFactorType { get; set; } = 0;
        public string RoleName { get; set; }
        public string Permissions { get; set; }

    }
}
