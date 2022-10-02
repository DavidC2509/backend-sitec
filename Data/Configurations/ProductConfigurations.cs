using Domain.Entities;
using Domain.Entities.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
	{
		public virtual void Configure(EntityTypeBuilder<Product> builder)
		{

			builder.Property(x => x.Id).HasColumnName("nProductId").IsRequired();
			builder.Property(x => x.Name).HasColumnName("sName").IsRequired();
			builder.Property(x => x.Descripcion).HasColumnName("sDescripcion");
			builder.Property(x => x.BarCode).HasColumnName("sBarCode").IsRequired();
			builder.Property(x => x.Price).HasColumnName("nPrice").IsRequired();
			builder.Property(x => x.PriceIva).HasColumnName("nPriceIva").IsRequired();
			builder.Property(x => x.Status).HasColumnName("bStatus").IsRequired();

		}
	}
}