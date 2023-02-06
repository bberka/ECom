﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Models
{
    public class JwtTokenModel
	{
        public string Token { get; set; } = null!;
        public long ExpireUnix { get; set; }
    }
}
