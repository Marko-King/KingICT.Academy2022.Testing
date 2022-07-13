using AutoMapper;
using KingICT.Academy2022.Testing.Contract;
using KingICT.Academy2022.Testing.Infrastructure.Configuration;
using KingICT.Academy2022.Testing.Infrastructure.Factories;
using KingICT.Academy2022.Testing.Infrastructure.Filters;
using KingICT.Academy2022.Testing.Infrastructure.Handlers;
using KingICT.Academy2022.Testing.Model;
using KingICT.Academy2022.Testing.Repository;
using KingICT.Academy2022.Testing.Service;
using KingICT.Academy2022.Testing.Service.Mapping;
using Microsoft.EntityFrameworkCore;

namespace KingICT.Academy2022.Testing.API
{
	public static class DiContainer
	{
		#region Public Methods

		public static void Configure(WebApplicationBuilder builder)
		{
			ConfigureServices(builder.Services);
			ConfigureRepositories(builder.Services, builder.Configuration);
			ConfigureDatabase(builder.Services, builder.Configuration);
			ConfigureMappingProfiles(builder.Services);
			ConfigureExceptionHandling(builder.Services);
		}

		#endregion


		#region Private Methods

		private static void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<ICustomerService, CustomerService>();
		}

		private static void ConfigureRepositories(IServiceCollection services, IConfiguration config)
		{
			services.AddTransient<ICustomerRepository, CustomerRepository>();
		}

		private static void ConfigureDatabase(IServiceCollection services, IConfiguration config)
		{
			var databaseConfig = config.GetSection(nameof(DatabaseConfiguration)).Get<DatabaseConfiguration>();

			services.AddDbContext<AppDbContext>(
				(options) => options.UseSqlServer(databaseConfig.ConnectionString)
				,
				ServiceLifetime.Scoped
			);
		}

		public static void ConfigureMappingProfiles(IServiceCollection services)
		{
			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new CustomerMappingProfile());
			});

			services.AddSingleton(mapperConfig.CreateMapper());
		}

		private static void ConfigureExceptionHandling(IServiceCollection services)
		{
			services.AddTransient<IExceptionHandlerFactory, ExceptionHandlerFactory>();

			services.AddTransient<IExceptionHandler, DefaultExceptionHandler>();
			services.AddTransient<IExceptionHandler, ValidationEntityExceptionHandler>();
			services.AddTransient<IExceptionHandler, ResourceNotFoundExceptionHandler>();

			services.AddControllers(options =>
			{
				options.Filters.Add<ExceptionFilter>();
			});
		}

		#endregion
	}
}
