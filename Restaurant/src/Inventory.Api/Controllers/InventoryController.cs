using AutoMapper;
using Inventory.Application.DataContracts.Data;
using Inventory.Application.DataContracts.Requests;
using Inventory.Application.DataContracts.Responses;
using Inventory.Domain.Entities;
using Inventory.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        private IMapper _mapper { get; }

        public InventoryController(
            IInventoryService inventoryService,
            IMapper mapper)
        {
            _inventoryService = inventoryService;
            _mapper = mapper;
        }        

        [HttpGet("Get")]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                var result = new ItemsResponse()
                {
                    Items = _mapper.Map<IEnumerable<Item>>(await _inventoryService.GetItemsAsync())
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Use")]
        public async Task<IActionResult> UseItems(UpdateItemsRequest request)
        {
            try
            {
                return Ok(_inventoryService.UseItemsAsync(
                        _mapper.Map<IEnumerable<ItemEntity>>(request.Items))
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Return")]
        public async Task<IActionResult> ReturnItems(UpdateItemsRequest request)
        {
            try
            {
                return Ok(
                        _inventoryService.ReturnItemsAsync(
                            _mapper.Map<IEnumerable<ItemEntity>>(request.Items)
                        )
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateItems(UpdateItemsRequest request)
        {
            try
            {
                _inventoryService.UpdateItems(_mapper.Map<IEnumerable<ItemEntity>>(request.Items));

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}