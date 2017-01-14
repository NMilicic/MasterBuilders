using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class DataException : Exception, ISerializable
    {
        public DataException(string message)
            : base(message) { }
    }
}
