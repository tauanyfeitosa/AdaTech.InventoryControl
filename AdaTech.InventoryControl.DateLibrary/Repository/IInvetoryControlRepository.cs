
namespace AdaTech.InventoryControl.DateLibrary.Repository
{
    public interface IInvetoryControlRepository<T> where T : class
    {
        Task<bool> Create (T entity);
        Task<bool> Uptdate (T  entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetOne (int id);
        Task<bool> Delete (T entity);
    }
}
