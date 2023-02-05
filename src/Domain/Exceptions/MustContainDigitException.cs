using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Exceptions
{
    public class MustContainDigitException : CustomException
    {
        public MustContainDigitException(string propertyName) : base(propertyName)
        {

        }
    }
}
