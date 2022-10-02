using Domain.Entities;
using Domain.Entities.WarehouseAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class WarehouseConfigurations : IEntityTypeConfiguration<Warehouse>
	{
		public virtual void Configure(EntityTypeBuilder<Warehouse> builder)
		{

			builder.Property(x => x.Id).HasColumnName("nWarehouseId").IsRequired();
			builder.Property(x => x.Name).HasColumnName("sName").IsRequired();
			builder.Property(x => x.Place).HasColumnName("sPlace").IsRequired();
			builder.Property(x => x.Status).HasColumnName("bStatus").IsRequired();


		}
	}
}