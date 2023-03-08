using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BigSchool.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        public ApplicationDbContext()
            : base("BigSchoolConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating (DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Entity<Attendance>()
                .HasRequired(a => a.Course)
                .WithMany()
                .WillCascadeOnDelete(false);
            base.OnModelCreating (dbModelBuilder);
        }
    }
}