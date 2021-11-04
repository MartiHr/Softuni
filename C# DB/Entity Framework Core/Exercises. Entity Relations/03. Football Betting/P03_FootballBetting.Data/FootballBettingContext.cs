using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;
using System.Diagnostics.CodeAnalysis;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        protected FootballBettingContext()
        {
        }

        public FootballBettingContext([NotNullAttribute] DbContextOptions options) 
            : base(options)
        {

        }


        public DbSet<Bet> Bets { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlayerStatistic>()
                .HasKey(ps => new 
                {
                    ps.GameId, ps.PlayerId 
                });
        }
    }
}
