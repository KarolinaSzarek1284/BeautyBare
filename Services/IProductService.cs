using BeautyBareAPI.Models;

namespace BeautyBareAPI.Services
{
    public interface IProductService
    {
        int Create(CreateProductModel dto);
        IEnumerable<ProductModel> GetAll();
        ProductModel GetById(int id);
        void Delete(int id);
        void Update(int id, UpdateProductModel dto);
    }
}