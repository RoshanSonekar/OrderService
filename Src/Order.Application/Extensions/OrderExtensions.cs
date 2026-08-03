using System.Net.NetworkInformation;
using Order.Application.DTO;

namespace Order.Application.Extensions
{
	public static class OrderExtensions
	{
		public static IEnumerable<OrderDTO> ToOrderDtoList(this IEnumerable<Domain.Models.Order> orders)
		{
			return orders.Select(order => new OrderDTO
			(
				Id: order.Id.Value,
				CustomerId: order.CustomerId.Value,
				OrderName: order.OrderName.Value,
				ShippingAddress: new AddressDTO
				(
					order.ShippingAddress.FirstName,
					order.ShippingAddress.LastName,
					order.ShippingAddress.EmailAddress,
					order.ShippingAddress.AddressLine,
					order.ShippingAddress.City,
					order.ShippingAddress.Country,
					order.ShippingAddress.PostalCode,
					order.ShippingAddress.State,
					order.ShippingAddress.StreetName
				),
				BillingAddress: new AddressDTO
				(
					order.BillingAddress.FirstName,
					order.BillingAddress.LastName,
					order.BillingAddress.EmailAddress,
					order.BillingAddress.AddressLine,
					order.BillingAddress.City,
					order.BillingAddress.Country,
					order.BillingAddress.PostalCode,
					order.BillingAddress.State,
					order.BillingAddress.StreetName
				),
				Payment: new PaymentDTO
				(
					order.Payment.CardName,
					order.Payment.CardNumber,
					order.Payment.PaymentMethod,
					order.Payment.Cvv,
					order.Payment.Expiration,
					order.Payment.CardType
				),
				Status: order.Status,
				OrderItems: order.OrderItems.Select(item => new OrderItemDTO
				(
					item.OrderId.Value,
					item.ProductId.Value,
					item.Quantity,
					item.Price
				)).ToList()
			));
		}
	}
}
