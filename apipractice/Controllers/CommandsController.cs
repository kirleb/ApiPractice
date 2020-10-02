using ApiPractice.Data;
using ApiPractice.Dtos;
using ApiPractice.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem != null)
            {
                return Ok(commandItem);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<Command> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            return CreatedAtAction(nameof(GetCommandById), new { Id = commandModel.Id }, commandModel);
        }
        
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id,CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo); //doesn't do anything but implementation changes to use this it is already here
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
