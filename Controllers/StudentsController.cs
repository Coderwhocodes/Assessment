using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using try2.Model;

namespace try2.Controllers
{
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private Data.IStuData _studentData;

        public StudentsController(Data.IStuData stuData)
        {
            _studentData = stuData;
        }


        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetStudents()
        {
            return Ok(_studentData.GetStudents());
        }


        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _studentData.GetStudent(id);

            if (student != null)
            {
                return Ok(student);

            }
            return NotFound($"Student with id: {id} not found");
        }


        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddStudent(Model.Student student)
        {
            _studentData.AddStudent(student);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + student.Id, student); ;
        }

        
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _studentData.GetStudent(id);

            if (student != null)
            {
                _studentData.DeleteStudent(student);
                return Ok();
            }
            return NotFound($"Student with id: {id} not found");
        }
        
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            var existingStudent = _studentData.GetStudent(id);

            if (existingStudent != null)
            {
                student.Id = existingStudent.Id;
                _studentData.UpdateStudent(student);
            }
            return Ok(student);


        }
    }
}
