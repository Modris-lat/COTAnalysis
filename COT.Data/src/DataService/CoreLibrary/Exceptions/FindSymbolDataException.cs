using System;

namespace CoreLibrary.Exceptions
{
    public class FindSymbolDataException: Exception
    {
        public FindSymbolDataException(): base(){}
        public FindSymbolDataException(string message): base(message){}
        public FindSymbolDataException(string message, Exception inner): base(message, inner){}
    }
}
