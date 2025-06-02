using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CleanArch.Application.Interfaces;
using CleanArch.Application.DTOs;
using CleanArch.Application.Services;


namespace CleanArch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("Get-All-Items")]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await _itemService.GetAllItems();
            return Ok(items);
        }

        [HttpPost("Add-Item")]
        public async Task<IActionResult> AddItemAsync(Guid categoryId,[FromBody] ItemDTO itemDTO)
        {
            await _itemService.AddItemAsync(itemDTO,categoryId);
            return Ok("Item was added successfully");
        }
        
        [HttpGet("Get-Item-by-Id/{id}")]
        public async Task<IActionResult> GetItemByIdAsync(Guid id)
        {
            var Itemdto = await _itemService.GetItemByIdAsync(id);
            return Ok(Itemdto);
        }

        [HttpPut("Replace-Item-by-Id")]
        public async Task<IActionResult> ReplaceItemByIdAsync(Guid id, Guid categoryId, [FromBody] ItemDTO updatedItemDTO )
        {
            await _itemService.ReplaceItemByIdAsync(id, categoryId ,updatedItemDTO);
            return Ok("Item successfully Replaced");
        }

        [HttpDelete("Delete-Item-by-Id")]
        public async Task<IActionResult> DeleteItemByIdAsync(Guid id)
        {
            await _itemService.DeleteItemByIdAsync(id);
            return Ok("Item has been deleted");
        }
    }

        
}
