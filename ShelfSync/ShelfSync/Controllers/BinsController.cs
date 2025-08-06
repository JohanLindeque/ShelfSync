using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using ShelfSync.Shared.Entities;
using ShelfSync.Shared.Services.Interfaces;

namespace ShelfSync.Controllers
{
    [Route("api/bins")]
    [ApiController]
    public class BinsController : ControllerBase
    {
        private readonly IBinService _binService;
        public BinsController(IBinService binService)
        {
            _binService = binService;
        }

        [Route("all")]
        public async Task<ActionResult<List<StorageBin>>> GetAllStorageBins()
        {
            try
            {
                var storageBins = await _binService.GetAllStorageBins();
                return Ok(storageBins);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StorageBin>> GetStorageBinById(int Id)
        {
            try
            {
                var storageBin = await _binService.GetStorageBinById(Id);
                if (storageBin == null)
                {
                    return NotFound();
                }

                return Ok(storageBin);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");

            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<StorageBin>> AddStorageBin(StorageBin storageBin)
        {
            try
            {
                if (storageBin == null)
                {
                    return BadRequest("Storage Bin cannot be null");
                }

                var addedStorageBin = await _binService.AddStorageBin(storageBin);
                return CreatedAtAction(nameof(GetStorageBinById), new { id = addedStorageBin.Id }, addedStorageBin);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteStorageBinById(int id)
        {
            try
            {
                var wasDeleted = await _binService.DeketeCategoryById(id);
                if (!wasDeleted)
                {
                    return NotFound($"Storage Bin with ID {id} not found");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<StorageBin>> UpdateStorageBin(int id, StorageBin storageBin)
        {
            try
            {
                if (storageBin == null)
                {
                    return BadRequest("Storage Bin cannot be null");
                }

                if (id != storageBin.Id)
                {
                    return BadRequest("ID mismatch");
                }

                var updatedStorageBin = await _binService.UpdateStorageBin(storageBin);
                if (storageBin == null)
                {
                    return NotFound($"Storage Bin with ID {id} not found");

                }

                return Ok(updatedStorageBin);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
