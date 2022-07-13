namespace KingICT.Academy2022.Testing.Infrastructure.Extenstions
{
	public static class CollectionExteension
	{
		public static bool HasElements<T>(this IEnumerable<T> input)
		{
			return input != null && input.Any();
		}
	}
}
