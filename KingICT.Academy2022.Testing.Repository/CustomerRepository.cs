using KingICT.Academy2022.Testing.Model;
using KingICT.Academy2022.Testing.Model.Query;
using Microsoft.EntityFrameworkCore;

namespace KingICT.Academy2022.Testing.Repository
{
	public class CustomerRepository : ICustomerRepository
	{

		#region Fields

		private readonly AppDbContext _context;

		#endregion

		#region Constructors

		public CustomerRepository(AppDbContext context)
		{
			_context = context;
		}

		#endregion

		#region ICustomerRepository

		public async Task<IEnumerable<Customer>> GetCustomerQueryAsync(GetCustomerQuery query)
		{
			return await _context.Customers
								 .Skip(query.PageSize * (query.PageNumber - 1))
								 .Take(query.PageSize)
								 .ToListAsync();
		}

		public async Task<Customer> GetCustomerAsync(long id)
		{
			return await _context.Customers.SingleOrDefaultAsync(x => x.Id == id);
		}

		public async Task CreateCustomerAsync(Customer customer)
		{
			await _context.AddAsync(customer);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateCustomerAsync(Customer customer)
		{
			_context.Update(customer);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteCustomerAsync(Customer customer)
		{
			_context.Remove(customer);
			await _context.SaveChangesAsync();
		}

		#endregion
	}
}
