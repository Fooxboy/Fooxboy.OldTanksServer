using Fooxboy.OldTanksServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Database
{
    public class ServerDB : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Garage> Garages { get; set; }
        public DbSet<BannedIp> BannedIps { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=server.db");
        }
    }
}
