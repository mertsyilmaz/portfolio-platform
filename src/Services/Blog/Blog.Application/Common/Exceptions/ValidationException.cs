using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string? message) : base(message)
        {
        }
    }
}
