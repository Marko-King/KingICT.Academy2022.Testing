using KingICT.Academy2022.Testing.Model;
using KingICT.Academy2022.Testing.Model.Query;

namespace KingICT.Academy2022.Testing.MockRepository
{
	public class CustomerRepositoryMock : ICustomerRepository
	{

		#region Fields

		private readonly IEnumerable<Customer> _customersDatabaseTableMock;

		#endregion

		#region Constructors

		public CustomerRepositoryMock()
		{
			_customersDatabaseTableMock = new List<Customer>()
					{
						new Customer(1, "Marko", "Pogačić", "095695959", DateTime.Now, null),
						new Customer(2, "Ivan", "Ivić", "056565656", DateTime.Now, DateTime.Now.AddMinutes(3)),
						new Customer(3, "Pero", "Perić", "0956565656", DateTime.Now, null),
					}.AsEnumerable();
		}

		#endregion

		#region Public Methods

		public Task CreateCustomerAsync(Customer customer)
		{
			throw new NotImplementedException();
		}

		public Task DeleteCustomerAsync(Customer customer)
		{
			throw new NotImplementedException();
		}

		public Task<Customer> GetCustomerAsync(long id)
		{
			return Task.FromResult(_customersDatabaseTableMock.FirstOrDefault(x=> x.Id == id));
		}

		public Task<IEnumerable<Customer>> GetCustomerQueryAsync(GetCustomerQuery query)
		{
			return Task.FromResult(_customersDatabaseTableMock);
		}

		public Task UpdateCustomerAsync(Customer customer)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
