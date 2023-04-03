namespace MelVincentAnonuevo_COMP306Project.Models
{
    public partial class GameInfo
    {
     
        public GameInfo()
        {
            GameComments = new HashSet<GameComment>();
        }

        public int GameId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int? AvgRating { get; set; }
        public string Publisher { get; set; } = null!;

        public virtual ICollection<GameComment>? GameComments { get; set; }

    }
}
