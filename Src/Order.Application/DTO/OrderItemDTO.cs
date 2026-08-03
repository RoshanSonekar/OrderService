namespace Order.Application.DTO
{
	public record OrderItemDTO
	(
		Guid OrderId,
		Guid ProductId,
		int Quantity,
		decimal Price
		);
}
