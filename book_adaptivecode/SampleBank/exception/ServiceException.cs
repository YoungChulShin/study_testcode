using System;
using System.Collections.Generic;
using System.Text;

namespace SampleBank.exception
{
    public class ServiceException : Exception
    {
        public ServiceException()
        {

        }

        public ServiceException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
