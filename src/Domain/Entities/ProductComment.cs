using System.Runtime.Serialization;

namespace ECom.Domain.Entities
{
    public class ProductComment : IEfEntity
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;

        [MaxLength(1000)]
        [MinLength(8)]
        public string Comment { get; set; }

        public byte Star { get; set; }
        //FK
        public int UserId { get; set; }
        public int ProductId { get; set; }



        //Virtual
        public virtual List<ProductCommentImage> ProductCommentImages { get; set; }
        

        ////Ignore
        //[IgnoreDataMember]
        //public virtual User User { get; set; }
        //[IgnoreDataMember]
        //public virtual Product Product { get; set; }
    }
}
