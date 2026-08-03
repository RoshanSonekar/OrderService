namespace Order.Domain.ValueObjects
{
	public record CustomerId
	{
		public Guid Value { get; }
		private CustomerId(Guid value) => Value = value;
		public static CustomerId Of(Guid value)
		{
			ArgumentNullException.ThrowIfNull(value);
			if (value == Guid.Empty)
				throw new DomainExecption("CustomerId can not be empty!");

			return new CustomerId(value);
		}
	}

	public record OrderName
	{
		private const int DefaultLenght = 5;
		public String Value { get; }
		private OrderName(String value) => Value = value;
		public static OrderName Of(String value)
		{
			ArgumentException.ThrowIfNullOrWhiteSpace(value);
			ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length,DefaultLenght);

			return new OrderName(value);
		}
	}

	public record OrderId
	{
		public Guid Value { get; }
		private OrderId(Guid value) => Value = value;
		public static OrderId Of(Guid value)
		{
			ArgumentNullException.ThrowIfNull(value);
			if (value == Guid.Empty)
				throw new DomainExecption("OrderId can not be empty!");

			return new OrderId(value);
		}
	}

	public record ProductId
	{
		public Guid Value { get; }
		private ProductId(Guid value) => Value = value;
		public static ProductId Of(Guid value)
		{
			ArgumentNullException.ThrowIfNull(value);
			if (value == Guid.Empty)
				throw new DomainExecption("ProductId can not be empty!");

			return new ProductId(value);
		}
	}
	public record OrderItemId
	{
		public Guid Value { get; }
		private OrderItemId(Guid value) => Value = value;
		public static OrderItemId Of(Guid value)
		{
			ArgumentNullException.ThrowIfNull(value);
			if (value == Guid.Empty)
				throw new DomainExecption("OrderItemId can not be empty!");

			return new OrderItemId(value);
		}

	}
}
