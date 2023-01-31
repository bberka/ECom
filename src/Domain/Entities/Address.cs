using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECom.Domain.Entities 
{
    public class Address : IEntity
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime RegisterDate { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }
        
        [MaxLength(64)]
        public string Surname { get; set; }
        
        [MaxLength(64)]
        public string Title { get; set; }
        
        [MaxLength(64)]
        public string Town { get; set; }
        
        [MaxLength(32)]
        public string Country { get; set; }
        public string Provience { get; set; }
        
        [MaxLength(64)]
        public string Details { get; set; }

        [MaxLength(64)]
        public string PhoneNumber { get; set; }
        public bool IsPreferred { get; set; }

        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public virtual User? User { get; set; }

    }
}
