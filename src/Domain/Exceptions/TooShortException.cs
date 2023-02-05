using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Exceptions
{
    public class TooShortException : CustomException
    {
        public TooShortException(string propertyName,int minLimit) : base($"{propertyName}:{minLimit}")
        {

        }
    }
}
