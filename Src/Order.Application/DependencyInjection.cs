using BuildingBlocks.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Order.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			// add MediatR services
			services.AddMediatR(config =>
			{
				config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
				config.AddOpenBehavior(typeof(LoggingBehavior<,>)); 
				config.AddOpenBehavior(typeof(ValidationBehavior<,>));
			});

			return services;	
		}
	}
}
