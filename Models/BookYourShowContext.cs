using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookYourShow.Models
{
    public partial class BookYourShowContext : DbContext
    {
        public BookYourShowContext()
        {
        }

        public BookYourShowContext(DbContextOptions<BookYourShowContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actors> Actors { get; set; }
        public virtual DbSet<Casts> Casts { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Crew> Crew { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<Likes> Likes { get; set; }
        public virtual DbSet<MovieCrew> MovieCrew { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Offers> Offers { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<Seats> Seats { get; set; }
        public virtual DbSet<ShowTime> ShowTime { get; set; }
        public virtual DbSet<Theatre> Theatre { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("ConStr");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actors>(entity =>
            {
                entity.HasKey(e => e.ActorId)
                    .HasName("PK__Actors__57B3EA4BDC75B0F6");

                entity.Property(e => e.ActorName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Casts>(entity =>
            {
                entity.HasKey(e => e.CastId)
                    .HasName("PK__Casts__68A1293C8F80C1F7");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.Casts)
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("FK__Casts__ActorId__5070F446");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Casts)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__Casts__MovieId__5165187F");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Zipcode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Crew>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK__Crew__0CF04B1802C279C1");

                entity.Property(e => e.MemberName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.HasKey(e => e.GenreId)
                    .HasName("PK__Genres__0385057E6CDD63B9");

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Languages>(entity =>
            {
                entity.HasKey(e => e.LangId)
                    .HasName("PK__Language__A5F312DEBD731D28");

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Likes>(entity =>
            {
                entity.HasKey(e => e.LikeId)
                    .HasName("PK__Likes__A2922C14BA954DC8");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__Likes__MovieId__5812160E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Likes__UserId__59063A47");
            });

            modelBuilder.Entity<MovieCrew>(entity =>
            {
                entity.Property(e => e.RoleName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MovieCrew)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__MovieCrew__Membe__5BE2A6F2");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieCrew)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__MovieCrew__Movie__5CD6CB2B");
            });

            modelBuilder.Entity<Movies>(entity =>
            {
                entity.HasKey(e => e.MovieId)
                    .HasName("PK__Movies__4BD2941A1946E1B8");

                entity.Property(e => e.MovieDesc)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.MovieRelease)
                    .HasColumnName("movieRelease")
                    .HasColumnType("date");

                entity.Property(e => e.MovieTitle)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK__Movies__GenreId__3F466844");

                entity.HasOne(d => d.Lang)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.LangId)
                    .HasConstraintName("FK__Movies__LangId__3E52440B");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.OfferId)
                    .HasConstraintName("FK__Movies__OfferId__403A8C7D");
            });

            modelBuilder.Entity<Offers>(entity =>
            {
                entity.HasKey(e => e.OfferId)
                    .HasName("PK__Offers__8EBCF0911C9CBD75");

                entity.Property(e => e.OfferDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OfferName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(e => e.PaymentInfo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.ShowTime)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.ShowTimeId)
                    .HasConstraintName("FK__Reservati__ShowT__48CFD27E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Reservati__UserI__49C3F6B7");
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.HasKey(e => e.ReviewId)
                    .HasName("PK__Reviews__74BC79CEDD3A1742");

                entity.Property(e => e.ReviewId).ValueGeneratedOnAdd();

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Review)
                    .WithOne(p => p.Reviews)
                    .HasForeignKey<Reviews>(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_MovieId");
            });

            modelBuilder.Entity<Seats>(entity =>
            {
                entity.HasKey(e => e.SeatId)
                    .HasName("PK__Seats__311713F3324ACEF3");

                entity.Property(e => e.Row)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.Seats)
                    .HasForeignKey(d => d.ReservationId)
                    .HasConstraintName("FK__Seats__Reservati__4CA06362");

                entity.HasOne(d => d.Theatre)
                    .WithMany(p => p.Seats)
                    .HasForeignKey(d => d.TheatreId)
                    .HasConstraintName("FK__Seats__TheatreId__4D94879B");
            });

            modelBuilder.Entity<ShowTime>(entity =>
            {
                entity.Property(e => e.ShowTimeStart).HasColumnType("datetime");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.ShowTime)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__ShowTime__MovieI__45F365D3");

                entity.HasOne(d => d.Theatre)
                    .WithMany(p => p.ShowTime)
                    .HasForeignKey(d => d.TheatreId)
                    .HasConstraintName("FK__ShowTime__Theatr__44FF419A");
            });

            modelBuilder.Entity<Theatre>(entity =>
            {
                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TheatreName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Theatre)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__Theatre__CityId__2F10007B");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CC4C980904D4");

                entity.Property(e => e.ContactNumber).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
