using BuildingBlocks.CQRS;
using Order.Application.DTO;

namespace Order.Application.Orders.Queries.GetOrderByName
{
	public record GetOrdersByNameQueryResult(IEnumerable<OrderDTO> Orders);
	public record GetOrdersByNameQuery(string OrderName)
		:IQuery<GetOrdersByNameQueryResult>;
}
