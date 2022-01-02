using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MyBlogBLL.Validation
{
    public class BlogException : Exception
    {
        public BlogException()
        {
        }

        public BlogException(string message) : base(message)
        {
        }

        public BlogException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BlogException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
