using ApiPractice.Data;
using ApiPractice.Dtos;
using ApiPractice.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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

        //GET api/Commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        //GET api/Commands/{id}
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

        //POST api/Commands
        [HttpPost]
        public ActionResult<Command> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            return CreatedAtAction(nameof(GetCommandById), new { Id = commandModel.Id }, commandModel);
        }
        
        //PUT api/Commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id,CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo); //doesn't do anything but if implementation changes it is already here
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/Commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandById(id); //get command from repo if its there
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo); //change Command object to CommandUpdateDto object 
            patchDoc.ApplyTo(commandToPatch, ModelState); // Apply the patch to the command

            if (!TryValidateModel(commandToPatch)) //check if its still a valid command
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo); //apply the new command and save it
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/Commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id); //get command from repo if its there
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
