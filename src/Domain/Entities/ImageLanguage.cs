
namespace ECom.Domain.Entities
{
    public class ImageLanguage : IEfEntity
    {
        [ForeignKey("ImageId")]
        public int ImageId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public virtual Image Image { get; set; }


        [ForeignKey("Culture")]
        public string Culture { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public virtual Language Language { get; set; }
    }
}
