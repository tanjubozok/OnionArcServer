using AutoMapper;
using OnionArc.Application.Features.Categories.Results;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.Categories.Mappings;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, GetCategoryQueryResult>();
    }
}