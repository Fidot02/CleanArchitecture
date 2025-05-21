using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class CategoryService : ICategoryService
    {       
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
                _categoryRepository = categoryRepository;
        }

        public async void AddCategory(CategoryDTO categoryDTO)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = categoryDTO.Name,
                ImageUrl = categoryDTO.ImageUrl
            };

            await _categoryRepository.AddCategoryAsync(category);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategories() //Mapping
        {
            //var A = await _categoryRepository.GetAllCategoriesAsync();//.ToListAsync();//.Where(x => x.Name.StartsWith("A")).ToList();
             var Categories = await _categoryRepository.GetAllCategoriesAsync();
            var CategoriesDto = Categories
                .Select(x => new CategoryDTO
                {
                    Name = x.Name, ImageUrl = x.ImageUrl
                }).ToList();
            return CategoriesDto;
        }

       public async Task<CategoryDTO> GetCategoryByIdAsync(Guid Id)
        {
            var Category = await _categoryRepository.GetCategoryByIdAsync(Id);
            var CategoryDto = new CategoryDTO
            {
                Name = Category.Name,
                ImageUrl = Category.ImageUrl
            };
            return CategoryDto;
        }
    }
}
