using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SQLSoundManagement_BL.BusinessLayer.DataLayer;

namespace SQLSoundManagement_BL.BusinessLayer
{
    public partial class clsShazamFactory
    {

        #region data Members

        clsShazamSql _dataObject = null;

        #endregion

        #region Constructor

        public clsShazamFactory()
        {
            _dataObject = new clsShazamSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new clsSongs
        /// </summary>
        /// <param name="businessObject">clsSongs object</param>
        /// <returns>true for successfully saved</returns>
        public Int32 Insert(clsShazam businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }
            return _dataObject.Insert(businessObject);
        }

        #endregion

    }
}
