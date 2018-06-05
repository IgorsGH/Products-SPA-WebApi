using System.ComponentModel.DataAnnotations;

namespace ServerPart.Models
{
    public class ProductTypeViewModel
    {
        public int Id { get; set; }

        [Required]
        public string ProductTypeName { get; set; }
    }
}