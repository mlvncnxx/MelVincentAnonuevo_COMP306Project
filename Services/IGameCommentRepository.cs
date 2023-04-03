using MelVincentAnonuevo_COMP306Project.Models;

namespace MelVincentAnonuevo_COMP306Project.Services
{
    public interface IGameCommentRepository
    {
        Task<IEnumerable<GameComment>> GetGameComments();

        Task<IEnumerable<GameComment>> GetGameCommentByGameId(int gameId);

        Task<GameComment> GetGameCommentByCommentId(int commentId);

        Task<GameComment> AddGameComment(GameComment gameComment);

        Task UpadateGameComment(int commentId, GameComment gameComment);

        Task DeleteGameComment(int commentId);

        Task<bool> Save();
    }
}
