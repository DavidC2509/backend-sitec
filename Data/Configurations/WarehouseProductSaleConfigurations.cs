using Domain.Entities.WarehouseProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Command.Configurations
{
    public class WarehouseProductSaleConfigurations : IEntityTypeConfiguration<WarehouseProductSale>
	{
		public virtual void Configure(EntityTypeBuilder<WarehouseProductSale> builder)
		{

			builder.Property(x => x.Id).HasColumnName("nWarehouseProductSale").IsRequired();
			builder.Property(x => x.WarehouseProductId).HasColumnName("nWarehouseProductId").IsRequired();
			builder.Property(x => x.CountSell).HasColumnName("nCountSell").IsRequired();
			builder.Property(x => x.PriceSell).HasColumnName("nPriceSell").IsRequired();
			builder.Property(x => x.DateSell).HasColumnName("dDateSell").IsRequired();

		}
	}
}