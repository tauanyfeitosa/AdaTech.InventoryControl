using System.ComponentModel.DataAnnotations;

namespace AdaTech.InventoryControl.WebAPI.Requests
{
    public class ProductRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
