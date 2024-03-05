using AdaTech.InventoryControl.Entities;
using AdaTech.InventoryControl.Service.Interfaces;
using AdaTech.InventoryControl.WebAPI.Requests;
using Microsoft.AspNetCore.Mvc;

namespace AdaTech.InventoryControl.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : Controller
    {
        private readonly IInventoryControlService _service;

        public BatchController(IInventoryControlService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public IActionResult AddBatch([FromBody] BatchRequest request)
        {
            var batch = _service.AddBatch(request);
            return View(batch);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var batches = _service.GetAllBatches();
            return View(batches);
        }

        [HttpGet("getById")]
        public IActionResult GetOneBatch([FromQuery] int id)
        {
            var batch = _service.GetOneBatch(id);
            return View(batch);
        }

        [HttpPut("update")]
        public IActionResult UpdateBatch([FromBody] BatchRequest request, [FromQuery] int id)
        {
            var batch = _service.UpdateBatch(request, id);
            return View(batch);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteBatch([FromQuery] int id)
        {
            var batch = _service.DeleteBatch(id);
            return View(batch);
        }

        [HttpPost("discardExpiredBatches")]
        public IActionResult DiscardExpiredBatches()
        {
            var batches = _service.DiscardExpiredBatches();
            return View(batches);
        }
    }
}
