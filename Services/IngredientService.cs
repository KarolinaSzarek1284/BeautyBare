using AutoMapper;
using BeautyBareAPI.Dtos;
using BeautyBareAPI.Entities;
using BeautyBareAPI.Exceptions;
using BeautyBareAPI.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BeautyBareAPI.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly BeautyBareContext _context;
        private readonly IMapper _mapper;

        public IngredientService(BeautyBareContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Create(int productId, CreateIngredientModel dto)
        {
            var product = GetProductById(productId);

            var ingredientEntity = _mapper.Map<Ingredient>(dto);

            ingredientEntity.ProductId = productId;

            _context.Ingredients.Add(ingredientEntity);
            _context.SaveChanges();

            return ingredientEntity.Id;

        }

        public IngredientModel GetById(int productId, int ingredientId)
        {
            var product = GetProductById(productId);

            var ingredient = _context.Ingredients.Select(x => new IngredientModel()
            {
                Id = x.Id,
                Name = x.Name,
                ProductId = x.ProductId
            })
            .FirstOrDefault(i => i.Id == ingredientId);

            if (ingredient is null || ingredient.ProductId != productId)

            {
                throw new NotFoundException("Ingredient not found");
            }

            return ingredient;
        }

        public List<IngredientModel> GetAll(int productId)
        {
            var product = GetProductById(productId);
            var ingredientDto = _mapper.Map<List<IngredientModel>>(product.Ingredients);

            return ingredientDto;
        }

        public void RemoveAll(int productId)
        {
            var product = GetProductById(productId);

            _context.RemoveRange(product.Ingredients);
            _context.SaveChanges();
        }
        public void Remove(int producId, int ingredientId)
        {
            var product = GetProductById(producId);

            var ingredient = _context.Ingredients.FirstOrDefault(i => i.Id == ingredientId);
            if (ingredient is null || ingredient.ProductId != ingredientId)
            {
                throw new NotFoundException("Ingredient not found");
            }

            _context.Ingredients.Remove(ingredient);
            _context.SaveChanges();
        }


        private Product GetProductById(int productId)
        {
            var product = _context
            .Products
            .Include(p => p.Ingredients)
            .FirstOrDefault(p => p.Id == productId);
            if (product is null)
                throw new NotFoundException("Product not found");

            return product;
        }
    }
}
