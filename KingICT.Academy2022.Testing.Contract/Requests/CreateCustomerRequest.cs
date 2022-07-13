using KingICT.Academy2022.Testing.Contract.Requests.Common;
using KingICT.Academy2022.Testing.Contract.Views;

namespace KingICT.Academy2022.Testing.Contract.Requests
{
	public class CreateCustomerRequest : RequestBase
	{
		public CreateCustomerView Customer { get; set; }
	}
}
