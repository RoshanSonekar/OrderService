using Order.Application.Orders.Commands.CreateOrder;
namespace OrderService.Endpoints;
 
public record CreateOrderRequest(OrderDTO Order);
public record CreateOrderResponse(Guid OrderId);

public class CrreateOrder : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapPost("/orders", async (CreateOrderRequest request, ISender sender) =>
		{
			var command = request.Adapt<CreateOrderCommand>();
			var result = await sender.Send(command);
			var response = result.Adapt<CreateOrderResponse>();

			return Results.Created($"/orders/{response.OrderId}", response);
		})
		.WithName("CrreateOrder")
		.Produces<CreateOrderResponse>(StatusCodes.Status201Created)
		.ProducesProblem(StatusCodes.Status400BadRequest)
		.WithSummary("Create Order")
		.WithDescription("Create Order");
	}
}
