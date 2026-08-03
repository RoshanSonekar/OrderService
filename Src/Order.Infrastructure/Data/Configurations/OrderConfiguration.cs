using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Enums;
using Order.Domain.Models;
using Order.Domain.ValueObjects;

namespace Order.Infrastructure.Data.Configurations
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order.Domain.Models.Order>
	{
		public void Configure(EntityTypeBuilder<Order.Domain.Models.Order> builder)
		{
			builder.HasKey(o=>o.Id);
			
			builder.Property(o => o.Id).HasConversion(
				orderId => orderId.Value,
				dbId => OrderId.Of(dbId));
			
			builder.HasOne<Customer>()
				.WithMany()
				.HasForeignKey(o => o.CustomerId)
				.IsRequired();

			builder.HasMany(oi => oi.OrderItems)
				.WithOne()
				.HasForeignKey(oi => oi.OrderId);

			builder.ComplexProperty(
				o => o.OrderName, nameBuilder =>
				{
					nameBuilder.Property(n => n.Value)
					.HasColumnName(nameof(Order.Domain.Models.Order.OrderName))
					.HasMaxLength(100)
					.IsRequired();
				});

			builder.ComplexProperty(
				a=> a.ShippingAddress, addressBuilder =>
				{
					addressBuilder.Property(x=> x.FirstName).HasMaxLength(100).IsRequired();

					addressBuilder.Property(x => x.LastName).HasMaxLength(100).IsRequired();

					addressBuilder.Property(x => x.AddressLine).HasMaxLength(300).IsRequired();

					addressBuilder.Property(x => x.Country).HasMaxLength(100).IsRequired();

					addressBuilder.Property(x => x.PostalCode).HasMaxLength(8).IsRequired();
				}
				);

			builder.ComplexProperty(
				a => a.BillingAddress, addressBuilder =>
				{
					addressBuilder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();

					addressBuilder.Property(x => x.LastName).HasMaxLength(100).IsRequired();

					addressBuilder.Property(x => x.AddressLine).HasMaxLength(300).IsRequired();

					addressBuilder.Property(x => x.Country).HasMaxLength(100).IsRequired();

					addressBuilder.Property(x => x.PostalCode).HasMaxLength(8).IsRequired();
				}
				);

			builder.ComplexProperty(
				p=> p.Payment, paymentBuilder =>
				{
					paymentBuilder.Property(p=> p.CardName).HasMaxLength(100).IsRequired();

					paymentBuilder.Property(p => p.CardNumber).HasMaxLength(16).IsRequired();

					paymentBuilder.Property(p => p.Expiration).HasMaxLength(5).IsRequired();

					paymentBuilder.Property(p => p.Cvv).HasMaxLength(3).IsRequired();

					paymentBuilder.Property(p => p.PaymentMethod).HasMaxLength(100).IsRequired();
				}
				);

			builder.Property(o=> o.Status)
				.HasDefaultValue(OrderStatus.Draft)
				.HasConversion
				(
				s=> s.ToString(),
				dbStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), dbStatus)	
				);

			builder.Property(t => t.TotalPrice).IsRequired();
		}
	}
}
