using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Exceptions
{
    public class TooLongException : CustomException
    {
        public TooLongException(string propertyName,int maxLimit) : base($"{propertyName}:{maxLimit}")
        {

        }
    }
}
