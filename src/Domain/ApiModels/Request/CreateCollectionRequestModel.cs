using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.ApiModels.Request
{
    public class CreateCollectionRequestModel : AuthApiRequestModelBase
    {
        [MinLength(3)]
        public string Name { get; set; }
    }
}
