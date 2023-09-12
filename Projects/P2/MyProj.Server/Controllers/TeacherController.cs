using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyProj.Shared.Data;
using MyProj.Server.Repositories;

namespace MyProj.Server.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class TeacherController : ControllerBase
    {
        private Repository _rpContext;
        public TeacherController(Repository rpContext)
        {
            _rpContext = rpContext;
        }

        [HttpGet("schools")]
        public async Task<IEnumerable<string>> GetSchools()
        => await _rpContext.AllSchools();

        [HttpGet("{school}/teachers")]
        public async Task<IEnumerable<Professor>> GetTeachers(string school)
        => await _rpContext.Teachers(school);
        [HttpGet("{school}/{name}")]
        public Professor GetTeacher(string school ,string name)
        => _rpContext.FindTeacher(name, school);
        
        [HttpPut("{id}/rate")]
        public ActionResult<Professor> UpdateTeacher(long id, Rate rate)
        {
            _rpContext.RateTeacher(id, rate);
            return Ok();
        }
    }
}