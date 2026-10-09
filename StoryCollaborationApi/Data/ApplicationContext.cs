using Microsoft.EntityFrameworkCore;
using StoryCollaborationApi.Models;

namespace StoryCollaborationApi.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Story> Stories { get; set; }
        public DbSet<Contribution> Contributions { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}