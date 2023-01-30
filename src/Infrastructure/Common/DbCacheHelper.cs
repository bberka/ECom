using Domain.Constants;
using Domain.Entities;
using Domain.Lib;
using EasMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common
{
    public static class DbCacheHelper
    {
        public static readonly EasCache<Option> Option = new(GetOption, 1);
        private static Option GetOption()
        {
            return EComDbContext.New().Options.FirstOrDefault() ?? throw new Exception("Option table is empty");
        }
    }
}
