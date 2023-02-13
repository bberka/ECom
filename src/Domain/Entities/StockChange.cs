using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    public class StockChange : IEfEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime RegisterDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 0: Decrease
        /// 1: Add
        /// </summary>
        public bool Type { get; set; }
        public int Count { get; set; }
        public int Cost { get; set; }
        public int ProductId { get; set; }
        public int? SupplierId { get; set; }
        public int? OrderId { get; set; }
        public string? Reason { get; set; }

        //virtual
        [IgnoreDataMember, Newtonsoft.Json.JsonIgnore, JsonIgnore]
        public virtual Supplier Supplier { get; set; }
        [IgnoreDataMember, Newtonsoft.Json.JsonIgnore, JsonIgnore]
        public virtual Product Product { get; set; }
        [IgnoreDataMember,Newtonsoft.Json.JsonIgnore,JsonIgnore]
        public virtual User User { get; set; }

    }
}
