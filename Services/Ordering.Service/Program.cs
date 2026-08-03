using Order.Application;
using Order.Infrastructure;
using Order.Infrastructure.Data.Extensions;
using Ordering.Service; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services
	.AddApplicationServices()
	.AddInfrastructureServices(builder.Configuration)
	.AddOrderServices();

var app = builder.Build();

app.UseOrderService();

// configure the http request pipeline
if (app.Environment.IsDevelopment())
{
	await app.InitialiseDatabaseAsynch();
}

app.Run();
