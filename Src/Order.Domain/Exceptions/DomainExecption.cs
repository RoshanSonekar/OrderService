namespace Order.Domain.Exceptions
{
	public class DomainExecption : Exception
	{
		public DomainExecption(string message)
			: base($"Domain Exception: \"{message}\" throws from domain layer.")
		{

		}
	}
}
