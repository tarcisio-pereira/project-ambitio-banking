using System;
using ambitio_banking.Models;
using Microsoft.EntityFrameworkCore;

namespace ambitio_banking.Data
{
	public class AmbitioContext : DbContext
	{
        protected readonly IConfiguration Configuration;

        public AmbitioContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;database=Banking;uid=root;password=senha123", new MySqlServerVersion(new Version(8, 0, 24)));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }

        public DbSet<UserModel> Users { get; set; }
    }
}
