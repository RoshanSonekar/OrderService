using BuildingBlocks.Pagination;

namespace Order.Application.Orders.Queries.GetOrders
{
	public record GetOrdersResult(PaginatedResults<OrderDTO> Orders);
	public record GetOrdersQuery(PaginationRequest PaginationRequest)
		: IQuery<GetOrdersResult>;
}
