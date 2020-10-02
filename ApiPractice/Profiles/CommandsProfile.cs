using ApiPractice.Dtos;
using ApiPractice.Models;
using AutoMapper;

namespace ApiPractice.Profiles
{
    public class CommandsProfile : Profile //Profile is available through automapper 
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandReadDto>(); //maps command objects to Dtos
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}
