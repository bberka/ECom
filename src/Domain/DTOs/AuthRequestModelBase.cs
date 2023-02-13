using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.DTOs
{
    /// <summary>
    /// Base class for Api Requests with Authorization and Authentication
    /// </summary>
    public abstract class AuthRequestModelBase
    {
        /// <summary>
        /// UserId received from current HttpContext.
        /// If User is not authenticated value will be -1
        /// <br/>
        /// <br/>
        /// This property is ignored in serialization.
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        [JsonIgnore]
        [IgnoreDataMember]
        public int AuthenticatedUserId
        {
            get
            {
                var context = new HttpContextAccessor().HttpContext;
                if (context is not null)
                {
                    if (context.IsUserAuthenticated())
                    {
                        return context.GetUserId();
                    }
                }
                return -1;
            }

        }
        /// <summary>
        /// AdminId received from current HttpContext.
        /// If Admin is not authenticated value will be -1
        /// <br/>
        /// <br/>
        /// This property is ignored in serialization.
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        [JsonIgnore]
        [IgnoreDataMember]
        public int AuthenticatedAdminId
        {
            get
            {
                var context = new HttpContextAccessor().HttpContext;
                if (context is not null)
                {
                    if (context.IsAdminAuthenticated())
                    {
                        return context.GetAdminId();
                    }
                }
                return -1;
            }

        }
    }
}
