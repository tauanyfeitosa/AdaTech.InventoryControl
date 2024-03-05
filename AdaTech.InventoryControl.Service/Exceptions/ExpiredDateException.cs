using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.InventoryControl.Service.Exceptions
{
    public class ExpiredDateException : Exception
    {
        public ExpiredDateException() : base() { }
        public ExpiredDateException(string message) : base(message) { }
        public ExpiredDateException(string message, Exception inner) : base(message, inner) { }
    }
}
