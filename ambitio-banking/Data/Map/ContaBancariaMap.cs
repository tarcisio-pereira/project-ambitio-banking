using System;
using ambitio_banking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ambitio_banking.Data.Map
{
	public class ContaBancariaMap : IEntityTypeConfiguration<ContaBancariaModel>
	{
        public void Configure(EntityTypeBuilder<ContaBancariaModel> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(e => e.Usuario);
            builder.WithOne(e => e.Usuario);
        }
    }
}