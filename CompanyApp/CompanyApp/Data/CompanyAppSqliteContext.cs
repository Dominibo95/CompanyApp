using CompanyApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyApp.Data
{
    public class CompanyAppSqliteContext : DbContext
    {
        public DbSet<Employee> employees { get; set; }
        public DbSet<BusinessPartners> bPartners { get; set; }

        public string DbPath { get; }

        public CompanyAppSqliteContext()
        {

            var folder = Environment.SpecialFolder.LocalizedResources;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "data.db");

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
}
