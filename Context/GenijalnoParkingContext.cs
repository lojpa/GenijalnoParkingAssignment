using GenijalnoParkingAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenijalnoParkingAssignment.Context
{
    public class GenijalnoParkingContext : DbContext
    {
        public GenijalnoParkingContext(DbContextOptions<GenijalnoParkingContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Parking> Parkings { get; set; }
        public DbSet<ParkingDetail> ParkingDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingDetail>()
            .HasOne(p => p.Parking)
            .WithMany(d => d.ParkingDetails)
            .HasForeignKey(p => p.ParkingId);

            modelBuilder.Entity<ParkingDetail>()
            .HasOne(o => o.Operator)
            .WithMany(d => d.ParkingDetails)
            .HasForeignKey(o => o.OperatorId);

            modelBuilder.Entity<ParkingDetail>()
            .HasOne(c => c.Customer)
            .WithMany(d => d.ParkingDetails)
            .HasForeignKey(c => c.CustomerId);

            modelBuilder.Entity<Customer>()
             .HasOne(v => v.Vehicle)
             .WithOne(c => c.Customer)
             .HasForeignKey<Vehicle>(v => v.CustomerId);


        }
    }
}
