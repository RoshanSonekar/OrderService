namespace Order.Domain.ValueObjects
{
	public record Address
	{
		public string FirstName { get; } = default!;
		public string LastName { get; } = default!;
		public string EmailAddress { get; } = default!;
		public string City { get;  } = default!;
		public string PostalCode { get;	 } = default!;
		public string Country { get; } = default!;
		public string State { get; } = default!;
		public string StreetName { get; } = default!;
		public string AddressLine { get; } = default!;

		protected Address()
		{
			
		}

		private Address(string firstName, string lastName, string emailAddress, string addressLine, string city, string country, string postalCode,  string state, string streetName)
		{
			FirstName = firstName;
			LastName = lastName;
			EmailAddress = emailAddress;
			City = city;
			PostalCode = postalCode;
			State = state;
			StreetName = streetName;
			Country = country;
			AddressLine = addressLine;
		}

		public static Address Of(string firstName, string lastName, string emailAddress, string addressLine, string city, string country, string postalCode, string state, string streetName)
		{
			ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
			ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress);
			ArgumentException.ThrowIfNullOrWhiteSpace(addressLine);

			return new Address(firstName, lastName, emailAddress, addressLine, city, country, postalCode, state, streetName); 

		}
	}
}
