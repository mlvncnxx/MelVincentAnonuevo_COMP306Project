namespace MelVincentAnonuevo_COMP306Project.Models
{
    public partial class GameComment
    {
        public int CommentId { get; set; }
        public int GameId { get; set; }
        public string Text { get; set; } = null!;
        public string? PostedBy { get; set; }
        public DateTime PostedAt { get; set; }

        public virtual GameInfo Game { get; set; } = null!;
    }
}
