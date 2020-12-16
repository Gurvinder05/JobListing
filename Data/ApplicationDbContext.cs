using JobListing.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobListing.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        /// <summary>
        /// Constructor which will receive the DbContextOptions
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Locations Table
        /// </summary>
        public DbSet<Location> Locations { get; set; }

        /// <summary>
        /// Skills Table
        /// </summary>
        public DbSet<Skill> Skills { get; set; }

        /// <summary>
        /// JobSkills Table
        /// </summary>
        public DbSet<JobSkill> JobSkills { get; set; }

        /// <summary>
        /// Jobs Table
        /// </summary>
        public DbSet<Job> Jobs { get; set; }
    }
}
