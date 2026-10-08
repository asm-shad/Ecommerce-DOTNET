using System;
using asp_net_ecommerce_web_api.DTOs;
using AutoMapper;
using ecommerce_web_api.Models;

namespace ecommerce_web_api.Profiles
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
        }
    }
}
