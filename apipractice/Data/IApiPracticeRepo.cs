using ApiPractice.Models;
using System.Collections.Generic;

namespace ApiPractice.Data
{
    interface IApiPracticeRepo
    {
        IEnumerable<Command> GetAppCommands();
        Command GetCommandById(int Id);
    }
}
