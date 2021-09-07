using System;

namespace AppForSkills.Application.Exceptions
{
    public class WrongIDException : Exception
    {
        public WrongIDException() : base()
        {

        }

        public WrongIDException(string message) : base(message)
        {
        }

        public WrongIDException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
