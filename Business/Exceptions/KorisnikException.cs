using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class KorisnikException: Exception, ISerializable
    {
        public KorisnikException(string message)
            : base(message) { }

        public static string KorisnikExceptionsText(KorisnikExceptionEnum exception)
        {
            switch (exception)
            {
                case KorisnikExceptionEnum.InvalidData:
                    return "Missing user data!";
                case KorisnikExceptionEnum.Taken:
                    return "User with that email is already register!";
                case KorisnikExceptionEnum.NotFound:
                    return "User not found!";
            }
            return "";
        }
    }

    public enum KorisnikExceptionEnum
    {
        InvalidData,
        Taken,
        NotFound
    }


}
