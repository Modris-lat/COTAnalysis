using System;

namespace CoreLibrary.Exceptions
{
    public class InvalidTextLineException: Exception
    {
        public InvalidTextLineException(): base(){}
        public InvalidTextLineException(string message): base(message){}
        public InvalidTextLineException(string message, Exception inner): base(message, inner){}
    }
}
