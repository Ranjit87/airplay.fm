using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SQLSoundManagement_BL.BusinessLayer.DataLayer;

namespace SQLSoundManagement_BL.BusinessLayer
{
    public partial class clsAudienceFigureFactory
    {

        #region data Members

        clsAudienceFiguresSql _dataObject = null;

        #endregion

        #region Constructor

        public clsAudienceFigureFactory()
        {
            _dataObject = new clsAudienceFiguresSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new clsAudienceFigures
        /// </summary>
        /// <param name="businessObject">clsAudienceFigures object</param>
        /// <returns>true for successfully saved</returns>
        public Int32 Insert(clsAudienceFigure businessObject, int FileType)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject, FileType);

        }

        #endregion
    }
}
