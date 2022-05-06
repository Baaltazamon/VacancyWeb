using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace VacancyWeb.Models
{
    public partial class VacancyContext : DbContext
    {
        public VacancyContext()
        {
        }

        public VacancyContext(DbContextOptions<VacancyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Condition> Conditions { get; set; }
        public virtual DbSet<Duty> Duties { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Requirement> Requirements { get; set; }
        public virtual DbSet<StatusRequest> StatusRequests { get; set; }
        public virtual DbSet<StatusVacancy> StatusVacancies { get; set; }
        public virtual DbSet<TimeTable> TimeTables { get; set; }
        public virtual DbSet<TypeOfEmployment> TypeOfEmployments { get; set; }
        public virtual DbSet<TypeVacancy> TypeVacancies { get; set; }
        public virtual DbSet<VacancyRequest> VacancyRequests { get; set; }
        public virtual DbSet<staff> staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.50.136;Database=Vacancy;User Id=sa;Password=Wsr2020!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Condition>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Vacancy)
                    .WithMany(p => p.Conditions)
                    .HasForeignKey(d => d.VacancyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Conditions_VacancyRequest");
            });

            modelBuilder.Entity<Duty>(entity =>
            {
                entity.ToTable("Duty");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Vacancy)
                    .WithMany(p => p.Duties)
                    .HasForeignKey(d => d.VacancyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Duty_VacancyRequest");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("Request");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.StaffNavigation)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.Staff)
                    .HasConstraintName("FK_Request_Staff");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_StatusRequest");

                entity.HasOne(d => d.VacancyNavigation)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.Vacancy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_VacancyRequest");
            });

            modelBuilder.Entity<Requirement>(entity =>
            {
                entity.ToTable("Requirement");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Vacancy)
                    .WithMany(p => p.Requirements)
                    .HasForeignKey(d => d.VacancyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Requirement_VacancyRequest");
            });

            modelBuilder.Entity<StatusRequest>(entity =>
            {
                entity.ToTable("StatusRequest");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<StatusVacancy>(entity =>
            {
                entity.ToTable("StatusVacancy");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TimeTable>(entity =>
            {
                entity.ToTable("TimeTable");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TypeOfEmployment>(entity =>
            {
                entity.ToTable("TypeOfEmployment");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TypeVacancy>(entity =>
            {
                entity.ToTable("TypeVacancy");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VacancyRequest>(entity =>
            {
                entity.ToTable("VacancyRequest");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.StaffNavigation)
                    .WithMany(p => p.VacancyRequests)
                    .HasForeignKey(d => d.Staff)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VacancyRequest_Staff");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.VacancyRequests)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VacancyRequest_StatusVacancy");

                entity.HasOne(d => d.TimeTableNavigation)
                    .WithMany(p => p.VacancyRequests)
                    .HasForeignKey(d => d.TimeTable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VacancyRequest_TimeTable");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.VacancyRequests)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VacancyRequest_TypeVacancy");

                entity.HasOne(d => d.TypeOfEmploymentNavigation)
                    .WithMany(p => p.VacancyRequests)
                    .HasForeignKey(d => d.TypeOfEmployment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VacancyRequest_TypeOfEmployment");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.PostNavigation)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.Post)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Staff_Post");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
