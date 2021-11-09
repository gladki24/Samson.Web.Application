using System;
using System.Globalization;

namespace Samson.Web.Application.Infrastructure.Exceptions
{
    /// <summary>
    /// Exception to represent exception in business logic
    /// </summary>
    public class BusinessLogicException : Exception
    {
        public BusinessLogicException() : base()
        {
        }
        
        public BusinessLogicException(string message) : base(message)
        {
        }

        public BusinessLogicException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
