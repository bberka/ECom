using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    public class SecurityLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTime RegisterDate { get; set; }

        public int HttpStatusCodeResponse { get; set; }

        public string RequestUrl { get; set; }
        public string QueryString { get; set; }

        [MaxLength(32)]
        public string RemoteIpAddress { get; set; }

        [MaxLength(32)]
        public string? XReal_IpAddress { get; set; }

        [MaxLength(32)]
        public string? CFConnecting_IpAddress { get; set; }

        [MaxLength(512)]
        public string? UserAgent { get; set; }

        [MaxLength(2000)]
        public string? Params { get; set; }





    }
}
