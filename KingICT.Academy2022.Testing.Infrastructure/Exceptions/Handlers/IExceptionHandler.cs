using Microsoft.AspNetCore.Mvc;

namespace KingICT.Academy2022.Testing.Infrastructure.Handlers
{
	public interface IExceptionHandler
	{
		public bool CanHandle(Exception e);

		public ObjectResult Handle(Exception e);
	}
}
