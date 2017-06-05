using System;
using System.Collections.Generic;
using System.Text;
namespace SQLSoundManagement_BL.BusinessLayer
{
	public class clsLabelsKeys
	{

		#region Data Members

		int _id;

		#endregion

		#region Constructor

		public clsLabelsKeys(int id)
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
