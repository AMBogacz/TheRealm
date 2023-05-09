using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheRealm.Services;

namespace TheRealm.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LumberMillController : Controller
    {
        private readonly ILumberMillService _lumberMillService;
        public LumberMillController(ILumberMillService lumberMillService)
        {
            _lumberMillService = lumberMillService;
        }

        [HttpGet]
        [Route("GetWood")]
        public IActionResult GetWood()
        {
            var wood = _lumberMillService.GetWood();
            return Ok(wood);
        }

        [HttpGet]
        [Route("SendTools/{toolsAmount}")]
        public async Task<IActionResult> SendTools(int toolsAmount) 
        {
            var success = await _lumberMillService.SendTools(toolsAmount);
            
            if (success) 
            {
                return Ok();
            }
            return StatusCode(500);
        }
    }
}
