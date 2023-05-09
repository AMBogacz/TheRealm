using Microsoft.AspNetCore.Mvc;
using TheRealm.Services;

namespace TheRealm.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MiningController : ControllerBase
    {
        private readonly IMiningService _miningService;
        public MiningController(IMiningService miningService)
        {
            _miningService= miningService;
        }

        [HttpGet]
        [Route("GetIron")]
        public IActionResult GetIron()
        {
            var iron = _miningService.GetIron();
            return Ok(iron);
        }

        [HttpGet]
        [Route("GetCoal")]
        public IActionResult GetCoal()
        {
            var coal = _miningService.GetCoal();
            return Ok(coal);
        }

        [HttpGet]
        [Route("GetGold")]
        public IActionResult GetGold()
        {
            var gold = _miningService.GetGold();
            return Ok(gold);
        }

        [HttpGet]
        [Route("SendTools/{toolsAmount}")]
        public IActionResult SendTools(int toolsAmount)
        {
            try
            {
                var success = _miningService.SendTools(toolsAmount);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
            
        }

    }
}
