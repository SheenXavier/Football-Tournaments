using Tournaments.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System;

namespace Tournaments.Data
{ 
    public class AppDBContext : DbContext
    {


        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Team> Team { get; set; } = null!;
        public DbSet<Pointstable> Pointstable { get; set; } = null!;
        public DbSet<Tournament> Tournament { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}



