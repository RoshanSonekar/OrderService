namespace Order.Domain.Models
{
	public class Product : Entity<ProductId>
	{
		public decimal Price { get; private set; } = default!;
		public string Name { get; private set; } = default!;

		public static Product Create(ProductId id, string name, decimal price)
		{
			ArgumentException.ThrowIfNullOrWhiteSpace(name);
			ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

			var product= new Product
			{
				Id = id,
				Name = name,
				Price = price
			};

			return product;
		}
	}
}
