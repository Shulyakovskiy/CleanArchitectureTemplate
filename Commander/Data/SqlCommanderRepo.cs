using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }
        

        public Task<List<Command>> GetAllCommands()
        {
            return _context.Commands.ToListAsync();
        }

        public Task<Command> GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefaultAsync(c => c.Id == id);
        }

        public void CreateCommand(Command command)
        {
           if(command==null)
               throw new ArgumentNullException(nameof(command));
           _context.Commands.Add(command);
           _context.SaveChanges();
        }
    }
}