using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShelfSync.Shared.Entities;
using ShelfSync.Shared.Services.Interfaces;

namespace ShelfSync.Controllers
{
    [Route("api/binItem")]
    [ApiController]
    public class BinItemCobtroller : ControllerBase
    {
        private readonly IBinItemService _binItemService;
        public BinItemCobtroller(IBinItemService binItemService)
        {
            _binItemService = binItemService;
        }

        [HttpGet("bin/{id:int}")]
        public async Task<ActionResult<List<BinItem>>> GetAllItemsForBinById(int id)
        {
            try
            {
                var binItems = await _binItemService.GetAllBinItems(id);
                return Ok(binItems);
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
                // return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BinItem>> GetBinItemById(int Id)
        {
            try
            {
                var binItem = await _binItemService.GetBinItemById(Id);
                if (binItem == null)
                {
                    return NotFound();
                }

                return Ok(binItem);
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<BinItem>> AddBinItem(BinItem binItem)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);

                }
                if (binItem == null)
                {
                    return BadRequest("Bin Item cannot be null");
                }

                var addedBinItem = await _binItemService.AddBinItem(binItem);
                return CreatedAtAction(nameof(GetBinItemById), new { id = addedBinItem.Id }, addedBinItem);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteBinItemById(int id)
        {
            try
            {
                var wasDeleted = await _binItemService.DeleteBinItemById(id);
                if (!wasDeleted)
                {
                    return NotFound($"Bin Item with ID {id} not found");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<BinItem>> UpdateStorageBin(int id, BinItem binItem)
        {
            try
            {
                if (binItem == null)
                {
                    return BadRequest("Bin Item cannot be null");
                }

                if (id != binItem.Id)
                {
                    return BadRequest("ID mismatch");
                }

                var updatedBinItem = await _binItemService.UpdateBinItem(binItem);
                if (binItem == null)
                {
                    return NotFound($"Bin Item with ID {id} not found");

                }

                return Ok(updatedBinItem);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }









    }
}
