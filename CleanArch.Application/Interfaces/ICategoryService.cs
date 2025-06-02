using CleanArch.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategories();
        Task AddCategoryAsync(CategoryDTO categoryDTO);

        Task<CategoryDTO> GetCategoryByIdAsync(Guid Id);
        Task ReplaceCategoryByIdAsync(Guid id, CategoryDTO updatedCategoryDTO);

        Task DeleteCategoryByIdAsync(Guid id);
    }
}
