using KingICT.Academy2022.Testing.Contract.Requests.Common;

namespace KingICT.Academy2022.Testing.Contract.Requests
{
	public class GetCustomerQueryRequest : RequestBase
	{
		public int PageSize { get; set; }

		public int PageNumber { get; set; }
	}
}
