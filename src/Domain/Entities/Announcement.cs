﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
    public class Announcement : IEfEntity
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Range(0,int.MaxValue)]
        public int Id { get; set; }
        public int Order { get; set; }

        [MaxLength(128)]
        public string Message { get; set; }

        public DateTime RegisterDate { get; set; }

        public bool IsValid { get; set; }
    }
}
