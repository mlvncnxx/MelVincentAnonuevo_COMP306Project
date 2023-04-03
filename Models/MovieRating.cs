namespace MelVincentAnonuevo_COMP306Project.Models
{
    public partial class MovieRating
    {
        public int RatingId { get; set; }
        public int MovieId { get; set; }
        public int? Score { get; set; }

        public virtual MovieInfo Movie { get; set; } = null!;
    }
}
