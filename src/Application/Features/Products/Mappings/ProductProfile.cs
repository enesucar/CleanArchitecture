using Application.Features.Products.Commands;
using Application.Features.Products.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Products.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, EditProductCommand>().ReverseMap(); 
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
