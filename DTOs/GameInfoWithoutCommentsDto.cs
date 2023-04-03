namespace MelVincentAnonuevo_COMP306Project.DTOs
{
    public class GameInfoWithoutCommentsDto
    {
        public int GameId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int? AvgRating { get; set; }
        public string Publisher { get; set; } = null!;
    }
}
