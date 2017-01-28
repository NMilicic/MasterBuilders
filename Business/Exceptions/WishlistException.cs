using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class WishlistException : Exception, ISerializable
    {
        public WishlistException(string message)
            : base(message)
        { }

        public static string WishlistExceptionsText(WishlistExceptionEnum exception)
        {
            switch (exception)
            {
                case WishlistExceptionEnum.InvalidData:
                    return "Missing user data!";
                case WishlistExceptionEnum.Taken:
                    return "User with that email is already register!";
                case WishlistExceptionEnum.NotFound:
                    return "User not found!";
            }
            return "";
        }
    }

    public enum WishlistExceptionEnum
    {
        InvalidData,
        Taken,
        NotFound
    }


}
