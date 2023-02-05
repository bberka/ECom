using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Lib
{
    public static class ThrowHelper
    {
        public static void New(string message) { throw new Exception(message); }
        public static void New(string message, Exception exception) { throw new Exception(message, exception); }
        public static void InvalidOperation(string message) { throw new InvalidOperationException(message);}
        public static void NullReference(string propName) { throw new System.NullReferenceException($"{propName} is null"); }
        public static void NotImplemented(string message) { throw new NotImplementedException(message); }
        public static void NotImplemented() { throw new NotImplementedException(); }
    }
}
