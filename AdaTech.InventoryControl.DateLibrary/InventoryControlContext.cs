using Microsoft.EntityFrameworkCore;

namespace AdaTech.InventoryControl.DateLibrary
{
    public class InventoryControlContext : DbContext
    {
        public InventoryControlContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
