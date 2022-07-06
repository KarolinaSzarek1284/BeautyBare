using AutoMapper;
using BeautyBareAPI.Dtos;
using BeautyBareAPI.Entities;
using BeautyBareAPI.Models;
using Mapster;

namespace BeautyBareAPI
{
    public class BeautyBareMappingProfile : Profile
    {
        public BeautyBareMappingProfile()
        {
            TypeAdapterConfig<IngredientModel, IngredientDto>.NewConfig()
            .Map(dest => dest.Name, src => src.Name);

            CreateMap<Product, ProductModel>()
                .ForMember(m => m.BrandName, c => c.MapFrom(s => s.Brand.Name))
                .ForMember(m => m.BrandCountry, c => c.MapFrom(s => s.Brand.Country));

           // CreateMap<Ingredient, IngredientModel>();

            CreateMap<CreateProductModel, Product>()
                .ForMember(m => m.Brand, c => c.MapFrom(dto => new Brand() { Name = dto.BrandName, Country = dto.BrandCountry }));

            CreateMap<CreateIngredientModel, Ingredient>();

        }
    }
}
