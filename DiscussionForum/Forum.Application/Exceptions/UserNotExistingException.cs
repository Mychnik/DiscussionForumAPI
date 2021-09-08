using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Exceptions
{
    public class UserNotExistingException : Exception
    {
        public int StatusCodeResult => 400;
        public UserNotExistingException()
        {
            HResult = StatusCodeResult;
        }

        public UserNotExistingException(string message) : base(message)
        {
            HResult = StatusCodeResult;
        }

        public UserNotExistingException(string message, Exception innerException) : base(message, innerException)
        {
            HResult = StatusCodeResult;
        }
    }
}
