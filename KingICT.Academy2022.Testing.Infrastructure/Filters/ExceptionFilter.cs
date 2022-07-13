using KingICT.Academy2022.Testing.Infrastructure.Factories;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace KingICT.Academy2022.Testing.Infrastructure.Filters
{
	public class ExceptionFilter : IAsyncExceptionFilter
	{
		#region Fields

		private readonly IExceptionHandlerFactory _factory;
		private readonly ILogger<ExceptionFilter> _logger;

		#endregion

		#region Constructors

		public ExceptionFilter(IExceptionHandlerFactory factory, ILogger<ExceptionFilter> logger)
		{
			_factory = factory;
			_logger = logger;
		}

		#endregion

		#region Public Methods

		public async Task OnExceptionAsync(ExceptionContext context)
		{
			_logger.LogError("Unhandled exception occured: {ex}", context.Exception);

			var handler = _factory.SelectHandler(context.Exception);
			var objectResult = handler.Handle(context.Exception);

			context.Result = objectResult;
		}

		#endregion
	}
}
