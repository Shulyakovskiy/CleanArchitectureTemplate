using System.Collections.Generic;
using System.Threading.Tasks;
using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        Task<List<Command>> GetAllCommands();
        Task<Command> GetCommandById(int id);
        void CreateCommand(Command command);
    }
}