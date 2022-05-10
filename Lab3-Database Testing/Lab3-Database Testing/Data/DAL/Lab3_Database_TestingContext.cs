#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab3_Database_Testing.Models;

namespace Lab3_Database_Testing.Data
{
    public class Lab3_Database_TestingContext : DbContext
    {
        public Lab3_Database_TestingContext (DbContextOptions<Lab3_Database_TestingContext> options)
            : base(options)
        {
        }

        public DbSet<Lab3_Database_Testing.Models.ParkingSpace> ParkingSpace { get; set; }

        public DbSet<Pass> Pass { get; set; }

        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
    }
}
