using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.Interfaces
{
    public interface ILocalization
    {
        public string Get(string key);
    }
}
