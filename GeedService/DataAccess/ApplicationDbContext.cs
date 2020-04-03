using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeedService.DataEntities;
using GeedService.Model;
using Microsoft.EntityFrameworkCore;


namespace GeedService.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}
        
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Following> Followings { get; set; }
    }
}
