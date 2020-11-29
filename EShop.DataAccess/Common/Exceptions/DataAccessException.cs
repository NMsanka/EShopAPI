using System;

namespace EShop.Data.Common.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class DataAccessException : Exception
    {
        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        public override string Message
        {
            get
            {
                return base.Message;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessException"/> class.
        /// </summary>
        public DataAccessException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public DataAccessException(string message)
          : base(message)
        {
        }
    }
}
