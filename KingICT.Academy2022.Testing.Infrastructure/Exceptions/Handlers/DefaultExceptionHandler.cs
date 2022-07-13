using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KingICT.Academy2022.Testing.Infrastructure.Handlers
{
	public class DefaultExceptionHandler : IExceptionHandler
	{
		public bool CanHandle(Exception e)
		{
			return true;
		}

		public ObjectResult Handle(Exception e)
		{
			return new ObjectResult(new
			{
				Message = "An error occured. Contact your system administrator."
			})
			{
				StatusCode = (int)HttpStatusCode.InternalServerError
			};
		}
	}
}
