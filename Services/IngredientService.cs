using AutoMapper;
using BeautyBareAPI.Entities;
using BeautyBareAPI.Exceptions;
using BeautyBareAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BeautyBareAPI.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly BeautyBareContext _context;
        public IngredientService(BeautyBareContext context)
        {
            _context = context;
        }
        public int Create(int productId, CreateIngredientDto dto)
        {
            var product = GetProductById(productId);
            var ingredient = new Ingredient()
            {
                Name = dto.Name,
                ProductId = dto.ProductId
            };
            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();

            return ingredient.Id;
        }

        public IngredientDto GetById(int productId, int ingredientId)
        {
            var product = GetProductById(productId);

            var ingredientDto = _context.Ingredients.Select(b => new IngredientDto()
            {
                Id = b.Id,
                Name = b.Name
            }).FirstOrDefault(b => b.Id == ingredientId);
            if (ingredientDto is null)
            {
                throw new NotFoundException("Ingredient not found");
            }
            return ingredientDto;
        }

        public IQueryable<IngredientDto> GetAll(int productId)
        {
            var product = GetProductById(productId);
            var ingredientsDto = _context.Ingredients.Select
                (b => new IngredientDto()
                {
                    Id = b.Id,
                    Name = b.Name
                }).AsQueryable();


            return ingredientsDto;
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
