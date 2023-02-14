﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.DTOs.UserDTOs
{
    public class UserLoginResponse
    {
        public UserDto User { get; set; }
        public JwtToken Token { get; set; }
    }
}