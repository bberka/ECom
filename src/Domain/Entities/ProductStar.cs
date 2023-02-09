using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    public class ProductStar : IEfEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int ProductId { get; set; }

        public byte Star { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;


        //virtual
        [IgnoreDataMember]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public User User { get; set; }

        [IgnoreDataMember]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Product Product { get; set; }
        
    }
}
