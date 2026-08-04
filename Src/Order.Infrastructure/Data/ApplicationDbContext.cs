using Order.Application.Data;
using Order.Domain.Models;
using System.Reflection;

namespace Order.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
	: base(dbContextOptions)
	{ }

	public DbSet<Customer> Customers => Set<Customer>();
	public DbSet<Product> Products => Set<Product>();
	public DbSet<Domain.Models.Order> Orders => Set<Domain.Models.Order>();
	public DbSet<OrderItem> OrderItems => Set<OrderItem>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		//modelBuilder.Entity<Payment>().HasNoKey();//.Property(c => c.Name).IsRequired().HasMaxLength(100);
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		base.OnModelCreating(modelBuilder);
	}
}
