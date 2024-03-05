using AdaTech.InventoryControl.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdaTech.InventoryControl.DateLibrary.Repository
{
    public class InventoryControlRepository<T> where T : class, IInvetoryControlRepository<T>
    {
        private readonly InventoryControlContext _context;

        public InventoryControlRepository(InventoryControlContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetOne(int id)
        {
            var item = await _context.Set<T>().FindAsync(id);
            return item;
        }

        public async Task<bool> Uptdate(T entity)
        {
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
