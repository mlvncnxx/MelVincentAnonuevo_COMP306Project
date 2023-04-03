using MelVincentAnonuevo_COMP306Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace MelVincentAnonuevo_COMP306Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameRatingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IGameRatingRepository _gameRatingRepository;
        private IGameInfoRepository _gameInfoRepository;

        public GameRatingController(IGameRatingRepository gameRatingRepository, IGameInfoRepository gameInfoRepository, IMapper mapper)
        {
            _gameRatingRepository = gameRatingRepository;
            _gameInfoRepository = gameInfoRepository;
            _mapper = mapper;
        }

        // GET: /GameRating/1
        [HttpGet("{gameId}")]
        public async Task<ActionResult> GetGameRatingByGameId(int gameId)
        {
            var ratings = await _gameRatingRepository.GetGameRatingByGameId(gameId);

            var results = _mapper.Map<IEnumerable<GameRatingDto>>(ratings);

            return Ok(results);
        }

        [HttpPost]
        public async Task<ActionResult> AddGameRating(GameRatingDto rating)
        {
            if (rating == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var ratingToInsert = _mapper.Map<GameRating>(rating);

            await _gameRatingRepository.AddGameRating(ratingToInsert);
            //var ratings = await _gameRatingRepository.GetGameRatingByGameId(rating.GameId);

            if (!await _gameRatingRepository.Save())
            {
                return StatusCode(500, "A problem occured while processing the request");
            }

            var gameInfo = _gameInfoRepository.GetGameInfoById(rating.GameId, false);

            return StatusCode(200, "Rating is submitted successfully.");
        }

        [HttpPut("{ratingId}")]
        public async Task<ActionResult> UpadateGameRating(int ratingId, GameRatingDto rating)
        {
            if (rating == null) return BadRequest();

            var ratingToUpdate = _mapper.Map<GameRating>(rating);

            await _gameRatingRepository.UpadateGameRating(ratingId, ratingToUpdate);
            var ratings = await _gameRatingRepository.GetGameRatingByGameId(rating.GameId);


            return StatusCode(200, "Comment is updated successfully.");
        }

    }
}
