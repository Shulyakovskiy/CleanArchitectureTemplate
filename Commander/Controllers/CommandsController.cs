using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : Controller
    {
        private readonly ICommanderRepo _repoCommanderRepo;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo commanderRepo, IMapper mapper)
        {
            _repoCommanderRepo = commanderRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommandReadDto>>> GetAllCommands()
        {
            var commandItems = await _repoCommanderRepo.GetAllCommands();
            return Ok(_mapper.Map<List<CommandReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "GetCommandsById")]
        public async Task<ActionResult<CommandReadDto>> GetCommandsById(int id)
        {
            var commandItem = await _repoCommanderRepo.GetCommandById(id);
            if (commandItem != null)
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand([FromBody] CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repoCommanderRepo.CreateCommand(commandModel);

            return CreatedAtRoute(nameof(GetCommandsById), new {Id = commandModel.Id}, commandModel);
        }
    }
}