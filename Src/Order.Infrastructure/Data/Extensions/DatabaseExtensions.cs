using Microsoft.AspNetCore.Builder;

namespace Order.Infrastructure.Data.Extensions
{
	public static class DatabaseExtensions
	{
		public static async Task InitialiseDatabaseAsynch(this WebApplication app)
		{
			using var scope= app.Services.CreateScope();
				var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

			context.Database.MigrateAsync().GetAwaiter().GetResult();	
		}
	}
}
