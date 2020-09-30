using ApiPractice.Models;
using System.Collections.Generic;

namespace ApiPractice.Data
{
    interface IApiPracticeRepo //interface that defines methods for the mock repo but doen't implement them
    {
        IEnumerable<Command> GetAppCommands();
        Command GetCommandById(int Id);
    }
}
