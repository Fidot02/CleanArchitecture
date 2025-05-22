using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CleanArch.Application.Interfaces;
using CleanArch.Application.DTOs;


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
        public IActionResult AddItem(Guid categoryId,[FromBody] ItemDTO itemDTO)
        {
            _itemService.AddItem(itemDTO,categoryId);
            return Ok("Item was added successfully");
        }
        
        [HttpGet("Get-Item-by-Id/{id}")]
        public async Task<IActionResult> GetItemByIdAsync(Guid id)
        {
            var Itemdto = await _itemService.GetItemByIdAsync(id);
            return Ok(Itemdto);
        }
    }

        

    }
