namespace AdaTech.InventoryControl.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public List<Batch> Batches { get; set; }
    }
}
