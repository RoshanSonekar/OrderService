namespace Order.Domain.ValueObjects
{
	public record Payment
	{
		public string CardName { get; } = default;
		public string CardNumber { get; } = default!;
		public string CardType { get; } = default!;
		public string Expiration { get; } = default!;
		public int Cvv { get; } = default;
		public string PaymentMethod { get; } = default!;

		protected Payment()
		{ }

		private Payment(string cardName, string cardNumber, string cardType, string expiration, int cvv, string paymentMethod)
		{
			CardName = cardName;
			CardType = cardType;
			Expiration = expiration;
			Cvv = cvv;
			PaymentMethod = paymentMethod;
			CardNumber = cardNumber;
		}

		public static Payment Of(string cardName, string cardNumber, string cardType, string expiration, int cvv, string paymentMethod)
		{
			ArgumentException.ThrowIfNullOrWhiteSpace(cardName);
			ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber);
			ArgumentException.ThrowIfNullOrWhiteSpace(cardType);
			ArgumentException.ThrowIfNullOrWhiteSpace(expiration);
			ArgumentException.ThrowIfNullOrWhiteSpace(paymentMethod);
			ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.ToString().Length, 3);
			ArgumentOutOfRangeException.ThrowIfLessThan(cvv.ToString().Length, 3);

			return new Payment(cardName, cardNumber, cardType, expiration, cvv, paymentMethod);
		}
	}
}
