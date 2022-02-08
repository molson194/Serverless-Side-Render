using Microsoft.AspNetCore.Mvc;

namespace serverSide.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new OkObjectResult(Data.GetData());
        }

        [HttpPost]
        public ActionResult Post([FromForm] string name)
        {
            Data.AppendData(name);
            return new AcceptedResult("http://localhost:5007/Home", "Data accepted. Note to self: prevent default submit action to change form href location.");
        }
    }
}