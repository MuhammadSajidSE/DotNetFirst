using college_Application.MyLooging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace college_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class newLoggerDemo : ControllerBase
    {
        private readonly IMyLogger _mylooger;
        //public newLoggerDemo()
        //{
        //    _mylooger = new LogToServer();
        //}

        //losly couple techniqu 
        public newLoggerDemo(IMyLogger mylooger)
        {
            _mylooger = mylooger;
        }
        [HttpGet]
        public ActionResult index2()
        {
            Console.WriteLine("I am looger demo 2 controller");
            _mylooger.Log("This is controller 2");
            return Ok();
        }
    }
}
