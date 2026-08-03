namespace Order.Application.Orders.EventHandlers
{
	public class OrderUpdatededEventHandler(ILogger<OrderUpdatededEventHandler> logger)
		: INotificationHandler<OrderUpdatedEvent>
	{
		public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
		{
			logger.LogInformation("Domain Event Handled: {DomainEvent}", notification.GetType().Name);
			logger.LogInformation("Received OrderUpdatedEvent for OrderId: {OrderId}", notification.order.Id);
			logger.LogInformation("Handling OrderUpdatedEvent for OrderId: {OrderId}", notification.order.Id);

			return Task.CompletedTask;
		}
	}
}
