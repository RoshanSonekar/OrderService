using Microsoft.EntityFrameworkCore.Diagnostics;
using Order.Application.Data;

namespace Order.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructureServices
			(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("MyConnection");

			// add services to IoC
			services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
			services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

			services.AddDbContext<ApplicationDbContext>((sp, options) =>
			{
				options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
				options.UseSqlServer(connectionString);
			});

			services.AddScoped<IApplicationDbContext, ApplicationDbContext>(); 
			// Add service to the container for dbContext
			// add MediatR services
			// domain
			// validations

			return services;
		}
	}
}
