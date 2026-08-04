using BuildingBlocks.Exceptions.Handler;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
namespace OrderService;

public static class DependencyInjection
{
	public static IServiceCollection AddOrderServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddCarter();
		services.AddExceptionHandler<CustomExceptionHandler>();
		services.AddHealthChecks()
			.AddSqlServer(configuration.GetConnectionString("MyConnection")!);

		return services;
	}

	public static WebApplication UseOrderService(this WebApplication app)
	{
		app.MapCarter();
		app.UseExceptionHandler(options => { });
		app.UseHealthChecks("/health",
			new HealthCheckOptions
			{
				ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
			});

		return app;
	}
}
