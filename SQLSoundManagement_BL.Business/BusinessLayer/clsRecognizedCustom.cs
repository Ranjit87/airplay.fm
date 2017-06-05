using SQLSoundManagement_BL.BusinessLayer.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SQLSoundManagement_BL.BusinessLayer.BusinessLayer
{
    public partial class clsRecognizedFactory
    {
        #region data Members

        clsRecognizedSql _dataObject = null;

        #endregion

        #region Constructor

        public clsRecognizedFactory()
        {
            _dataObject = new clsRecognizedSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new clsRecognized
        /// </summary>
        /// <param name="businessObject">clsRecognized object</param>
        /// <returns>true for successfully saved</returns>
        public Int32 Insert(clsRecognized businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }
            return _dataObject.Insert(businessObject);
        }

        /// <summary>
        /// get list of all GetAllRecognized
        /// </summary>
        /// <returns>list</returns>
        public DataSet GetAllRecognized(int pageNumber, int PageSize)
        {
            return _dataObject.GetAllRecognized(pageNumber, PageSize);
        }

        /// <summary>
        /// GetAllRecognizedDelete
        /// </summary>
        /// <returns>list</returns>
        public int GetAllRecognizedDelete()
        {
            return _dataObject.GetAllRecognizedDelete();
        }

        /// <summary>
        /// SaveAllInRecognized
        /// </summary>
        /// <returns>list</returns>
        public int SaveAllInRecognized()
        {
            return _dataObject.SaveAllInRecognized();
        }




        #endregion

    }
}
