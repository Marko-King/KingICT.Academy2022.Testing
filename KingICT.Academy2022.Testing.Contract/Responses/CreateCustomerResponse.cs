using KingICT.Academy2022.Testing.Contract.Responses.Common;
using KingICT.Academy2022.Testing.Contract.Views;

namespace KingICT.Academy2022.Testing.Contract.Responses
{
	public class CreateCustomerResponse : ResponseBase
	{
		public CustomerView Customer { get; set; }
	}
}
