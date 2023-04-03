using MelVincentAnonuevo_COMP306Project.Models;
using Microsoft.EntityFrameworkCore;

namespace MelVincentAnonuevo_COMP306Project.Services
{
    public class GameRatingRepository : IGameRatingRepository
    {
        private MelVincentDBContext _context;

        public GameRatingRepository(MelVincentDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GameRating>> GetGameRatingByGameId(int gameId)
        {
            IQueryable<GameRating> result = _context.GameRatings.Where(g => g.GameId == gameId);
            return await result.ToListAsync();
        }

        public async Task<GameRating> GetGameRatingByRatingId(int ratingId)
        {
            return await _context.GameRatings.Where(c => c.RatingId == ratingId).FirstOrDefaultAsync();
        }

        public async Task<GameRating> AddGameRating(GameRating gameRating)
        {
            await _context.GameRatings.AddAsync(gameRating);
            _context.Entry(gameRating).GetDatabaseValues();
            var average = (int)_context.GameRatings.Where(g => g.GameId == gameRating.GameId).Select(g => g.Score).Average();
            var gameInfo = await _context.GameInfos.SingleOrDefaultAsync(g => g.GameId == gameRating.GameId);
            gameInfo.AvgRating = average;
            _context.Entry(gameInfo).CurrentValues.SetValues(gameInfo);

            return gameRating;
        }

        public async Task<bool> Save()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }



        public async Task UpadateGameRating(int ratingId, GameRating gameRating)
        {
            GameRating gameRatingToUpdate = await _context.GameRatings.SingleOrDefaultAsync(g => g.RatingId == ratingId);
            GameRating newGameRating = new GameRating();
            if (gameRatingToUpdate != null)
            {
                newGameRating.GameId = gameRatingToUpdate.GameId;
                newGameRating.RatingId = gameRatingToUpdate.RatingId;
                newGameRating.Score = gameRating.Score;
                _context.Entry(gameRatingToUpdate).CurrentValues.SetValues(newGameRating);

                var average = (int)_context.GameRatings.Where(g => g.GameId == gameRating.GameId).Select(g => g.Score).Average();
                var gameInfo = await _context.GameInfos.SingleOrDefaultAsync(g => g.GameId == gameRating.GameId);
                gameInfo.AvgRating = average;
                _context.Entry(gameInfo).CurrentValues.SetValues(gameInfo);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> getAverageRating(int gameId, GameRating gameRating)
        {
            var average = (int)_context.GameRatings.Where(g => g.GameId == gameRating.GameId).Select(g => g.Score).Average();
            var gameInfo = await _context.GameInfos.SingleOrDefaultAsync(g => g.GameId == gameRating.GameId);
            gameInfo.AvgRating = average;
            _context.Entry(gameInfo).CurrentValues.SetValues(gameInfo);
            await _context.SaveChangesAsync();
            return (int)average;
        }
    }
}
