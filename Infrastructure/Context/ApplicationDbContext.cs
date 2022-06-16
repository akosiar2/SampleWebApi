using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Context
{
    public partial class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Estimate> Estimates { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectTask> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-JQFQRFG;Database=SampleApp;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employee>(entity =>
            //{
            //    //entity.HasNoKey();

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.EmployeeName).HasColumnType("employeename");

            //});

            //modelBuilder.Entity<Estimate>(entity =>
            //{
            //    //entity.HasNoKey();

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.Estimated).HasColumnName("estimated");

            //    entity.Property(e => e.TaskId).HasColumnType("taskid");

            //    entity.Property(e => e.EmployeeId).HasColumnName("employeeid");
            //});


            //modelBuilder.Entity<Project>(entity =>
            //{
                
            //    entity.Property(e => e.Id);

            //    entity.Property(e => e.ProjectName).HasColumnType("projectname");

            //});

            //modelBuilder.Entity<ProjectTask>(entity =>
            //{
                
            //    entity.Property(e => e.Id);

            //    entity.Property(e => e.TaskName).HasColumnType("taskname");

            //    entity.Property(e => e.TotalEstimate).HasColumnName("totalestimate");

            //    entity.Property(e => e.ProjectId).HasColumnName("projectid");
                    
            //});

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
