using BuildingBlocks.Pagination;

namespace Order.Application.Orders.Queries.GetOrders
{
	public class GetOrdersHandler(IApplicationDbContext dbContext)
		: IQueryHandler<GetOrdersQuery, GetOrdersResult>
	{
		public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
		{
			// get orders with pagination from db
			var pageIndex = query.PaginationRequest.PageIndex;
			var pageSize = query.PaginationRequest.PageSize;

			var totalCount = await dbContext.Orders.CountAsync(cancellationToken);

			if (totalCount == 0)
			{
				return new GetOrdersResult(
					new PaginatedResults<OrderDTO>
					(
						pageIndex, pageSize, totalCount,
						new List<OrderDTO>())
					);
			}

			var orders = await dbContext.Orders
				.Include(o => o.OrderItems)
				.OrderBy(o => o.OrderName.Value)
				.Skip(pageIndex * pageSize)
				.Take(pageSize)
				.ToListAsync(cancellationToken);

			return new GetOrdersResult(
				new PaginatedResults<OrderDTO>
				(
					pageIndex, pageSize, totalCount,
					orders.ToOrderDtoList())
				);
		}
	}
}
