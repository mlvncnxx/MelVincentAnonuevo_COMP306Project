using Microsoft.EntityFrameworkCore;

namespace MelVincentAnonuevo_COMP306Project.Models
{
    public partial class MelVincentDBContext : DbContext
    {
        public MelVincentDBContext()
        {
        }

        public MelVincentDBContext(DbContextOptions<MelVincentDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GameComment> GameComments { get; set; } = null!;
        public virtual DbSet<GameInfo> GameInfos { get; set; } = null!;
        public virtual DbSet<GameRating> GameRatings { get; set; } = null!;
        public virtual DbSet<MovieComment> MovieComments { get; set; } = null!;
        public virtual DbSet<MovieInfo> MovieInfos { get; set; } = null!;
        public virtual DbSet<MovieRating> MovieRatings { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;


        public override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MelVincentDB;Trusted_Connection=True;");
            }
        }

    }
}
