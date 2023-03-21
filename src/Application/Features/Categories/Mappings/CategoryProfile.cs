using Application.Features.Categories.Commands;
using Application.Features.Categories.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Categories.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, EditCategoryCommand>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
