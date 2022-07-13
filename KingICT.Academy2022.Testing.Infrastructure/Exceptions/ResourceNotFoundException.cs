namespace KingICT.Academy2022.Testing.Infrastructure.Exceptions
{
	public class ResourceNotFoundException : Exception
	{
		public ResourceNotFoundException()
			: base("Traženi resurs nije pronađen.")
		{
		}
	}
}
