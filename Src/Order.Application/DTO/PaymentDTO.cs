
namespace Order.Application.DTO
{
	public record PaymentDTO
	(
		string CardName,
		string CardNumber,
		string PaymentMethod,
		int Cvv,
		string Expiration,
		string CardType
		);
}
