using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly RestaurantDbContext _context;
        public CategoryRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task AddCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            
            return await _context.Categories.ToListAsync();
        }

        public IQueryable<Category> GetAll()
        {
            return  _context.Categories;
        }

        public async Task<Category> GetCategoryByIdAsync(Guid id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task ReplaceCategoryByIdAsync(Guid id, Category updatedCategory)
        {

            var identity = await GetCategoryByIdAsync(id);

            if (identity == null)
            {
                throw new InvalidOperationException("Category not found");
            }
            
            identity.Name = updatedCategory.Name;
            identity.ImageUrl = updatedCategory.ImageUrl;
           
            


             await _context.SaveChangesAsync();

            

        }

        public async Task DeleteCategoryByIdAsync(Guid id)
        {
            var existingCategory = await _context.Categories.FindAsync(id);
            if (existingCategory == null)
            {
                throw new InvalidOperationException("Category does not exist");
            }
            
            _context.Categories.Remove(existingCategory);
            await _context.SaveChangesAsync();
        }
    }
}
