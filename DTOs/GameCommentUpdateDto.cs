namespace MelVincentAnonuevo_COMP306Project.DTOs
{
    public class GameCommentUpdateDto
    {
        public int CommentId { get; set; }
        public string Text { get; set; } = null!;
        public string? PostedBy { get; set; }
    }
}
