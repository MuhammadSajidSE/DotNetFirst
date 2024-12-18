using college_Application.MyLooging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace college_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Demo3Controller : ControllerBase
    {
        private readonly IMyLogger _logerinterface;
        public Demo3Controller(IMyLogger subloggerinstance)
        {
            _logerinterface = subloggerinstance;
        }
        [HttpGet("thirddemologger")]
        public ActionResult Printlog()
        {
            _logerinterface.Log("I am third loger demo class");
            return Ok();
        }
    }

}
