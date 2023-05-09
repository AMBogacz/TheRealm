using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheRealm.Services;

namespace TheRealm.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LumberMillController : Controller
    {
        private readonly LumberMillService _lumberMillService;
        public LumberMillController(LumberMillService lumberMillService)
        {
            _lumberMillService= lumberMillService;
        }

        [HttpGet]
        public ActionResult GetWood()
        {
            var wood = _lumberMillService.GetWood();
            return Ok(wood);
        }

    }
}
