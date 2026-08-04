using Order.Application.Orders.Queries.GetOrderByName;
namespace OrderService.Endpoints;

public record GetOrderByNameResponse(IEnumerable<OrderDTO> Orders);
public class GetOrdersByName : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapGet("/orders/{orderName}", async(string orderName, ISender sender) =>
			{
				var results = await sender.Send(new GetOrdersByNameQuery(orderName));
				var response = results.Adapt<GetOrderByNameResponse>();

				return Results.Ok(response);
		})
		.WithName("GetOrdersByName")
		.Produces<GetOrderByNameResponse>(StatusCodes.Status200OK)
		.ProducesProblem(StatusCodes.Status400BadRequest)
		.ProducesProblem(StatusCodes.Status404NotFound)
		.WithSummary("Get Orders By Name")
		.WithDescription("Get Orders By Name");
	}
}
