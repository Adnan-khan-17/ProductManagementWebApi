using System.ComponentModel.DataAnnotations;

namespace ProductManagementApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "only positive number allowed ")]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
