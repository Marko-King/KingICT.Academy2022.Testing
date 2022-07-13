using KingICT.Academy2022.Testing.Contract.Requests;
using KingICT.Academy2022.Testing.Contract.Responses;

namespace KingICT.Academy2022.Testing.Contract
{
	public interface ICustomerService
	{
		Task<GetCustomerQueryResponse> GetCustomerQueryAsync(GetCustomerQueryRequest request);

		Task<GetCustomerResponse> GetCustomerAsync(GetCustomerRequest request);

		Task<CreateCustomerResponse> CreateCustomerAsync(CreateCustomerRequest request);

		Task<UpdateCustomerResponse> UpdateCustomerAsync(UpdateCustomerRequest request);

		Task<DeleteCustomerResponse> DeleteCustomerAsync(DeleteCustomerRequest request);
	}
}
