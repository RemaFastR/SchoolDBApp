using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolDBApp.DataBase;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolDBApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        ISchoolRepsitory repository;
        public SchoolController(ISchoolRepsitory repository)
        {
            this.repository = repository;
        }

        // GET: api/<SchoolController>
        [HttpGet]
        public List<Student> Get()
        {
            return repository.GetStudents();
        }

        // GET api/<SchoolController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            Student student = repository.Get(id);
            return student;
        }

        // POST api/<SchoolController>
        [HttpPost]
        public Student Post([FromBody] Student value)
        {
            repository.Create(value);
            return value;
        }

        // POST api/<SchoolController>/5
        [HttpPost("{id}")]
        public void Update(int id, [FromBody] Student value)
        {
            repository.Update(id, value);
        }

        // DELETE api/<SchoolController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Delete(id);
        }

        // GET api/<SchoolController>/calculate
        [HttpGet("calculate")]
        public int Calculate()
        {
            return repository.CalculateArithmeticMeanInThreeSubjects();
        }

        // GET api/<SchoolController>/search/secondName
        [HttpGet("search/{secondName}")]
        public List<Student> SearchStudents(string secondName)
        {
            return repository.SearchStudent(secondName);
        }

        // GET api/<SchoolController>/orderby
        [HttpGet("orderby")]
        public List<Student> OrderBySecName()
        {
            return repository.OrderBySecondName();
        }

        // GET api/<SchoolController>/sample
        [HttpGet("sample/{age}")]
        public List<Student> MakeASample(int age)
        {
            return repository.MakeASample(age);
        }
    }
}
