using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SmtpOption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public bool IsValid { get; set; }

        [Required]
        [MaxLength(128)]
        public string Host { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(255)]
        [Required]
        public string Sifre { get; set; }

        [Required]
        public bool Ssl { get; set; }

        [Required]
        [Range(0,65535)]
        public int Port { get; set; } 
    }
}
