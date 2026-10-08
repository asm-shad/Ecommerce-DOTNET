using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_net_ecommerce_web_api.Controllers;
using asp_net_ecommerce_web_api.DTOs;
using AutoMapper;
using ecommerce_web_api.Models;

namespace ecommerce_web_api.Services
{
    public class CategoryService: ICategoryService
    {
        private static readonly List<Category> _categories = new List<Category>();
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<CategoryReadDto> GetAllCategories()
        {
            return _mapper.Map<List<CategoryReadDto>>(_categories);
        }

        public CategoryReadDto? GetCategoryById(Guid categoryId)
        {
            var findCategory = _categories.FirstOrDefault(c => c.CategoryId == categoryId);
            return findCategory == null ? null : _mapper.Map<CategoryReadDto>(findCategory);
        }

        public CategoryReadDto CreateCategory(CategoryCreateDto categoryData)
        {
            // CategoryCreateDto => Category
            var newCategory = _mapper.Map<Category>(categoryData);
            newCategory.CategoryId =Guid.NewGuid();
            newCategory.Description = categoryData.Description;

            _categories.Add(newCategory);

            return _mapper.Map<CategoryReadDto>(newCategory);
        }
        public CategoryReadDto? UpdateCategoryById(Guid categoryId, CategoryUpdateDto categoryData)
        {
            var foundCategory = _categories.FirstOrDefault(category => category.CategoryId == categoryId);
            if (foundCategory == null)
            {
                return null;
            }

            _mapper.Map(categoryData, foundCategory);

            return _mapper.Map<CategoryReadDto>(foundCategory);
        }
        public bool DeleteCategoryById(Guid categoryId)
        {
            var foundCategory = _categories.FirstOrDefault(category => category.CategoryId == categoryId);
            if (foundCategory == null)
            {
                return false;
            }
            _categories.Remove(foundCategory);
            return true;
        }
    }
}