using Microsoft.EntityFrameworkCore;
using eLearning.Models;
using System;

namespace eLearning.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<About> Abouts { get; set; }

    }
}
