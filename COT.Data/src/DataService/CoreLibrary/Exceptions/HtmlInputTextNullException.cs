using System;

namespace CoreLibrary.Exceptions
{
    public class HtmlInputTextNullException: Exception
    {
        public HtmlInputTextNullException(): base(){}
        public HtmlInputTextNullException(string message): base(message){}
        public HtmlInputTextNullException(string message, Exception inner) : base(message, inner){}
    }
}
