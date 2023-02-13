using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ECom.Domain.Entities
{
    [PrimaryKey(nameof(UserId),nameof(ProductId))]
    public class Cart : IEfEntity
	{
        public DateTime RegisterDate { get; set; } = DateTime.MaxValue;
        public DateTime LastUpdateDate { get; set; }
        public int Count { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }



        //Virtual
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }


    }
}
