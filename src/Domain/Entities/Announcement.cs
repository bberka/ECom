using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Announcement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Order { get; set; }

        [MaxLength(128)]
        public string Message { get; set; }

        public DateTime RegisterDate { get; set; }

        public bool IsValid { get; set; }
    }
}
