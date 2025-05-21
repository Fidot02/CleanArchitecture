using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task AddCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
