using System;
using System.Collections.Generic;
using System.Text;
using AccountatApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Worker> Workers { get; set; }
    }
}
