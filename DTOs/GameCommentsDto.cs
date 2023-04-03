namespace MelVincentAnonuevo_COMP306Project.DTOs
{
    public class GameCommentsDto
    {
        public int CommentId { get; set; }
        public int GameId { get; set; }
        public string Text { get; set; } = null!;
        public string? PostedBy { get; set; }
        public DateTime PostedAt { get; set; }
    }
}
