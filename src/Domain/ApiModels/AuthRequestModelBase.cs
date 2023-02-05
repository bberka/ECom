using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.ApiModels
{
    public abstract class AuthRequestModelBase
    {
        [JsonIgnore]
        public int AuthenticatedUserId
        {
            get
            {
                var context = new HttpContextAccessor().HttpContext;
                if (context is not null)
                {
                    if (context.IsUserAuthenticated())
                    {
                        return context.GetUser().Id;
                    }
                }
                return -1;
            }

        }

        [JsonIgnore]
        public int AuthenticatedAdminId
        {
            get
            {
                var context = new HttpContextAccessor().HttpContext;
                if (context is not null)
                {
                    if (context.IsAdminAuthenticated())
                    {
                        return context.GetAdmin().Id;
                    }
                }
                return -1;
            }

        }
    }
}
