using KingICT.Academy2022.Testing.Model.Query;

namespace KingICT.Academy2022.Testing.Model
{
	public interface ICustomerRepository
	{
		Task<IEnumerable<Customer>> GetCustomerQueryAsync(GetCustomerQuery query);

		Task<Customer> GetCustomerAsync(long id);
		
		Task CreateCustomerAsync(Customer customer);

		Task UpdateCustomerAsync(Customer customer);

		Task DeleteCustomerAsync(Customer customer);
	}
}
