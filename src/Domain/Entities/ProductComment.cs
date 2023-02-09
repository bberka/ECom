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

        //FK
        public int UserId { get; set; }
        public int ProductId { get; set; }



        //Virtual
        public virtual List<ProductCommentImage> ProductCommentImages { get; set; }
        public virtual List<ProductCommentStar> ProductCommentStars { get; set; }

        [NotMapped]
        public virtual double StarScore => ProductCommentStars.Average(x => x.Star);


        //Ignore
        [IgnoreDataMember]
        public virtual User User { get; set; }
        [IgnoreDataMember]
        public virtual Product Product { get; set; }
    }
}
