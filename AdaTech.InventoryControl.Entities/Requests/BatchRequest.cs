using System.ComponentModel.DataAnnotations;

namespace AdaTech.InventoryControl.WebAPI.Requests
{
    public class BatchRequest
    {
        [Required]
        public int QuantityItems { get; set; }
        [Required]
        public DateOnly ExpiryDate { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
