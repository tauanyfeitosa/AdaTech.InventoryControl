using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.InventoryControl.Service.Exceptions
{
    public class InvalidInputQuantityException : Exception
    {
        public InvalidInputQuantityException() : base() { }
        public InvalidInputQuantityException(string message) : base(message) { }
        public InvalidInputQuantityException(string message, Exception inner) : base(message, inner) { }
    }
}
