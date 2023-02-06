using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    public class Language : IEfEntity
	{
        [Key]
        [MaxLength(6)]
        public string Culture { get; set; }

    }
}
