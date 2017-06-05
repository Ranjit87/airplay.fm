using System;
using System.Collections.Generic;
using System.Text;
namespace SQLSoundManagement_BL.BusinessLayer
{
    public class clsEmergentiKeys
    {
        #region Data Members

		int _id;

		#endregion

		#region Constructor

        public clsEmergentiKeys(int id)
		{
			 _id = id; 
		}

		#endregion

		#region Properties

		public int  ID
		{
			 get { return _id; }
		}

		#endregion
    }
}
