using ApiPractice.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApiPractice.Data
{
    public class SqlApiPracticeRepo : IApiPracticeRepo
    {
        private readonly ApiPracticeContext _context;

        public SqlApiPracticeRepo(ApiPracticeContext context)
        {
            _context = context;
        } 
        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id == id); //Id is the id in Commands id is the parameter
        }
    }
}
