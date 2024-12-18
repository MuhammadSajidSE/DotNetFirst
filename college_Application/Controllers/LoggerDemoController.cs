using college_Application.MyLooging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace college_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggerDemoController : ControllerBase
    {
        //1 first method to  implement the dependencies is the tightly couple
        private readonly IMyLogger _mylogger;
        //public LoggerDemoController()
        //{
        //    _mylogger = new LogToFile();
        //}
        /// <summary>
        /// it the coorcet method which is lossly couple and we will pass the object not the
        /// calss create by self object and this is the dynamic object 
        /// what object is pass to the controller we will pass from program.c file
        /// </summary>
        /// 
        public LoggerDemoController(IMyLogger mylogger)
        {
            _mylogger = mylogger;
        }
        [HttpGet]
        public ActionResult Index()
        {
            _mylogger.Log("Index method has been started");
            return Ok();
        }

    }
}
