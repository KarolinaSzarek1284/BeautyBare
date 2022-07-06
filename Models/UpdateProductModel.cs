using System.ComponentModel.DataAnnotations;

namespace BeautyBareAPI.Models
{
    public class UpdateProductModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
