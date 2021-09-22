using Microsoft.EntityFrameworkCore;
using VoicePlatform.Data.Entities;

#nullable disable

namespace VoicePlatform.Data.Contexts
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
        public virtual DbSet<ArtistProjectFile> ArtistProjectFiles { get; set; }
        public virtual DbSet<ArtistVoiceDemo> ArtistVoiceDemos { get; set; }
        public virtual DbSet<ArtistVoiceStyle> ArtistVoiceStyles { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerProject> CustomerProjects { get; set; }
        public virtual DbSet<CustomerProjectFile> CustomerProjectFiles { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectCountry> ProjectCountries { get; set; }
        public virtual DbSet<ProjectGender> ProjectGenders { get; set; }
        public virtual DbSet<ProjectUsagePurpose> ProjectUsagePurposes { get; set; }
        public virtual DbSet<ProjectVoiceStyle> ProjectVoiceStyles { get; set; }
        public virtual DbSet<UsagePurpose> UsagePurposes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VoiceDemo> VoiceDemos { get; set; }
        public virtual DbSet<VoiceStyle> VoiceStyles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("Artist");

                entity.HasIndex(e => e.Username, "UQ__Artist__536C85E4C6DFB7BB")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "UQ__Artist__5C7E359E58B307C9")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Artist__A9D10534CE495CD1")
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
                    .HasName("PK__ArtistCo__AEC660EF424DC915");

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

            modelBuilder.Entity<ArtistProjectFile>(entity =>
            {
                entity.ToTable("ArtistProjectFile");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Url).IsRequired();

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.ArtistProjectFiles)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArtistPro__Creat__49C3F6B7");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ArtistProjectFiles)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArtistPro__Proje__48CFD27E");
            });

            modelBuilder.Entity<ArtistVoiceDemo>(entity =>
            {
                entity.HasKey(e => new { e.ArtistId, e.VoiceDemoId })
                    .HasName("PK__ArtistVo__F97D9A3E178488A7");

                entity.ToTable("ArtistVoiceDemo");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.ArtistVoiceDemos)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArtistVoi__Artis__5DCAEF64");

                entity.HasOne(d => d.VoiceDemo)
                    .WithMany(p => p.ArtistVoiceDemos)
                    .HasForeignKey(d => d.VoiceDemoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArtistVoi__Voice__5EBF139D");
            });

            modelBuilder.Entity<ArtistVoiceStyle>(entity =>
            {
                entity.HasKey(e => new { e.ArtistId, e.VoiceStyleId })
                    .HasName("PK__ArtistVo__262BCF6ED6EDCF31");

                entity.ToTable("ArtistVoiceStyle");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.ArtistVoiceStyles)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArtistVoi__Artis__6383C8BA");

                entity.HasOne(d => d.VoiceStyle)
                    .WithMany(p => p.ArtistVoiceStyles)
                    .HasForeignKey(d => d.VoiceStyleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArtistVoi__Voice__6477ECF3");
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

                entity.HasIndex(e => e.Username, "UQ__Customer__536C85E47B5A5B30")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "UQ__Customer__5C7E359E50A0540D")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Customer__A9D10534974593B1")
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
                    .HasName("PK__Customer__EC5058BDB204B703");

                entity.ToTable("CustomerProject");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerProjects)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerP__Custo__59063A47");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.CustomerProjects)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerP__Proje__5812160E");
            });

            modelBuilder.Entity<CustomerProjectFile>(entity =>
            {
                entity.ToTable("CustomerProjectFile");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Url).IsRequired();

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.CustomerProjectFiles)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerP__Creat__4D94879B");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.CustomerProjectFiles)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerP__Proje__4CA06362");
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

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.MaxPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MinPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProjectDeadline).HasColumnType("datetime");

                entity.Property(e => e.ResponseDeadline).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.PosterNavigation)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.Poster)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Project__Poster__403A8C7D");
            });

            modelBuilder.Entity<ProjectCountry>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.CountryId })
                    .HasName("PK__ProjectC__9717A8F91FF310B7");

                entity.ToTable("ProjectCountry");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.ProjectCountries)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectCo__Count__5535A963");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectCountries)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectCo__Proje__5441852A");
            });

            modelBuilder.Entity<ProjectGender>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.GenderId })
                    .HasName("PK__ProjectG__12F8F06FF1718F6E");

                entity.ToTable("ProjectGender");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.ProjectGenders)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectGe__Gende__5165187F");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectGenders)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectGe__Proje__5070F446");
            });

            modelBuilder.Entity<ProjectUsagePurpose>(entity =>
            {
                entity.HasKey(e => new { e.UsagePurposeId, e.ProjectId })
                    .HasName("PK__ProjectU__8831D5CCCCF1F8DC");

                entity.ToTable("ProjectUsagePurpose");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectUsagePurposes)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectUs__Proje__45F365D3");

                entity.HasOne(d => d.UsagePurpose)
                    .WithMany(p => p.ProjectUsagePurposes)
                    .HasForeignKey(d => d.UsagePurposeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectUs__Usage__44FF419A");
            });

            modelBuilder.Entity<ProjectVoiceStyle>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.VoiceStyleId })
                    .HasName("PK__ProjectV__75411ACE28003764");

                entity.ToTable("ProjectVoiceStyle");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectVoiceStyles)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectVo__Proje__6754599E");

                entity.HasOne(d => d.VoiceStyle)
                    .WithMany(p => p.ProjectVoiceStyles)
                    .HasForeignKey(d => d.VoiceStyleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectVo__Voice__68487DD7");
            });

            modelBuilder.Entity<UsagePurpose>(entity =>
            {
                entity.ToTable("UsagePurpose");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Username, "UQ__User__536C85E4F581B476")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "UQ__User__5C7E359E1762C763")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__User__A9D10534A95EC454")
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
