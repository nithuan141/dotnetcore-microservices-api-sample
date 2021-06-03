using System;
using System.Collections.Generic;
using System.Text;

namespace ApiBase.Common
{
    [Serializable]
    public class InvalidDataException : Exception
    {
        public InvalidDataException()
        {

        }

        public InvalidDataException(string message)
            : base(String.Format("Invalid data: {0}", message))
        {

        }

    }
}
