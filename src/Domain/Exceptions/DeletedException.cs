using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Exceptions
{
    public class DeletedException : CustomException
    {
        public DeletedException(string entityName) : base(entityName)
        {

        }
    }
}
