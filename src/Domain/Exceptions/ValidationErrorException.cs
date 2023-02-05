using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Exceptions
{
    public class ValidationErrorException : CustomException
    {
        public ValidationErrorException(string propertyname, string message) : base($"{propertyname}:{message}")
        {

        }
    }
}
