using BeautyBareAPI.Dtos;
using BeautyBareAPI.Models;

namespace BeautyBareAPI.Services
{
    public interface IIngredientService
    {
        int Create(int productId, CreateIngredientModel dto);
        IngredientModel GetById(int productId, int ingredientId);
        public List<IngredientModel> GetAll(int productId);
        void RemoveAll(int productId);
        void Remove(int producId, int ingredientId);
    }
}