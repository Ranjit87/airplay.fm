using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SQLSoundManagement_BL.BusinessLayer.DataLayer;

namespace SQLSoundManagement_BL.BusinessLayer
{
    public class clsLabelsFactory
    {

        #region data Members

        clsLabelsSql _dataObject = null;

        #endregion

        #region Constructor

        public clsLabelsFactory()
        {
            _dataObject = new clsLabelsSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new clsLabels
        /// </summary>
        /// <param name="businessObject">clsLabels object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(clsLabels businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing clsLabels
        /// </summary>
        /// <param name="businessObject">clsLabels object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(clsLabels businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get clsLabels by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public clsLabels GetByPrimaryKey(clsLabelsKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all clsLabelss
        /// </summary>
        /// <returns>list</returns>
        public List<clsLabels> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of clsLabels by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<clsLabels> GetAllBy(clsLabels.clsLabelsFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(clsLabelsKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete clsLabels by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(clsLabels.clsLabelsFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
