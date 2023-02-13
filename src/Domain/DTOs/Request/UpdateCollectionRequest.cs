using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.DTOs.Request
{
    public class UpdateCollectionRequest : AuthRequestModelBase
    {
        public int CollectionId { get; set; }
        public string CollectionName { get; set; }
    }
}
