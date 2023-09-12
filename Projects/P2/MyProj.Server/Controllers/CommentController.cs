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
    public class CommentController : ControllerBase
    {
        private Repository _rpContext;
        public CommentController(Repository rpContext)
        {
            _rpContext = rpContext;
        }

        [HttpGet("{id}/comments")]
        public async Task<IEnumerable<Comment>> GetComments(long id)
        => await _rpContext.LoadComments(id);
        
        [HttpPost("{id}/add")]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            await _rpContext.AddComment(comment);
            return Ok();
        }
        
        [HttpDelete("{id}/delete")]
        public async Task<ActionResult<Comment>> DeleteComment(long id)
        {
            try{
               await _rpContext.RemoveComment(id);
            }
            catch(Exception e){
                return NotFound(e.Message);
            }
            return Ok();
        }
    }
}