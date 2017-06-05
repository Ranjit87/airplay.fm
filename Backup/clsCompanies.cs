using System;
using System.Collections.Generic;
using System.Text;
namespace SQLSoundManagement_BL.BusinessLayer
{
	public class clsCompanies: BusinessObjectBase
	{

		#region InnerClass
		public enum clsCompaniesFields
		{
			Id,
			Company,
			Data,
			FullName
		}
		#endregion

		#region Data Members

			int _id;
			string _company;
			bool _data;
			string _fullName;

		#endregion

		#region Properties

		public int  Id
		{
			 get { return _id; }
			 set
			 {
				 if (_id != value)
				 {
					_id = value;
					 PropertyHasChanged("Id");
				 }
			 }
		}

		public string  Company
		{
			 get { return _company; }
			 set
			 {
				 if (_company != value)
				 {
					_company = value;
					 PropertyHasChanged("Company");
				 }
			 }
		}

		public bool  Data
		{
			 get { return _data; }
			 set
			 {
				 if (_data != value)
				 {
					_data = value;
					 PropertyHasChanged("Data");
				 }
			 }
		}

		public string  FullName
		{
			 get { return _fullName; }
			 set
			 {
				 if (_fullName != value)
				 {
					_fullName = value;
					 PropertyHasChanged("FullName");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Id", "Id"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Company", "Company"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Company", "Company",400));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Data", "Data"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("FullName", "FullName",2147483647));
		}

		#endregion

	}
}
