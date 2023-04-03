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


       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=database-1.ce8lqueajana.us-east-1.rds.amazonaws.com,1433;database=JoshuaKunwooDB;User ID=admin;Password=password;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameComment>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK__GameComm__C3B4DFCAA436433F");

                entity.Property(e => e.CommentId).ValueGeneratedNever();

                entity.Property(e => e.PostedAt).HasColumnType("date");

                entity.Property(e => e.PostedBy).HasMaxLength(50);

                entity.Property(e => e.Text).HasMaxLength(500);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameComments)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GameComme__GameI__3F466844");
            });

            modelBuilder.Entity<GameInfo>(entity =>
            {
                entity.HasKey(e => e.GameId)
                    .HasName("PK__GameInfo__2AB897FDC64EAB45");

                entity.ToTable("GameInfo");

                entity.Property(e => e.GameId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Publisher).HasMaxLength(50);

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<GameRating>(entity =>
            {
                entity.HasKey(e => e.RatingId)
                .HasName("FK__GameRatin__C3B4DFCAA436433F");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.HasOne(d => d.Game)
                    .WithMany()
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GameRatin__GameI__4316F928");
            });

            modelBuilder.Entity<MovieComment>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK__MovieCom__C3B4DFCAD56F8250");

                entity.Property(e => e.CommentId).ValueGeneratedNever();

                entity.Property(e => e.PostedAt).HasColumnType("date");

                entity.Property(e => e.PostedBy).HasMaxLength(50);

                entity.Property(e => e.Text).HasMaxLength(500);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieComments)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MovieComm__Movie__3C69FB99");
            });

            modelBuilder.Entity<MovieInfo>(entity =>
            {
                entity.HasKey(e => e.MovieId)
                    .HasName("PK__MovieInf__4BD2941AF74C17EB");

                entity.ToTable("MovieInfo");

                entity.Property(e => e.MovieId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Director).HasMaxLength(50);

                entity.Property(e => e.Genre).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<MovieRating>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Score).HasColumnName("score");

                entity.HasOne(d => d.Movie)
                      .WithMany()
                      .HasForeignKey(d => d.MovieId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK__MovieRati__Movie__412EB0B6");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__Users__C9F28457C0507541");

                entity.Property(e => e.UserName).HasMaxLength(20);

                entity.Property(e => e.Password).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}

