using KingICT.Academy2022.Testing.Infrastructure.Handlers;

namespace KingICT.Academy2022.Testing.Infrastructure.Factories
{
	public interface IExceptionHandlerFactory
	{
		public IExceptionHandler SelectHandler(Exception e);
	}
}
