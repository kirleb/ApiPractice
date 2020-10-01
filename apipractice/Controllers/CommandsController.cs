using ApiPractice.Data;
using ApiPractice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiPractice.Controllers
{
    [Route("api/[controller]")] //can put it in explicitly and is probs better but leaving it to show
    [ApiController]
    public class CommandsController : ControllerBase   //the bit before Controller is [controller] == "Commands"
    {
        private readonly IApiPracticeRepo _repository;

        public CommandsController(IApiPracticeRepo repository) // ensure interface is public as default is internal
        {
            _repository = repository;
        }
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

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
