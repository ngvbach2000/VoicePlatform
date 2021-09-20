using Entity.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Entity.Contexts
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<ArtistCountry> ArtistCountries { get; set; }
        public virtual DbSet<ArtistVoiceDemo> ArtistVoiceDemos { get; set; }
        public virtual DbSet<ArtistVoiceStyle> ArtistVoiceStyles { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerProject> CustomerProjects { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectCountry> ProjectCountries { get; set; }
        public virtual DbSet<ProjectGender> ProjectGenders { get; set; }
        public virtual DbSet<ProjectVoiceStyle> ProjectVoiceStyles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VoiceDemo> VoiceDemos { get; set; }
        public virtual DbSet<VoiceStyle> VoiceStyles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("Artist");

                entity.HasIndex(e => e.Username, "UQ__Artist__536C85E44D8D4EC4")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "UQ__Artist__5C7E359E7D2307AC")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Artist__A9D105345100D585")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Avatar)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Bio)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Artists)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Artist__GenderId__31EC6D26");

                entity.HasOne(d => d.UpdateByNavigation)
                    .WithMany(p => p.Artists)
                    .HasForeignKey(d => d.UpdateBy)
                    .HasConstraintName("FK__Artist__UpdateBy__32E0915F");
            });

            modelBuilder.Entity<ArtistCountry>(entity =>
            {
                entity.HasKey(e => new { e.ArtisId, e.CountryId })
                    .HasName("PK__ArtistCo__AEC660EFE40185E1");

                entity.ToTable("ArtistCountry");

                entity.HasOne(d => d.Artis)
                    .WithMany(p => p.ArtistCountries)
                    .HasForeignKey(d => d.ArtisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArtistCou__Artis__3C69FB99");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.ArtistCountries)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArtistCou__Count__3D5E1FD2");
            });

            modelBuilder.Entity<ArtistVoiceDemo>(entity =>
            {
                entity.HasKey(e => new { e.ArtistId, e.VoiceDemoId })
                    .HasName("PK__ArtistVo__F97D9A3E2C3AAE62");

                entity.ToTable("ArtistVoiceDemo");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.ArtistVoiceDemos)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArtistVoi__Artis__5070F446");

                entity.HasOne(d => d.VoiceDemo)
                    .WithMany(p => p.ArtistVoiceDemos)
                    .HasForeignKey(d => d.VoiceDemoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArtistVoi__Voice__5165187F");
            });

            modelBuilder.Entity<ArtistVoiceStyle>(entity =>
            {
                entity.HasKey(e => new { e.ArtistId, e.VoiceStyleId })
                    .HasName("PK__ArtistVo__262BCF6E36FAFFF8");

                entity.ToTable("ArtistVoiceStyle");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.ArtistVoiceStyles)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArtistVoi__Artis__5629CD9C");

                entity.HasOne(d => d.VoiceStyle)
                    .WithMany(p => p.ArtistVoiceStyles)
                    .HasForeignKey(d => d.VoiceStyleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArtistVoi__Voice__571DF1D5");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasIndex(e => e.Username, "UQ__Customer__536C85E4000C5AF1")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "UQ__Customer__5C7E359EDC621C04")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Customer__A9D105345332831C")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Avatar)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Bio)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customer__Gender__38996AB5");

                entity.HasOne(d => d.UpdateByNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UpdateBy)
                    .HasConstraintName("FK__Customer__Update__398D8EEE");
            });

            modelBuilder.Entity<CustomerProject>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.CustomerId })
                    .HasName("PK__Customer__EC5058BD48E73FAD");

                entity.ToTable("CustomerProject");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerProjects)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerP__Custo__4BAC3F29");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.CustomerProjects)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerP__Proje__4AB81AF0");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Comment).HasMaxLength(256);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.HasOne(d => d.PosterNavigation)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.Poster)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Project__Poster__403A8C7D");
            });

            modelBuilder.Entity<ProjectCountry>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.CountryId })
                    .HasName("PK__ProjectC__9717A8F9AF8F0916");

                entity.ToTable("ProjectCountry");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.ProjectCountries)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectCo__Count__47DBAE45");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectCountries)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectCo__Proje__46E78A0C");
            });

            modelBuilder.Entity<ProjectGender>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.GenderId })
                    .HasName("PK__ProjectG__12F8F06F35E59EF5");

                entity.ToTable("ProjectGender");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.ProjectGenders)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectGe__Gende__440B1D61");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectGenders)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectGe__Proje__4316F928");
            });

            modelBuilder.Entity<ProjectVoiceStyle>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.VoiceStyleId })
                    .HasName("PK__ProjectV__75411ACE473D96FE");

                entity.ToTable("ProjectVoiceStyle");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectVoiceStyles)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectVo__Proje__59FA5E80");

                entity.HasOne(d => d.VoiceStyle)
                    .WithMany(p => p.ProjectVoiceStyles)
                    .HasForeignKey(d => d.VoiceStyleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectVo__Voice__5AEE82B9");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Username, "UQ__User__536C85E4B880B709")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "UQ__User__5C7E359EF176798D")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__User__A9D105343BDE7EEA")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Avatar)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Bio)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__GenderId__2B3F6F97");

                entity.HasOne(d => d.UpdateByNavigation)
                    .WithMany(p => p.InverseUpdateByNavigation)
                    .HasForeignKey(d => d.UpdateBy)
                    .HasConstraintName("FK__User__UpdateBy__2C3393D0");
            });

            modelBuilder.Entity<VoiceDemo>(entity =>
            {
                entity.ToTable("VoiceDemo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<VoiceStyle>(entity =>
            {
                entity.ToTable("VoiceStyle");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
