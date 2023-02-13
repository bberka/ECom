using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string ToEncryptedText(this string str)
        {
            return str.MD5Hash().ToBase64String();
        }
    }
}
