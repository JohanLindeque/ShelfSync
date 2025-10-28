using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShelfSync.Shared.Entities;
using ShelfSync.Shared.Services.Interfaces;

namespace ShelfSync.Controllers
{
    [Route("api/barcodes")]
    [ApiController]
    public class BarcodeContoller : ControllerBase
    {
        private readonly IBarcodeService _barcodeService;

        public BarcodeContoller(IBarcodeService barcodeService)
        {
            _barcodeService = barcodeService;
        }

        [HttpPost]
        [Route("generate")]
        public async Task<ActionResult<StorageBin>> GenerateBarcodee(StorageBin storageBin)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (storageBin == null)
                {
                    return BadRequest("Storage Bin cannot be null");
                }

                var addedStorageBin = await _barcodeService.GenerateBarcodee(storageBin);
                return CreatedAtAction(
                    nameof(GetStorageBinById),
                    new { id = addedStorageBin.Id },
                    addedStorageBin
                );
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
