using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Exceptions
{
    public class NotValidException : CustomException
    {
        public NotValidException(string entityName) : base(entityName)
        {

        }
    }

}
