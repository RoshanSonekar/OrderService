using Order.Application.Extensions;

namespace Order.Application.Orders.Queries.GetOrderByName
{
	public class GetOrdersByNameHandler(IApplicationDbContext dbContext)
		: IQueryHandler<GetOrdersByNameQuery, GetOrdersByNameQueryResult>
	{
		public async Task<GetOrdersByNameQueryResult> Handle(GetOrdersByNameQuery query, CancellationToken cancellationToken)
		{
			var orders = await dbContext.Orders
				.Include(o => o.OrderItems)
				.AsNoTracking()
				.Where(o => o.OrderName.Value.Contains(query.OrderName))
				.OrderBy(o => o.OrderName)
				.ToListAsync(cancellationToken);

			//var orderDto = ProjectToOrderDTO(orders); 
			return new GetOrdersByNameQueryResult(orders.ToOrderDtoList());
		}

		private List<OrderDTO> ProjectToOrderDTO(List<Domain.Models.Order> orders)
		{

			List<OrderDTO> orderDTOs = new List<OrderDTO>();
			foreach (var order in orders)
			{
				var orderDTO = new OrderDTO
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
					OrderItems: order.OrderItems.Select(oi => new OrderItemDTO
					(
						oi.Id.Value,
						oi.ProductId.Value,
						oi.Quantity,
						oi.Price
					)).ToList()
				);

				orderDTOs.Add(orderDTO);
			}
			return orderDTOs;
		}
	}
}
