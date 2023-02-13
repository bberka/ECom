using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.DTOs.Request
{
    public class AddCollectionRequest : AuthRequestModelBase
    {
        [MinLength(3)]
        public string Name { get; set; }
    }
}
