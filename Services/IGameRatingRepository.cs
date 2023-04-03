using MelVincentAnonuevo_COMP306Project.Models;

namespace MelVincentAnonuevo_COMP306Project.Services
{
    public interface IGameRatingRepository
    {
        Task<IEnumerable<GameRating>> GetGameRatingByGameId(int gameId);

        Task<GameRating> GetGameRatingByRatingId(int ratingId);

        Task<GameRating> AddGameRating(GameRating gameRating);

        Task UpadateGameRating(int ratingId, GameRating gameRating);

        Task<bool> Save();
        Task<int> getAverageRating(int gameId, GameRating gameRating);



    }
}
