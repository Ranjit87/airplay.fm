using System;
using System.Collections.Generic;
using System.Text;
namespace SQLSoundManagement_BL.BusinessLayer
{
	public class clsSongsKeys
	{

		#region Data Members

		int _idSong;

		#endregion

		#region Constructor

		public clsSongsKeys(int idSong)
		{
			 _idSong = idSong; 
		}

		#endregion

		#region Properties

		public int  IdSong
		{
			 get { return _idSong; }
		}

		#endregion

	}
}
