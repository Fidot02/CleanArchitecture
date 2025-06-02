using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Data
{
    public class ItemRepository : IItemRepository
    {
        private readonly RestaurantDbContext _context;
        public ItemRepository (RestaurantDbContext context)
        {
            _context = context;
        }
        public async Task AddItemAsync(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
        }

        public  IQueryable<Item> GetAll()
        {
           return _context.Items;
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
           return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetItemByIdAsync(Guid id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task ReplaceItemByIdAsync(Guid id, Item updatedItemDTO)
        {
            var existingItem = await GetItemByIdAsync(id);

            if (existingItem == null)
            {
                throw new InvalidOperationException("Item not Found");
            }

            existingItem.Name = updatedItemDTO.Name;
            existingItem.Description = updatedItemDTO.Description;  
            existingItem.Price = updatedItemDTO.Price;
            existingItem.ImageUrl = updatedItemDTO.ImageUrl;
            existingItem.CategoryId = existingItem.CategoryId;

            await _context.SaveChangesAsync();           
        }

        public async Task DeleteItemByIdAsync(Guid id)
        {
            var existingItem = await _context.Items.FindAsync(id);
            if (existingItem == null)
            {
                throw new InvalidOperationException("Category does not exist");
            }

             _context.Items.Remove(existingItem);
            await _context.SaveChangesAsync();
        }
    }
}
