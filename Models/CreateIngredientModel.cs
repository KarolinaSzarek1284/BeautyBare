using BeautyBareAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace BeautyBareAPI.Models
{
    public class CreateIngredientModel
    {
        [Required]
        public string Name { get; set; }

        public int ProductId { get; set; }

    }
}
