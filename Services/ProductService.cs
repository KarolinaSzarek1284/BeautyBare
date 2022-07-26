using AutoMapper;
using BeautyBareAPI.Entities;
using BeautyBareAPI.Exceptions;
using BeautyBareAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BeautyBareAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly BeautyBareContext _context;
        private readonly ILogger<ProductService> _logger;

        public ProductService(BeautyBareContext context, ILogger<ProductService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public ProductDto GetById(int id)
        {
            if (!_context.Products.Any(x => x.Id == id))
                throw new NotFoundException("Product not found");

            var productDto = _context.Products.Select(b => new ProductDto()
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description,
                Category = b.Category,
                Subcategory = b.Subcategory,
                Contraindications = b.Contraindications,
                Apllying = b.Apllying,
                Capacity = b.Capacity,
                IsVegan = b.IsVegan,
                Country = b.Country,
                InUse = b.InUse,
                BrandName = b.Brand.Name,
                BrandCountry = b.Brand.Country,
                Ingredients = b.Ingredients.Select(i => new IngredientDto()
                {
                    Id = i.Id,
                    Name = i.Name
                }).ToList()
            }).FirstOrDefault(b => b.Id == id);

            if (productDto is null)
            {
                throw new NotFoundException("Product not found");
            }
            return productDto;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            if (!_context.Products.Any())
                throw new NotFoundException("Product not found");

            var productsDto = _context.Products.Select(b => new ProductDto()
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description,
                Category = b.Category,
                Subcategory = b.Subcategory,
                Contraindications = b.Contraindications,
                Apllying = b.Apllying,
                Capacity = b.Capacity,
                IsVegan = b.IsVegan,
                Country = b.Country,
                InUse = b.InUse,
                BrandName = b.Brand.Name,
                BrandCountry = b.Brand.Country,
                Ingredients = b.Ingredients.Select(i => new IngredientDto()
                {
                    Id = i.Id,
                    Name = i.Name
                }).ToList()
            }).AsQueryable();

            return productsDto;
        }

        public int Create(CreateProductDto dto)
        {
            var product = new Product()
            {
                Name = dto.Name,
                Description = dto.Description,
                Category = dto.Category,
                Subcategory = dto.Subcategory,
                Contraindications = dto.Contraindications,
                Apllying = dto.Apllying,
                Capacity = dto.Capacity,
                IsVegan = dto.IsVegan,
                Country = dto.Country,
                InUse = dto.InUse,
                Brand = new Brand()
                {
                    Name = dto.BrandName,
                    Country = dto.Country
                }
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return product.Id;
        }

        public void Delete(int id)
        {
            _logger.LogError($"Product with id:{id} DELETE action invoked");

            var product = _context
           .Products
           .FirstOrDefault(p => p.Id == id);

            if (product is null)
                throw new NotFoundException("Product not found");

            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateProductDto dto)
        {
            var product = _context
            .Products
            .FirstOrDefault(p => p.Id == id);

            if (product is null)
                throw new NotFoundException("Product not found");

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Category = dto.Category;

            _context.SaveChanges();
        }
    }
}
