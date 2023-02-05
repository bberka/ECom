using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.ApiModels
{
    public abstract class AuthApiRequestModelBase
    {
        [JsonIgnore]
        public int AuthenticatedUserId
        {
            get
            {
                var context = new HttpContextAccessor().HttpContext;
                if (context is not null)
                {
                    if (context.IsUserAuthorized())
                    {
                        return context.GetUser().Id;
                    }
                }
                return -1;
            }

        }
    }
}
