using MelVincentAnonuevo_COMP306Project.Models;
using Microsoft.EntityFrameworkCore;

namespace MelVincentAnonuevo_COMP306Project.Services
{
    public class GameInfoRepository : IGameInfoRepository
    {
        private MelVincentDBContext _context;

        public GameInfoRepository(MelVincentDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GameInfo>> GetGameInfoes()
        {
            var result = _context.GameInfos.OrderBy(g => g.ReleaseDate);
            return await result.ToListAsync();
        }

        public async Task<GameInfo> GetGameInfoById(int gamId, bool includeComments)
        {
            IQueryable<GameInfo> result;

            if (includeComments)
            {
                result = _context.GameInfos.Include(c => c.GameComments)
                .Where(c => c.GameId == gamId);
            }
            else result = _context.GameInfos.Where(c => c.GameId == gamId);

            return await result.FirstOrDefaultAsync();
        }

        public async Task<GameInfo> AddGameInfo(GameInfo gameInfo)
        {
            await _context.GameInfos.AddAsync(gameInfo);
            _context.Entry(gameInfo).GetDatabaseValues();

            return gameInfo;
        }

        public async Task<bool> Save()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task UpadateGameInfo(int gameId, GameInfo gameInfo)
        {
            GameInfo gameInfoToUpdate = await _context.GameInfos.SingleOrDefaultAsync(p => p.GameId == gameId);
            GameInfo newGameInfo = new GameInfo();
            if (gameInfoToUpdate != null)
            {
                newGameInfo.GameId = gameInfoToUpdate.GameId;
                newGameInfo.Title = gameInfo.Title;
                newGameInfo.Description = gameInfo.Description;
                newGameInfo.ReleaseDate = gameInfo.ReleaseDate;
                newGameInfo.AvgRating = gameInfo.AvgRating;
                newGameInfo.Publisher = gameInfo.Publisher;
                _context.Entry(gameInfoToUpdate).CurrentValues.SetValues(newGameInfo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteGameInfo(int gameId)
        {
            GameInfo petToRemove = await _context.GameInfos.SingleOrDefaultAsync(p => p.GameId == gameId);

            if (petToRemove != null)
            {
                _context.GameInfos.Remove(petToRemove);
                await _context.SaveChangesAsync();
            }
        }

    }
}
