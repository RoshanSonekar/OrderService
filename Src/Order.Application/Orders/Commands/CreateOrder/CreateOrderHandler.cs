using BuildingBlocks.CQRS;
using Order.Application.Data;
using Order.Application.DTO;

namespace Order.Application.Orders.Commands.CreateOrder
{
	public class CreateOrderHandler(IApplicationDbContext dbContext)
		: ICommandHandler<CreateOrderCommand, CreateOrderResult>
	{
		public async Task<CreateOrderResult> Handle(CreateOrderCommand command, 
			CancellationToken cancellationToken)
		{
			var order = CretaNewOrder(command.Order);

			dbContext.Orders.Add(order);
			await dbContext.SaveChangesAsync(cancellationToken);

			return new CreateOrderResult(order.Id.Value);
		}

		private Order.Domain.Models.Order CretaNewOrder(OrderDTO orderDto)
		{

			var shippingAddress = Address.Of(
				orderDto.ShippingAddress.FirstName, orderDto.ShippingAddress.LastName, orderDto.ShippingAddress.EmailAddress,
				orderDto.ShippingAddress.AddressLine, orderDto.ShippingAddress.City, orderDto.ShippingAddress.Country,
				orderDto.ShippingAddress.PostalCode, orderDto.ShippingAddress.state, orderDto.ShippingAddress.StreetName
			);
			var billingAddress = Address.Of(
				orderDto.ShippingAddress.FirstName, orderDto.ShippingAddress.LastName, orderDto.ShippingAddress.EmailAddress,
				orderDto.ShippingAddress.AddressLine, orderDto.ShippingAddress.City, orderDto.ShippingAddress.Country,
				orderDto.ShippingAddress.PostalCode, orderDto.ShippingAddress.state, orderDto.ShippingAddress.StreetName
			);

			var newOrder = Order.Domain.Models.Order.Create(
				id: OrderId.Of(Guid.NewGuid()),
				customerId: CustomerId.Of(orderDto.CustomerId),
				orderName: OrderName.Of(orderDto.OrderName),
				shippingAddress: shippingAddress,
				billingAddress: billingAddress,
				payment: Payment.Of(orderDto.Payment.CardName, orderDto.Payment.CardNumber, orderDto.Payment.CardType, orderDto.Payment.Expiration, orderDto.Payment.Cvv, orderDto.Payment.PaymentMethod)
			);

			foreach (var itemDto in orderDto.OrderItems)
			{
				newOrder.Add(ProductId.Of(itemDto.ProductId), itemDto.Quantity, itemDto.Price);
			}

			return newOrder;
		}
	}
}