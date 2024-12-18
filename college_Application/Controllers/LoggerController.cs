using college_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace college_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        private readonly ILogger<LoggerController> _logger;
        public LoggerController(ILogger<LoggerController> logger)
        {
            _logger = logger;
        }
        [HttpGet("{id:int}")]

        public ActionResult<PatientRipo> GetAllPatient(int id)
        {
            if (id==null)
            {
                _logger.LogError("Please Enter the ID");
                return BadRequest();
            }
            var searching = PatientRipo.Patients.Where(n => n.id == id).FirstOrDefault();
            if (searching==null)
            {
                _logger.LogWarning("This ID is not exist");
                return NotFound();
            }
            _logger.LogWarning("Every thing Ok");
            return Ok(searching);
        }
        [HttpGet]
        public ActionResult LoggerChecker()
        {
            _logger.LogTrace("I am Log Trace");
            _logger.LogDebug("I am Log debug");
            _logger.LogInformation("I am information log");
            _logger.LogWarning("I am Warning log");
            _logger.LogError("I am Error log");
            _logger.LogCritical("I am critical log");
            return Ok();
        }

    }
}
