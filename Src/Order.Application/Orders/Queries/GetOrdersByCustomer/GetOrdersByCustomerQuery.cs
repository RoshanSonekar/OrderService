namespace Order.Application.Orders.Queries.GetOrdersByCustomer
{
	public record GetOrdersByCustomerResult(IEnumerable<OrderDTO> Orders);
	public record GetOrdersByCustomerQuery(Guid CustId) 
		: IQuery<GetOrdersByCustomerResult>;
}
