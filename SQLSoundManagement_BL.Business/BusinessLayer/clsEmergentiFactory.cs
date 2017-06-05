using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SQLSoundManagement_BL.BusinessLayer.DataLayer;

namespace SQLSoundManagement_BL.BusinessLayer
{
    public partial class clsEmergentiFactory
    {

        #region data Members

        clsEmergentiSql _dataObject = null;

        #endregion

        #region Constructor

        public clsEmergentiFactory()
        {
            _dataObject = new clsEmergentiSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new clsEmergenti
        /// </summary>
        /// <param name="businessObject">clsEmergenti object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(clsEmergenti businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing clsEmergenti
        /// </summary>
        /// <param name="businessObject">clsEmergenti object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(clsEmergenti businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get clsEmergenti by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public clsEmergenti GetByPrimaryKey(clsEmergentiKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all clsEmergenti
        /// </summary>
        /// <returns>list</returns>
        public DataSet GetAll(int pageNumber, int PageSize, string sortcolumn, string Keyword)
        {
            return _dataObject.SelectAll(pageNumber, PageSize, sortcolumn, Keyword);
        }

        /// <summary>
        /// get list of clsEmergenti by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<clsEmergenti> GetAllBy(clsEmergenti.clsEmergentiFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(clsEmergentiKeys keys)
        {
            return _dataObject.Delete(keys);
        }

        /// <summary>
        /// delete clsEmergenti by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(clsEmergenti.clsEmergentiFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        #endregion
    }
}
