using ApiPractice.Data;
using ApiPractice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiPractice.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly MockApiPracticeRepo _repository = new MockApiPracticeRepo();
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAppCommands();

            return Ok(commandItems);
        }
        
        [HttpGet("{id}")] // the id bit means the uri requested needs a number (as id is int type) on the end to call it
        public ActionResult <Command> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            return Ok(commandItem);
        }
    }
}
