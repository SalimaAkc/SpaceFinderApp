using Microsoft.EntityFrameworkCore;
using SpacefinderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacefinderApp.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasDiscriminator(u => u.Type)
                .HasValue<Student>(UserType.Student)
                .HasValue<Teacher>(UserType.Teacher);
        }
    }
}
