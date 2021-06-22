using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Praca_Inzynierska_PSobczak.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Praca_Inzynierska_PSobczak.Data
{
    public class ApplicationDbContext : IdentityDbContext<User,Role,int>
    {
        public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options) { }

        public DbSet<Visit> Visits { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
