using BeautyBareAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace BeautyBareAPI.Models
{
    public class CreateIngredientDto
    {
        [Required]
        public string Name { get; set; }

        public int ProductId { get; set; }

    }
}
