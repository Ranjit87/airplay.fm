using System;
using System.Collections.Generic;
using System.Text;
namespace SQLSoundManagement_BL.BusinessLayer
{
	public class clsJP_ADMIN: BusinessObjectBase
	{

		#region InnerClass
		public enum clsJP_ADMINFields
		{
			Username,
			Pswd
		}
		#endregion

		#region Data Members

			string _username;
			string _pswd;

		#endregion

		#region Properties

		public string  Username
		{
			 get { return _username; }
			 set
			 {
				 if (_username != value)
				 {
					_username = value;
					 PropertyHasChanged("Username");
				 }
			 }
		}

		public string  Pswd
		{
			 get { return _pswd; }
			 set
			 {
				 if (_pswd != value)
				 {
					_pswd = value;
					 PropertyHasChanged("Pswd");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Username", "Username",45));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Pswd", "Pswd",45));
		}

		#endregion

	}
}
