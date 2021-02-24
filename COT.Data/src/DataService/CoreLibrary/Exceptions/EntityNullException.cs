using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLibrary.Exceptions
{
    public class EntityNullException: Exception
    {
        public EntityNullException(): base(){}
        public EntityNullException(string message): base(message){}
        public EntityNullException(string message, Exception inner): base(message, inner){}
    }
}
