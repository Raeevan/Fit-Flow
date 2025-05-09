using FitFlow.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FitFlow.Data
{
    public class GymDbContext: DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

    }
}
