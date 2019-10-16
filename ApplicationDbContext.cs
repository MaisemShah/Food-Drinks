using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using D.I._Tech_Night_School.Data;

namespace D.I._Tech_Night_School.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<D.I._Tech_Night_School.Data.Drink> Drink { get; set; }
        public DbSet<D.I._Tech_Night_School.Data.Food> Food { get; set; }
    }
}
