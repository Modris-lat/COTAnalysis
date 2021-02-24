using System;

namespace CoreLibrary.Exceptions
{
    public class CotDataNotFoundException: Exception
    {
        public CotDataNotFoundException(): base(){}
        public CotDataNotFoundException(string message): base(message){}
        public CotDataNotFoundException(string message, Exception inner): base(){}
    }
}
