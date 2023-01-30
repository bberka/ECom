﻿using Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class BaseException : Exception

    {
        public BaseException(string message) : base(message)
        { 

        }
        public BaseException(Response resp) : base(resp.ToString())
        {

        }

    }
}
