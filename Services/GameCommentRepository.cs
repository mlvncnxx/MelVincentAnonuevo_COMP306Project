using MelVincentAnonuevo_COMP306Project.Models;
using Microsoft.EntityFrameworkCore;

namespace MelVincentAnonuevo_COMP306Project.Services
{
    public class GameCommentRepository : IGameCommentRepository
    {
        private MelVincentDBContext _context;

        public GameCommentRepository(MelVincentDBContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<GameComment>> GetGameComments()
        {
            var result = _context.GameComments.OrderBy(g => g.CommentId);
            return await result.ToListAsync();
        }

        public async Task<IEnumerable<GameComment>> GetGameCommentByGameId(int gameInfoId)
        {
            IQueryable<GameComment> result = _context.GameComments.Where(g => g.GameId == gameInfoId);
            return await result.ToListAsync();
        }

        public async Task<GameComment> GetGameCommentByCommentId(int commentId)
        {
            return await _context.GameComments.Where(c => c.CommentId == commentId).FirstOrDefaultAsync();
        }

        public async Task<GameComment> AddGameComment(GameComment gameComment)
        {
            await _context.GameComments.AddAsync(gameComment);
            _context.Entry(gameComment).GetDatabaseValues();

            return gameComment;
        }

        public async Task<bool> Save()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }



        public async Task UpadateGameComment(int commentId, GameComment gameComment)
        {
            GameComment gameCoomentToUpdate = await _context.GameComments.SingleOrDefaultAsync(g => g.CommentId == commentId);
            GameComment newGameCooment = new GameComment();
            if (gameCoomentToUpdate != null)
            {
                newGameCooment.CommentId = gameCoomentToUpdate.CommentId;
                newGameCooment.GameId = gameCoomentToUpdate.GameId;
                newGameCooment.Text = gameComment.Text;
                newGameCooment.PostedBy = gameComment.PostedBy;
                newGameCooment.PostedAt = gameComment.PostedAt;
                _context.Entry(gameCoomentToUpdate).CurrentValues.SetValues(newGameCooment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteGameComment(int commentId)
        {
            GameComment commentToRemove = await _context.GameComments.SingleOrDefaultAsync(g => g.CommentId == commentId);

            if (commentToRemove != null)
            {
                _context.GameComments.Remove(commentToRemove);
                await _context.SaveChangesAsync();
            }
        }
    }
}
