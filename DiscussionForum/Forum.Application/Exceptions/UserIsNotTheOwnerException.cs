using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Exceptions
{
  public  class UserIsNotTheOwnerException : Exception
    {
        public int StatusCodeResult => 401;
        public UserIsNotTheOwnerException()
        {
            HResult = StatusCodeResult;
        }

        public UserIsNotTheOwnerException(string message) : base(message)
        {
            HResult = StatusCodeResult;
        }

        public UserIsNotTheOwnerException(string message, Exception innerException) : base(message, innerException)
        {
            HResult = StatusCodeResult;
        }
    }
}
