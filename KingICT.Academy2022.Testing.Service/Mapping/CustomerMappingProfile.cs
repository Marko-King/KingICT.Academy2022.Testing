using AutoMapper;
using KingICT.Academy2022.Testing.Contract.Views;
using KingICT.Academy2022.Testing.Model;

namespace KingICT.Academy2022.Testing.Service.Mapping
{
	public class CustomerMappingProfile : Profile
	{
		public CustomerMappingProfile()
		{
			#region To View

			CreateMap<Customer, CustomerView>();

			#endregion
		}
	}
}
