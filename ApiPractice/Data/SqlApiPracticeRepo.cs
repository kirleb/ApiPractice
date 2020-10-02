using ApiPractice.Models;
using System;
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


        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Add(cmd);
        }
        public void UpdateCommand(Command cmd)
        {
            //Nothing
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0); //executes save changes and returns true if successful
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Remove(cmd);
        }
    }
}
