namespace Ordering.Service
{ 
	public static class DependencyInjection
	{
		public static IServiceCollection AddOrderServices(this IServiceCollection services)
		{
			// services.AddCarter();

			return services;
		}

		public static WebApplication UseOrderService(this WebApplication app)
		{
			// app.MapCarter

			return app;
		}
	}
}
