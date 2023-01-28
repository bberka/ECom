using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }
        [Required]
        public int LogType { get; set; }
        [Required]
        public int OperationType { get; set; }
        [Required]
        public int OperationMemo { get; set; }
        [MaxLength(32)]
        [Required]
        public string IpAddress { get; set; }
        public long? UserNo { get; set; }
        [MaxLength(2000)]
        [Required]
        public string Params { get; set; }

    }
}
