using System.Collections.Generic;
using System.Threading.Tasks;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Command>> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command {Id = 0, HowTo = "Boil and egg", Line = "boil water", Platform = "Kettle & Pan"},
                new Command {Id = 1, HowTo = "Cut bread", Line = "boil water", Platform = "Board"},
                new Command {Id = 2, HowTo = "Make Cup", Line = "boil water", Platform = "Cup"}
            };
            return commands;
        }

        public async Task<Command> GetCommandById(int id)
        {
            var command = new Command
            {
                Id = 0, HowTo = "Boil and egg...", Line = "boil water", Platform = "Kettle & Pan"
            };
            return command;
        }

        public void CreateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }
    }
}