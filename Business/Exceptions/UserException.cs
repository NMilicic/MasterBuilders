using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class UserException: Exception, ISerializable
    {
        public UserException(string message)
            : base(message) { }

        public static string UserExceptionsText(UserExceptionEnum exception)
        {
            switch (exception)
            {
                case UserExceptionEnum.InvalidData:
                    return "Missing user data!";
                case UserExceptionEnum.Taken:
                    return "User with that email is already register!";
                case UserExceptionEnum.NotFound:
                    return "User not found!";
            }
            return "";
        }
    }

    public enum UserExceptionEnum
    {
        InvalidData,
        Taken,
        NotFound
    }


}
