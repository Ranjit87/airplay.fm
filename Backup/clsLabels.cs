using System;
using System.Collections.Generic;
using System.Text;
namespace SQLSoundManagement_BL.BusinessLayer
{
	public class clsLabels: BusinessObjectBase
	{

		#region InnerClass
		public enum clsLabelsFields
		{
			Id,
			Title,
			Data
		}
		#endregion

		#region Data Members

			int _id;
			string _title;
			bool _data;

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

		public string  Title
		{
			 get { return _title; }
			 set
			 {
				 if (_title != value)
				 {
					_title = value;
					 PropertyHasChanged("Title");
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


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Id", "Id"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Title", "Title"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Title", "Title",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Data", "Data"));
		}

		#endregion

	}
}
