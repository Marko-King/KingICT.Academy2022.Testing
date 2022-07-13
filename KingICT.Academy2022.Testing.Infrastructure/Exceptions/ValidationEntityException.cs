namespace KingICT.Academy2022.Testing.Infrastructure.Exceptions
{
	public class ValidationEntityException : Exception
	{
		public ValidationEntityException(string message)
			: base(message)
		{
		}
	}
}
