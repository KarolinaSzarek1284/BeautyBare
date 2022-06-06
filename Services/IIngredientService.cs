using BeautyBareAPI.Models;

namespace BeautyBareAPI.Services
{
    public interface IIngredientService
    {
        int Create(int productId, CreateIngredientDto dto);
        IngredientDto GetById(int productId, int ingredientId);
        public List<IngredientDto> GetAll(int productId);
        void RemoveAll(int productId);
        void Remove(int producId, int ingredientId);
    }
}