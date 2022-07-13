using KingICT.Academy2022.Testing.Model.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingICT.Academy2022.Testing.Model.Query
{
	[NotMapped]
	public class GetCustomerQuery : ValidationEntity
	{
		#region Properties

		public int PageSize { get; private set; }

		public int PageNumber { get; private set; }

		#endregion

		#region Constructors

		public GetCustomerQuery(int pageSize, int pageNumber)
		{
			PageNumber = pageNumber;
			PageSize = pageSize;
		}

		#endregion

		#region Validation Entity

		public void Validate()
		{
			if(PageNumber < 1)
			{
				AddBrokenRule("Page number must be at least 1.");
			}

			if(PageSize <= 1)
			{
				AddBrokenRule("At least one element per page.");
			}

			if(PageSize > 15)
			{
				AddBrokenRule("Maximum number of elements per page is 15.");
			}

			base.ThrowExceptionIfThereAreBrokenRules();
		}

		#endregion
	}
}
