using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Exceptions
{
    public class SignInFailedException : Exception
    {
        public int StatusCodeResult => 400;
        public SignInFailedException()
        {
            HResult = StatusCodeResult;
        }

        public SignInFailedException(string message) : base(message)
        {
            HResult = StatusCodeResult;
        }

        public SignInFailedException(string message, Exception innerException) : base(message, innerException)
        {
            HResult = StatusCodeResult;
        }

    }
}
