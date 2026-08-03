namespace Order.Application.DTO
{
	public record AddressDTO
	(
		string FirstName,
		string LastName,
		string EmailAddress,
		string AddressLine,
		string City,
		string Country,
		string PostalCode,
		string state,
		string StreetName
	);
}
