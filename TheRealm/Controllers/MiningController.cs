using Microsoft.AspNetCore.Mvc;
using TheRealm.Services;

namespace TheRealm.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MiningController : ControllerBase
    {
        private readonly MiningService _miningService;
        public MiningController(MiningService miningService)
        {
            _miningService= miningService;
        }

        [HttpGet]
        [Route("GetIron")]
        public ActionResult GetIron()
        {
            var iron = _miningService.GetIron();
            return Ok(iron);
        }

        [HttpGet]
        [Route("GetCoal")]
        public ActionResult GetCoal()
        {
            var coal = _miningService.GetCoal();
            return Ok(coal);
        }

        [HttpGet]
        [Route("GetGold")]
        public ActionResult GetGold()
        {
            var gold = _miningService.GetGold();
            return Ok(gold);
        }
    }
}
