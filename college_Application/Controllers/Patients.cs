using college_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace college_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Patients : ControllerBase
    {
        [HttpGet]
        [Route("AllPatient")]
        public ActionResult<IEnumerable<PatientDTOs>> Getpateint()
        {
            var Detopatinet = PatientRipo.Patients.Select(s => new PatientDTOs() {
                id = s.id,
                name = s.name,
                address = s.address,
                sex = s.sex
            });
            //return Ok(PatientRipo.Patients);
            return Ok(Detopatinet);
        }

        [HttpGet("{Id:int}",Name ="GetByID")]
        public Patinets searchpatient(int Id)
        {
            return PatientRipo.Patients.Where(n => n.id == Id).FirstOrDefault();
        }



        [HttpDelete("{Id:int:min(1):max(20)}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult deletebyid(int Id)
        {
            var singlePatient = PatientRipo.Patients.FirstOrDefault(n => n.id == Id);
            if (singlePatient != null)
            {
                PatientRipo.Patients.Remove(singlePatient);
                return Ok();
            }
            return NotFound("ID is not exist");
        }


        [HttpPost("CreatePatient",Name ="CreatePatinet")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PatientDTOs> creatpatient([FromBody]PatientDTOs models)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int lastid = PatientRipo.Patients.LastOrDefault().id+1;
            if (models.age < 18)
            {
                return BadRequest("Age must be greater than 18");
            }
            //if (models.admissiondate<DateTime.Now)
            //{
            //    ModelState.AddModelError("Admission error", "Incorrect date");
            //    return BadRequest(ModelState);
            //}
            Patinets newpatient = new Patinets
            {
                id = lastid,
                name = models.name,
                address = models.address,
                sex = models.sex,
                age = models.age
            };
            PatientRipo.Patients.Add(newpatient);
        //return Ok(newpatient);
        //https://localhost:7203/api/Patients/CreatePatient/model.id 
        //must be pass the 201 status code
            return CreatedAtRoute("GetByID", new { id = models.id }, newpatient);
        }

        [HttpPut("Updating")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult UpdateAll([FromBody] PatientDTOs model)
        {
            if (model==null)
            {
                return BadRequest("No thing input");
            }
            var editpatient = PatientRipo.Patients.Where(n => n.id == model.id).FirstOrDefault();
            if (editpatient==null)
            {
                return NotFound("This iD patient not found");
            }
            editpatient.name = model.name;
            editpatient.address = model.address;
            editpatient.sex = model.sex;
            editpatient.emai = model.emai;
            return NoContent();
        }


        [HttpPatch("{Id}/Patching")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult PartialUpdate(int Id,[FromBody] JsonPatchDocument<PatientDTOs> patchmodel)
        {
            if (patchmodel == null)
            {
                return BadRequest("No thing input");
            }
            var editpatient = PatientRipo.Patients.Where(n => n.id == Id).FirstOrDefault();
            if (editpatient == null)
            {
                return NotFound("This iD patient not found");
            }
            var existingPatinet = new PatientDTOs
            {
                name = editpatient.name,
                address = editpatient.address,
                sex = editpatient.sex,
                emai = editpatient.emai
            };
            patchmodel.ApplyTo(existingPatinet,ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            editpatient.name = existingPatinet.name;
            editpatient.address = existingPatinet.address;  
            editpatient.sex = existingPatinet.sex;
            editpatient.emai = existingPatinet.emai;
            return NoContent();
        }

        [HttpGet]
        [Route("bysex/{Sex:alpha}", Name = "Bysex")]
        public Patinets getpatientbysex(char Sex)
        {
            return PatientRipo.Patients.Where(n => n.sex == Sex).FirstOrDefault();
        }

        [HttpGet("exit/{Name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult ExitsOrNot(string Name)
        {
            var pat = PatientRipo.Patients.Where(n => n.name == Name).FirstOrDefault();
            if (pat != null)
            {
                return Ok("Successfully");
            }
            else
            {
                return NotFound("fail");
            }
        }
        [HttpGet]
        [Route("name/{name:alpha}", Name = "GetPatientByName")]
        public ActionResult<Patinets> getbyname(string name)
        {
            return Ok(PatientRipo.Patients.Where(n => n.name == name).FirstOrDefault());
        }
        private ActionResult<Patinets> ok(Patinets? patinets)
        {
            throw new NotImplementedException();
        }

    }
}
