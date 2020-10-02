using ApiPractice.Models;
using System.Collections.Generic;

namespace ApiPractice.Data
{
    public interface IApiPracticeRepo //interface that defines methods for the mock repo but doen't implement them
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int Id);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);
    }
}
