using ApiPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPractice.Data
{
    public interface IApiPracticeRepo //interface that defines methods for the mock repo but doen't implement them
    {
        IEnumerable<Command> GetAppCommands();
        Command GetCommandById(int Id);
    }
}
