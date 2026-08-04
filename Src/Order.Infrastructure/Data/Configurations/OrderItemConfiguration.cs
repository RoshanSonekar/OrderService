using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Models;
using Order.Domain.ValueObjects;

namespace Order.Infrastructure.Data.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
	public void Configure(EntityTypeBuilder<OrderItem> builder)
	{
		builder.HasKey(oi => oi.Id);

		builder.Property(oi => oi.Id).HasConversion
			(oiItemId=> oiItemId.Value,
			dbId=> OrderItemId.Of(dbId));

		builder.HasOne<Product>()
			.WithMany()
			.HasForeignKey(oi => oi.ProductId);

		builder.Property(oi => oi.Quantity).HasMaxLength(3).IsRequired();
		builder.Property(oi=> oi.Price).IsRequired();	
	}
}
