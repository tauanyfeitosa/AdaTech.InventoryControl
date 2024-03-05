using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.InventoryControl.Service.Exceptions
{
    public class InvalidProductNameException : Exception
    {
        public InvalidProductNameException() : base() { }
        public InvalidProductNameException(string message) : base(message) { }
        public InvalidProductNameException(string message, Exception inner) : base(message, inner) { }
    }
}
