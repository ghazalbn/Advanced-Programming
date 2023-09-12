using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyProj.Shared.Data;
using MyProj.Server.Repositories;
using System.Net.Http;

namespace MyProj.Server.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class BookletController : ControllerBase
    {
        private Repository _rpContext;
        public BookletController(Repository rpContext)
        {
            _rpContext = rpContext;
        }

        [HttpGet("{school}/lessons")]
        public async Task<IEnumerable<string>> GetLessons(string school)
        => await _rpContext.Lessonss(school);
        [HttpGet("{lesson}/booklets")]
        public async Task<IEnumerable<Booklet>> GetBooklets(string lesson)
        => await _rpContext.Booklets(lesson);
        // [HttpPost("{lesson}/add")]
        // public async Task<ActionResult> PostBooklet(MultipartFormDataContent file)
        // {
        //     await _rpContext.AddBooklet(file);
        //     return Ok();
        // }
    }
}