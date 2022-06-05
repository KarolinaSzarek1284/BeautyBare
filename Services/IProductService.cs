using BeautyBareAPI.Models;

namespace BeautyBareAPI.Services
{
    public interface IProductService
    {
        int Create(CreateProductDto dto);
        IEnumerable<ProductDto> GetAll();
        ProductDto GetById(int id);
        void Delete(int id);
        void Update(int id, UpdateProductDto dto);
    }
}