using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Exceptions
{
    public class NotFoundException : CustomException
    {
        public NotFoundException(string entityName) : base(entityName)
        {

        }
    }
}
