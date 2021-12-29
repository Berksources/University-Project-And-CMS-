using EntityLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class AtmosphericGasesDBContext : DbContext
    {
        public AtmosphericGasesDBContext() { }
        public DbSet<MDataPublish> MDataPublishes { get; set; }
        public DbSet<Result> Results { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=WIN-45G2OIU40AH; Initial Catalog=AtmosphericGasesDB;Integrated Security=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MDataPublishConfiguration());
        }
    }
}
