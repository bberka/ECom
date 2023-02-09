using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    [PrimaryKey(nameof(UserId),nameof(ProductId))]
    public class FavoriteProduct : IEfEntity
	{
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public int ProductId { get; set; }


        //Virtual
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
