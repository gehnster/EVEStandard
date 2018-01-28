using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard
{
    public class EVEStandardException : Exception
    {
        public EVEStandardException()
        {
        }

        public EVEStandardException(string message)
            : base(message)
        {
        }

        public EVEStandardException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
