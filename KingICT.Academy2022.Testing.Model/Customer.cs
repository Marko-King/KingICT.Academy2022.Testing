using KingICT.Academy2022.Testing.Model.Common;
using System.Text.RegularExpressions;

namespace KingICT.Academy2022.Testing.Model
{
	public class Customer : ValidationEntity
	{

		#region Properties

		public long Id { get; private set; }

		public string FirstName { get; private set; }

		public string LastName { get; private set; }

		public string PhoneNumber { get; private set; }

		public DateTime DateCreated { get; private set; }

		public DateTime? DateUpdated { get; private set; }

		#endregion

		#region Constructors

		public Customer()
		{

		}

		public Customer(long id, string firstName, string lastName, string phoneNumber, DateTime dateCreated, DateTime? dateUpdated)
			:base()
		{
			Id = id;
			FirstName = firstName;
			LastName = lastName;
			PhoneNumber = phoneNumber;
			DateCreated = dateCreated;
			DateUpdated = dateUpdated;
		}

		#endregion

		#region Public Methods

		#region ValidationEntity

		public void ValidateForCreate()
		{
			if (string.IsNullOrWhiteSpace(FirstName))
			{
				AddBrokenRule("FirstName is required.");
			}else if (Char.IsLower(FirstName.First()))
			{
				AddBrokenRule("FirstName must start with capital letter.");
			}

			if (string.IsNullOrWhiteSpace(LastName))
			{
				AddBrokenRule("LastName is required.");
			}
			else if (Char.IsLower(LastName.First()))
			{
				AddBrokenRule("LastName must start with capital letter.");
			}

			if (string.IsNullOrWhiteSpace(PhoneNumber))
			{
				AddBrokenRule("PhoneNumber is required.");
			}
			else
			{
				var reg = new Regex("^[0-9]+$");
				if (!reg.IsMatch(PhoneNumber))
				{
					AddBrokenRule("PhoneNumber must contain only numbers.");
				}
			}

			base.ThrowExceptionIfThereAreBrokenRules();
		}

		public void ValidateForUpdate()
		{
			if(Id == default)
			{
				AddBrokenRule("Id is required for update");
			}

			ValidateForCreate();

			base.ThrowExceptionIfThereAreBrokenRules();
		}

		#endregion

		public void SetFirstName(string firstName)
		{
			FirstName = firstName;
		}

		public void SetLastName(string lastName)
		{
			LastName = lastName;
		}
		public void SetPhoneNumber(string phoneNumber)
		{
			PhoneNumber = phoneNumber;
		}

		public void SetDateCreated() 
		{
			DateCreated = DateTime.Now;
		}

		public void SetDateUpdated()
		{
			DateUpdated = DateTime.Now;
		}

		#endregion
	}
}
