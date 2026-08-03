using BuildingBlocks.CQRS;
using Order.Application.Data;
using Order.Application.DTO;

namespace Order.Application.Orders.Commands.UpdateOrder
{
	public class UpdateCommandHandler(IApplicationDbContext dbContext)
		: ICommandHandler<UpdateOrderCommand, UpdateOrderResult>
	{
		public async Task<UpdateOrderResult> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
		{
			var orderId = OrderId.Of(command.Order.Id);
			var order = await dbContext.Orders.FindAsync
				([orderId],cancellationToken: cancellationToken);
			
			if (order != null)
				throw new OrderNotFoundException(command.Order.Id);
			
			UpdateOrderWithNewValues(order, command.Order);

			dbContext.Orders.Update(order!);
			await dbContext.SaveChangesAsync(cancellationToken);

			return new UpdateOrderResult(true);

			throw new NotImplementedException();
		}

		private void UpdateOrderWithNewValues(Domain.Models.Order? order, OrderDTO orderDto)
		{
			var updatedShippingAddress = Address.Of(
				orderDto.ShippingAddress.FirstName, orderDto.ShippingAddress.LastName, orderDto.ShippingAddress.EmailAddress,
				orderDto.ShippingAddress.AddressLine, orderDto.ShippingAddress.City, orderDto.ShippingAddress.Country,
				orderDto.ShippingAddress.PostalCode, orderDto.ShippingAddress.state, orderDto.ShippingAddress.StreetName
			);

			var updatedBillingAddress = Address.Of(
				orderDto.ShippingAddress.FirstName, orderDto.ShippingAddress.LastName, orderDto.ShippingAddress.EmailAddress,
				orderDto.ShippingAddress.AddressLine, orderDto.ShippingAddress.City, orderDto.ShippingAddress.Country,
				orderDto.ShippingAddress.PostalCode, orderDto.ShippingAddress.state, orderDto.ShippingAddress.StreetName
			);

			var updatedPayment = Payment.Of(orderDto.Payment.CardName, orderDto.Payment.CardNumber, orderDto.Payment.CardType, orderDto.Payment.Expiration, orderDto.Payment.Cvv, orderDto.Payment.PaymentMethod);

			order.Update(orderName: OrderName.Of(orderDto.OrderName),
				shippingAddress: updatedShippingAddress,
				billingAddress: updatedBillingAddress,
				payment: updatedPayment,
				status: orderDto.Status);
		}
	}
}
	