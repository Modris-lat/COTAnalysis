using System;

namespace CoreLibrary.Exceptions
{
    public class InvalidStringException: Exception
    {
        public InvalidStringException(): base(){}
        public InvalidStringException(string message): base(message){}
        public InvalidStringException(string message, Exception inner): base(message, inner){}
    }
}
