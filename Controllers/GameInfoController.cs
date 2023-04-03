using MelVincentAnonuevo_COMP306Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace MelVincentAnonuevo_COMP306Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameInfoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IGameInfoRepository _gameInfoRepository;

        public GameInfoController(IGameInfoRepository gameInfoRepostory, IMapper mapper)
        {
            _gameInfoRepository = gameInfoRepostory;
            _mapper = mapper;
        }

        //GET: api<controller>
        [HttpGet]
        public async Task<ActionResult<GameInfo>> GetGameInfoes()
        {
            var gameEntities = await _gameInfoRepository.GetGameInfoes();
            var results = _mapper.Map<IEnumerable<GameInfoWithoutCommentsDto>>(gameEntities);

            return Ok(results);
        }

        // GET: api/GameInfo/1
        [HttpGet("{gameId}")]
        public async Task<ActionResult> GetGameInfoById(int gameId)
        {
            var game = await _gameInfoRepository.GetGameInfoById(gameId, true);

            if (game == null)
            {
                return NotFound();
            }

            var gameWithoutCommentsResult = _mapper.Map<GameInfoWithoutCommentsDto>(game);

            return Ok(gameWithoutCommentsResult);
        }

        // POST api/GameInfo
        [HttpPost]
        public async Task<ActionResult> AddGameInfo([FromBody] GameInfoWithoutCommentsDto gameInfo)
        {
            if (gameInfo == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var gameToInsert = _mapper.Map<GameInfo>(gameInfo);

            var gameInserted = await _gameInfoRepository.AddGameInfo(gameToInsert);

            if (!await _gameInfoRepository.Save())
            {
                return StatusCode(500, "A problem occured while processing the request");
            }

            var createdGameToReturn = _mapper.Map<GameInfoWithoutCommentsDto>(gameToInsert);

            return CreatedAtAction(nameof(GetGameInfoById), new { gameId = createdGameToReturn.GameId, includeComments = false }, createdGameToReturn);
        }


        // PUT api/GameInfo/1
        [HttpPut("{gameId}")]
        public async Task<ActionResult> UpadateGameInfo(int gameId, [FromBody] GameInfoWithoutCommentsDto gameInfo)
        {
            if (gameInfo == null) return BadRequest();

            var gameToUpdate = _mapper.Map<GameInfo>(gameInfo);
            await _gameInfoRepository.UpadateGameInfo(gameId, gameToUpdate);

            return Ok(gameToUpdate);
        }

        // PUT api/GameInfo/1
        [HttpPatch("{gameId}")]
        public async Task<ActionResult> UpadateGameInfobyId(int gameId, [FromBody] GameInfoWithoutCommentsDto gameInfo)
        {
            if (gameInfo == null) return BadRequest();

            var gameToUpdate = _mapper.Map<GameInfo>(gameInfo);
            await _gameInfoRepository.UpadateGameInfo(gameId, gameToUpdate);

            return Ok(gameToUpdate);
        }

        // DELETE api/GameInfo/2
        [HttpDelete("{gameId}")]
        public async Task<ActionResult> DeleteGameInfo(int gameId)
        {
            GameInfo game = await _gameInfoRepository.GetGameInfoById(gameId, false);

            if (game == null)
            {
                return NotFound();
            }

            await _gameInfoRepository.DeleteGameInfo(gameId);

            return Ok(game);
        }
    }
}
