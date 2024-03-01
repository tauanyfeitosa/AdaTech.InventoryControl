namespace AdaTech.InventoryControl.Entities
{
    public class Batch
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int QuantityItems { get; set; }
        public DateOnly ExpiryDate { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
