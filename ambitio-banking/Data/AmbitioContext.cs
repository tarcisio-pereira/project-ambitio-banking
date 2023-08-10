using System;
using ambitio_banking.Data;
using System.Configuration;
using ambitio_banking.Models;
using ambitio_banking.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ambitio_banking.Data.Map;

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
                //optionsBuilder.UseMySql("server=localhost;port=3306;database=Banking;uid=root;password=senha123", new MySqlServerVersion(new Version(8, 0, 24)));
                  optionsBuilder.UseMySql("server=ambitio-banking.mysql.database.azure.com;port=3306;database=Banking;uid=tarcisio51;password=Ambitio5151", new MySqlServerVersion(new Version(8, 0, 24)));
            }
        }

        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<ContaBancariaModel> ContaBancaria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContaBancariaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}