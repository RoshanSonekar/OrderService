namespace Order.Application.Orders.EventHandlers
{
	public class OrderCreatedEventHandler(ILogger<OrderCreatedEventHandler> logger)
		 : INotificationHandler<OrderCreatedEvent>
	{
		public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
		{
			logger.LogInformation("Domain Event Handled: {DomainEvent}", notification.GetType().Name);
			logger.LogInformation("Received OrderCreatedEvent for OrderId: {OrderId}", notification.order.Id);	
			logger.LogInformation("Handling OrderCreatedEvent for OrderId: {OrderId}", notification.order.Id);

			return Task.CompletedTask;
		} 
	}
}
