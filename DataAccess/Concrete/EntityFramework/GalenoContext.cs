using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class GalenoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source=185.210.94.60\\sql.athena.domainhizmetleri.com,1433;Database=galenoco_GalenoDB;User id=galenoco_admin0306; password=soner123*;Integrated Security=false;");
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchOperation> BranchOperations { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageOperation> LanguageOperations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }


    }
}
