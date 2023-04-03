namespace MelVincentAnonuevo_COMP306Project.Models
{
    public partial class GameRating
    {
        public int RatingId { get; set; }
        public int GameId { get; set; }
        public int? Score { get; set; }

        public virtual GameInfo Game { get; set; } = null!;
    }
}
