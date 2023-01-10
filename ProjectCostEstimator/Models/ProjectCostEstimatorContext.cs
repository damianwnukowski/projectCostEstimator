using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProjectCostEstimator.Models
{
    public class ProjectCostEstimatorContext : DbContext
    {

        public ProjectCostEstimatorContext() : base("Test")
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<ProjectTaskDefinition> ProjectTaskDefinitions { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<TechnologyDefinition> TechnologyDefinitions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}