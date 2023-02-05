using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Exceptions
{
    public class NullException : CustomException
    {
        public NullException(string name) : base(name)
        {

        }
    }
}
