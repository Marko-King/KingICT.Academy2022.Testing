using AutoMapper;
using KingICT.Academy2022.Testing.Contract;
using KingICT.Academy2022.Testing.Contract.Requests;
using KingICT.Academy2022.Testing.Contract.Responses;
using KingICT.Academy2022.Testing.Contract.Views;
using KingICT.Academy2022.Testing.Infrastructure.Exceptions;
using KingICT.Academy2022.Testing.Model;
using KingICT.Academy2022.Testing.Model.Query;

namespace KingICT.Academy2022.Testing.Service
{
	public class CustomerService : ICustomerService
	{

		#region Fields

		private readonly ICustomerRepository _customerRepository;
		private readonly IMapper _mapper;

		#endregion

		#region Constructors

		public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
		{
			_customerRepository = customerRepository;
			_mapper = mapper;
		}

		#endregion

		#region ICustomerService

		public async Task<GetCustomerQueryResponse> GetCustomerQueryAsync(GetCustomerQueryRequest request)
		{
			var query = new GetCustomerQuery(request.PageSize, request.PageNumber);
			query.Validate();

			var response = await _customerRepository.GetCustomerQueryAsync(query);

			return new GetCustomerQueryResponse
			{
				Success = true,
				Customers = _mapper.Map<IEnumerable<CustomerView>>(response)
			};
		}

		public async Task<GetCustomerResponse> GetCustomerAsync(GetCustomerRequest request)
		{
			var customer = await _customerRepository.GetCustomerAsync(request.Id);

			if(customer == null)
			{
				throw new ResourceNotFoundException();
			}

			return new GetCustomerResponse 
			{ 
				Success = true,
				Customer = _mapper.Map<CustomerView>(customer)
			};
		}

		public async Task<CreateCustomerResponse> CreateCustomerAsync(CreateCustomerRequest request)
		{
			var customer = new Customer();
			customer.SetFirstName(request.Customer.FirstName);
			customer.SetLastName(request.Customer.LastName);
			customer.SetPhoneNumber(request.Customer.PhoneNumber);
			customer.SetDateCreated();

			customer.ValidateForCreate();

			await _customerRepository.CreateCustomerAsync(customer);

			return new CreateCustomerResponse
			{
				Success = true,
				Customer = _mapper.Map<CustomerView>(customer)
			};
		}

		public async Task<UpdateCustomerResponse> UpdateCustomerAsync(UpdateCustomerRequest request)
		{
			var customer = await _customerRepository.GetCustomerAsync(request.Customer.Id);

			if(customer == null)
			{
				throw new ResourceNotFoundException();
			}

			customer.SetFirstName(request.Customer.FirstName);
			customer.SetLastName(request.Customer.LastName);
			customer.SetPhoneNumber(request.Customer.PhoneNumber);
			customer.SetDateUpdated();

			customer.ValidateForUpdate();

			await _customerRepository.UpdateCustomerAsync(customer);

			return new UpdateCustomerResponse
			{
				Success = true,
				Customer = _mapper.Map<CustomerView>(customer)
			};
		}

		public async Task<DeleteCustomerResponse> DeleteCustomerAsync(DeleteCustomerRequest request)
		{
			var customer = await _customerRepository.GetCustomerAsync(request.Id);

			if (customer == null)
			{
				throw new ResourceNotFoundException();
			}

			await _customerRepository.DeleteCustomerAsync(customer);

			return new DeleteCustomerResponse
			{
				Success = true
			};
		}

		#endregion
	}
}
