using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
