using Fooxboy.OldTanksServer.Models;
using Fooxboy.OldTanksServer.TanksApi;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Database
{
    public class ServerDB : DbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Garage> Garages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=server.db");
        }
    }
}
