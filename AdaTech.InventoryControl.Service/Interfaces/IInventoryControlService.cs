using AdaTech.InventoryControl.Entities;
using AdaTech.InventoryControl.WebAPI.Requests;

namespace AdaTech.InventoryControl.Service.Interfaces
{
    public interface IInventoryControlService
    {
        Batch AddBatch(BatchRequest request);
        IEnumerable<Batch> GetAllBatches();
        Batch GetOneBatch(int id);
        Batch UpdateBatch(BatchRequest request, int id);
        Batch DeleteBatch(int id);
        IEnumerable<Batch> DiscardExpiredBatches();

        Product AddProduct(ProductRequest request);
        IEnumerable<Product> GetAllProducts();
        Product GetOneProduct(int id);
        Product UpdateProduct(ProductRequest request, int id);
        Product DeleteProduct(int id);
        void RegisterProductsExit(int quantity, int productId, int? batchId = default);
    }
}
