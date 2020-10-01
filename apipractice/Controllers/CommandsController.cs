using ApiPractice.Data;
using ApiPractice.Dtos;
using ApiPractice.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiPractice.Controllers
{
    [Route("api/[controller]")] //can put it in explicitly and is probs better but leaving it to show
    [ApiController]
    public class CommandsController : ControllerBase   //the bit before Controller is [controller] == "Commands"
    {
        private readonly IApiPracticeRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(IApiPracticeRepo repository, IMapper mapper) // ensure interface is public as default is internal
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }
        
        [HttpGet("{id}")] // the id bit means the uri requested needs a number (as id is int type) on the end to call it
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if(commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            return NotFound();
        }
    }
}
