using MelVincentAnonuevo_COMP306Project.Models;

namespace MelVincentAnonuevo_COMP306Project.Services
{
    public interface IGameInfoRepository
    {
        Task<IEnumerable<GameInfo>> GetGameInfoes();

        Task<GameInfo> GetGameInfoById(int GameId, bool includeComments);

        Task<GameInfo> AddGameInfo(GameInfo gameInfo);

        Task UpadateGameInfo(int gameId, GameInfo gameInfo);

        Task DeleteGameInfo(int gameId);

        Task<bool> Save();

    }
}
