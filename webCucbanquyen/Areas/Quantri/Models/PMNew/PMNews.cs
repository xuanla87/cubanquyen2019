namespace webCucbanquyen.Areas.Quantri.Models.PMNew
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PMNews : DbContext
    {
        public PMNews()
            : base("name=PMNews")
        {
        }

        public virtual DbSet<AppLog> AppLogs { get; set; }
        public virtual DbSet<BusinessClientVersion> BusinessClientVersions { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<LogType> LogTypes { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<Licensor> Licensors { get; set; }
        public virtual DbSet<National> Nationals { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<ProgramType> ProgramTypes { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<RevokedDecision> RevokedDecisions { get; set; }
        public virtual DbSet<Work> Works { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Works)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.WorkAreaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Works1)
                .WithRequired(e => e.Department1)
                .HasForeignKey(e => e.CreatedAreaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LogType>()
                .HasMany(e => e.AppLogs)
                .WithRequired(e => e.LogType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Categories1)
                .WithOptional(e => e.Category1)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Category>()
                .HasOptional(e => e.ProgramType)
                .WithRequired(e => e.Category);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Works)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<National>()
                .HasMany(e => e.Authors)
                .WithOptional(e => e.National)
                .HasForeignKey(e => e.NationalityId);

            modelBuilder.Entity<National>()
                .HasMany(e => e.Owners)
                .WithOptional(e => e.National)
                .HasForeignKey(e => e.NationalityId);

            modelBuilder.Entity<Work>()
                .HasOptional(e => e.Certificate)
                .WithRequired(e => e.Work)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Work>()
                .HasOptional(e => e.RevokedDecision)
                .WithRequired(e => e.Work)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Work>()
                .HasMany(e => e.Works1)
                .WithOptional(e => e.Work1)
                .HasForeignKey(e => e.ParentId);
        }
    }
}
