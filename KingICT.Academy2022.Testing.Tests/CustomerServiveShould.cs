using FluentAssertions;
using FluentAssertions.Execution;
using KingICT.Academy2022.Testing.Contract.Requests;
using KingICT.Academy2022.Testing.Infrastructure.Exceptions;
using System.Threading.Tasks;
using Xunit;

namespace KingICT.Academy2022.Testing.Tests
{
	public class CustomerServiveShould : IClassFixture<CustomerServiceTestFixture>
	{
		#region Fields

		private readonly CustomerServiceTestFixture _fixture;

		#endregion

		#region Constructors

		public CustomerServiveShould(CustomerServiceTestFixture fixture)
		{
			_fixture = fixture;
		}

		#endregion


		#region Tests

		#region CustomerQuery

		[Fact]
		public async Task GetCustomerQuery_When_ParametersAreValid()
		{
			#region Arrange

			var request = new GetCustomerQueryRequest
			{
				PageNumber = 1,
				PageSize = 10,
			};

			#endregion

			#region Act

			var response = await _fixture.CustomerService.GetCustomerQueryAsync(request);

			#endregion

			#region Assert

			using (new AssertionScope())
			{
				response.Success.Should().BeTrue();
				response.Customers.Should().NotBeEmpty();
			}

			#endregion
		}

		[Theory, MemberData(nameof(CustomerServiceTestData.GetInvalidCustomerQueryRequests), MemberType = typeof(CustomerServiceTestData)) ]
		public async Task FailToGetCustomerQuery_When_ParametersAreInvalid(GetCustomerQueryRequest request)
		{
			#region Act & Assert

			await Assert.ThrowsAsync<ValidationEntityException>(async () => await _fixture.CustomerService.GetCustomerQueryAsync(request));

			#endregion
		}


		[Fact]
		public async Task GetCustomer_When_RequestIsValid()
		{
			#region Arrange

			var request = new GetCustomerRequest
			{
				Id = 1
			};

			#endregion

			#region Act

			var response = await _fixture.CustomerService.GetCustomerAsync(request);

			#endregion

			#region Assert

			using (new AssertionScope())
			{
				response.Success.Should().BeTrue();
				response.Customer.Should().NotBeNull();
			}

			#endregion
		}


		[Fact]
		public async Task FailToGetCustomer_When_IdDoesNotExist()
		{
			#region Arrange

			var request = new GetCustomerRequest
			{
				Id = 32332
			};

			#endregion

			#region Act

			await Assert.ThrowsAsync<ResourceNotFoundException>(async () => await _fixture.CustomerService.GetCustomerAsync(request));

			#endregion
		}


		#endregion

		#endregion
	}
}
