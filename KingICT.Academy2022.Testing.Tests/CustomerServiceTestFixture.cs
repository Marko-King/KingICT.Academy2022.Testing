using AutoMapper;
using KingICT.Academy2022.Testing.Contract;
using KingICT.Academy2022.Testing.MockRepository;
using KingICT.Academy2022.Testing.Service;
using KingICT.Academy2022.Testing.Service.Mapping;

namespace KingICT.Academy2022.Testing.Tests
{
	public class CustomerServiceTestFixture
	{
		#region Fields 

		public ICustomerService CustomerService;

		#endregion

		#region Constructors

		public CustomerServiceTestFixture()
		{
			var mapper = GenerateMapperMock();
			var mockRepo = new CustomerRepositoryMock();

			CustomerService = new CustomerService
				(
					mockRepo,
					mapper
				);
		}

		#endregion

		#region Private Methods

		private IMapper GenerateMapperMock()
		{
			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new CustomerMappingProfile());
			});

			return mapperConfig.CreateMapper();
		}

		#endregion
	}
}
