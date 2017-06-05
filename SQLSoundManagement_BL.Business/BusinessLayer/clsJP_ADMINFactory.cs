using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SQLSoundManagement_BL.BusinessLayer.DataLayer;

namespace SQLSoundManagement_BL.BusinessLayer
{
    public class clsJP_ADMINFactory
    {

        #region data Members

        clsJP_ADMINSql _dataObject = null;

        #endregion

        #region Constructor

        public clsJP_ADMINFactory()
        {
            _dataObject = new clsJP_ADMINSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new clsJP_ADMIN
        /// </summary>
        /// <param name="businessObject">clsJP_ADMIN object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(clsJP_ADMIN businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing clsJP_ADMIN
        /// </summary>
        /// <param name="businessObject">clsJP_ADMIN object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(clsJP_ADMIN businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get clsJP_ADMIN by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public clsJP_ADMIN GetByPrimaryKey(clsJP_ADMINKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all clsJP_ADMINs
        /// </summary>
        /// <returns>list</returns>
        public List<clsJP_ADMIN> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of clsJP_ADMIN by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<clsJP_ADMIN> GetAllBy(clsJP_ADMIN.clsJP_ADMINFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(clsJP_ADMINKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete clsJP_ADMIN by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(clsJP_ADMIN.clsJP_ADMINFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
