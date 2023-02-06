using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    public class ImageLanguage : IEfEntity
    {
        [ForeignKey("ImageId")]
        public int ImageId { get; set; }
        public virtual Image Image { get; set; }


        [ForeignKey("Culture")]
        public string Culture { get; set; }
        public virtual Language Language { get; set; }
    }
}
