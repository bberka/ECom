using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime RegisterDate { get; set; }

        [MaxLength(32)]
        public string Name { get; set; }

        [MaxLength(128)]
        public string Description { get; set; }

        [MaxLength(64)]
        public string CompanyName { get; set; }

        [MaxLength(16)]
        public string PhoneNumber { get; set; }

        [MaxLength(64)]
        public string EmailAddress { get; set; }
    }
}
