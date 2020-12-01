using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TvPlusGame.Model.Entity;

namespace TvPlusGame.DataAccess.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var PLAYER_ID = "75625814-138e-4831-a1ea-bf58e211adff";
            var PLAYER_ROLE_ID = "29bd76db-5835-406d-ad1d-7a0901447c18";
            var player = new User()
            {
                Id = PLAYER_ID,
                Name = "Player",
                UserName = "player",
                NormalizedUserName = "PLAYER",
                Email = "player@player.com",
                NormalizedEmail = "PLAYER@PLAYER.COM"
            };
            player.PasswordHash = GetHashedPassword(player, "Player");

            modelBuilder.Entity<User>().HasData(
                player
            );
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = PLAYER_ROLE_ID, Name = "Player", NormalizedName = "PLAYER" }
            );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = PLAYER_ROLE_ID,
                UserId = PLAYER_ID
            });
        }
        public static string GetHashedPassword(User user, string password)
        {
            var pass = new PasswordHasher<User>();
            var hashed = pass.HashPassword(user, password);
            return hashed;
        }
    }
}
