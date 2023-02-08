namespace ECom.Domain.Entities
{
    public class ProductComment : IEfEntity
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        
        public DateTime RegisterDate { get; set; }
        
        
        [MaxLength(64)]
        public string Title { get; set; }
        
        [MaxLength(1000)]
        public string Description { get; set; }


        [ForeignKey("AuthorUserId")]
        public int AuthorUserId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual User AuthorUser { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Product? Product { get; set; }

        public virtual List<ProductCommentImage> Images { get; set; }
        public virtual List<ProductCommentStar> Stars { get; set; }

        public virtual double StarScore => Stars.Average(x => x.Star);

    }
}
