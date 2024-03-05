using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.InventoryControl.Service.Exceptions
{
    public class LowStockException : Exception
    {
        public LowStockException() : base() { }
        public LowStockException(string message) : base(message) { }
        public LowStockException(string message, Exception inner) : base(message, inner) { }
    }
}
