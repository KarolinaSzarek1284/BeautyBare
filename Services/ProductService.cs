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
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;

        public ProductService(BeautyBareContext context, IMapper mapper, ILogger<ProductService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public ProductModel GetById(int id)
        {
            var product = _context
            .Products
            .Include(p => p.Brand)
            .Include(p => p.Ingredients)
            .FirstOrDefault(p => p.Id == id);

            if (product is null)
                throw new NotFoundException("Product not found");

            var result = _mapper.Map<ProductModel>(product);
            return result;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            var products = _context
            .Products
            .Include(p => p.Brand)
            .Include(p => p.Ingredients)
            .ToList();

            var productsDtos = _mapper.Map<List<ProductModel>>(products);

            return productsDtos;
        }

        public int Create(CreateProductModel dto)
        {
            var product = _mapper.Map<Product>(dto);
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

        public void Update(int id, UpdateProductModel dto)
        {
            var product = _context
            .Products
            .FirstOrDefault(p => p.Id == id);

            if( product is null)
                throw new NotFoundException("Product not found");

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Category = dto.Category;

            _context.SaveChanges();
        }
    }
}
