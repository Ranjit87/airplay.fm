using System;
using System.Collections.Generic;
using System.Text;
namespace SQLSoundManagement_BL.BusinessLayer
{
	public class clsCompaniesKeys
	{

		#region Data Members

		int _id;

		#endregion

		#region Constructor

		public clsCompaniesKeys(int id)
		{
			 _id = id; 
		}

		#endregion

		#region Properties

		public int  Id
		{
			 get { return _id; }
		}

		#endregion

	}
}
