using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TvPlusGame.Model.Entity;

namespace TvPlusGame.DataAccess.Context
{
    public class MyDbContext : IdentityDbContext<User>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<UserGame> UserGames { get; set; }
        public DbSet<GameSetting> GameSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.UserName).HasMaxLength(22);
            modelBuilder.Entity<User>().Property(x => x.NormalizedUserName).HasMaxLength(22);

            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}
