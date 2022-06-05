using AutoMapper;
using BeautyBareAPI.Entities;
using BeautyBareAPI.Models;

namespace BeautyBareAPI
{
    public class BeautyBareMappingProfile : Profile
    {
        public BeautyBareMappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(m => m.BrandName, c => c.MapFrom(s => s.Brand.Name))
                .ForMember(m => m.BrandCountry, c => c.MapFrom(s => s.Brand.Country));

            CreateMap<Ingredient, IngredientDto>();

            CreateMap<CreateProductDto, Product>()
                .ForMember(m => m.Brand, c => c.MapFrom(dto => new Brand() { Name = dto.BrandName, Country = dto.BrandCountry }));

            CreateMap<CreateIngredientDto, Ingredient>();
        }
    }
}
