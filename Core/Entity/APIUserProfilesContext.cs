using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Core.Entity
{
    public partial class APIUserProfilesContext : DbContext
    {
        public APIUserProfilesContext()
        {
        }

        public APIUserProfilesContext(DbContextOptions<APIUserProfilesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApiUserType> ApiUserTypes { get; set; }
        public virtual DbSet<Apiuserdetail> Apiuserdetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=10.168.1.14;Database=APIUserProfiles;User ID=sa;Password=P@ssw0rd@UMB;Trusted_Connection=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<ApiUserType>(entity =>
            {
                entity.HasKey(e => e.UserTypeId);

                entity.ToTable("ApiUserType");

                entity.Property(e => e.UserTypeId)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("UserTypeID");

                entity.Property(e => e.UserTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Apiuserdetail>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CompanyName).IsUnicode(false);

                entity.Property(e => e.ContactPerson).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.ModifiedBy).IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Telephone).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);

                entity.Property(e => e.UserTypeId)
                    .IsUnicode(false)
                    .HasColumnName("UserTypeID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
