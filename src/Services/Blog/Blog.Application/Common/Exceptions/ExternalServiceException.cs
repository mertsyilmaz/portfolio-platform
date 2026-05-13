using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Common.Exceptions
{
    public class ExternalServiceException : Exception
    {
        public ExternalServiceException(string message) : base(message)
        {
        }
    }
}
