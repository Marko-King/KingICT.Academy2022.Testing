using KingICT.Academy2022.Testing.Contract;
using KingICT.Academy2022.Testing.Contract.Requests;
using KingICT.Academy2022.Testing.Contract.Views;
using Microsoft.AspNetCore.Mvc;

namespace KingICT.Academy2022.Testing.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CustomerController : ControllerBase
	{

		#region Fields

		private readonly ICustomerService _customerService;

		#endregion

		#region Constructors

		public CustomerController(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Returns a list of customers with pagination 
		/// </summary>
		/// <param name="pageSize">Number of elements per page (max 15)</param>
		/// <param name="pageNumber">Page number starting from 1</param>
		/// <returns></returns>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<CustomerView>>> GetCustomersAsync([FromQuery] int pageSize, [FromQuery] int pageNumber)
		{
			var request = new GetCustomerQueryRequest
			{
				PageSize = pageSize,
				PageNumber = pageNumber
			};

			var response = await _customerService.GetCustomerQueryAsync(request);

			return Ok(response.Customers);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<CustomerView>> GetCustomerAsync([FromRoute] long id)
		{
			var request = new GetCustomerRequest
			{
				Id = id
			};

			var response = await _customerService.GetCustomerAsync(request);

			return Ok(response.Customer);
		}


		[HttpPost("Create")]
		public async Task<ActionResult<CustomerView>> CreateCustomerAsync(CreateCustomerView customer)
		{
			var request = new CreateCustomerRequest
			{
				Customer = customer
			};

			var response = await _customerService.CreateCustomerAsync(request);

			return Ok(response.Customer);
		}

		[HttpPut("Update")]
		public async Task<ActionResult<CustomerView>> UpdateCustomerAsync(UpdateCustomerView customer)
		{
			var request = new UpdateCustomerRequest
			{
				Customer = customer
			};

			var response = await _customerService.UpdateCustomerAsync(request);

			return Ok(response.Customer);
		}

		[HttpDelete("Delete/{id}")]
		public async Task<IActionResult> DeleteCustomerAsync([FromRoute] long id)
		{
			var request = new DeleteCustomerRequest
			{
				Id = id
			};

			await _customerService.DeleteCustomerAsync(request);

			return Ok();
		}

		#endregion
	}
}
