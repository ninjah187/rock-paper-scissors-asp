using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RockPaperScissorsASP.Models;

namespace RockPaperScissorsASP
{
    public class GameDbContext : DbContext
    {
        public GameDbContext()
            : base("name=GameDbContext")
        {
        }

        public GameDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Player>().MapToStoredProcedures();
            modelBuilder.Entity<Game>().MapToStoredProcedures();
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}