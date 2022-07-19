using KingICT.Academy2022.Testing.Contract.Requests;
using Xunit;

namespace KingICT.Academy2022.Testing.Tests
{
	public class CustomerServiceTestData
	{
		public static TheoryData<GetCustomerQueryRequest> GetInvalidCustomerQueryRequests => new TheoryData<GetCustomerQueryRequest>
		{
			new GetCustomerQueryRequest
			{
				PageNumber = 1,
				PageSize = -1,
			},
			new GetCustomerQueryRequest
			{
				PageNumber = 1,
				PageSize = 0,
			},
			new GetCustomerQueryRequest
			{
				PageNumber = 1,
				PageSize = 16,
			},
			new GetCustomerQueryRequest
			{
				PageNumber = -5,
				PageSize = 10,
			},
			new GetCustomerQueryRequest
			{
				PageNumber = 0,
				PageSize = 10,
			}
		};
	}
}
