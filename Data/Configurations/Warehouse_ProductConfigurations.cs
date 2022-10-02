using Domain.Entities;
using Domain.Entities.WarehouseProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class Warehouse_ProductConfigurations : IEntityTypeConfiguration<WarehouseProduct>
	{
		public virtual void Configure(EntityTypeBuilder<WarehouseProduct> builder)
		{

            builder
               .HasOne(pt => pt.Product)
               .WithMany()
               .HasForeignKey(pt => pt.ProductId);

            builder
                .HasOne(pt => pt.Warehouse)
                .WithMany()
                .HasForeignKey(pt => pt.WarehouseId);


            builder.Property(x => x.Id).HasColumnName("nWarehouseProductId").IsRequired();
            builder.Property(x => x.Count).HasColumnName("nCount").IsRequired();
            builder.Property(x => x.ProductId).HasColumnName("nProductId").IsRequired();
            builder.Property(x => x.WarehouseId).HasColumnName("nWarehouseId").IsRequired();

            builder
               .HasMany(p => p.WarehouseProductSale)
               .WithOne()
               .HasForeignKey(p => p.WarehouseProductId);

            builder
            .Metadata
            .FindNavigation(nameof(WarehouseProduct.WarehouseProductSale))
            .SetPropertyAccessMode(PropertyAccessMode.Field);


        }
    }
}