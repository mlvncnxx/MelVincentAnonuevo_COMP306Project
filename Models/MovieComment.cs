namespace MelVincentAnonuevo_COMP306Project.Models
{
    public partial class MovieComment
    {
        public int CommentId { get; set; }
        public int MovieId { get; set; }
        public string Text { get; set; } = null!;
        public string? PostedBy { get; set; }
        public DateTime PostedAt { get; set; }

        public virtual MovieInfo Movie { get; set; } = null!;
    }
}
