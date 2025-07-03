using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class InvalidMarksException : Exception
    {
        public InvalidMarksException() : base("Marks entered are outside the valid range (0-100).")
        {
        }

        public InvalidMarksException(string message) : base(message)
        {
        }

        public InvalidMarksException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

