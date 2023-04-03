namespace MelVincentAnonuevo_COMP306Project.Models
{
    public partial class MovieInfo
    {
        public MovieInfo()
        {
            MovieComments = new HashSet<MovieComment>();
        }

        public int MovieId { get; set; }
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public string Director { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public string? Description { get; set; }
        public int? AvgRating { get; set; }

        public virtual ICollection<MovieComment> MovieComments { get; set; }
    }
}
