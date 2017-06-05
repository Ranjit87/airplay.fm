using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SQLSoundManagement_BL.BusinessLayer.DataLayer;

namespace SQLSoundManagement_BL.BusinessLayer
{
    public class clsCompaniesFactory
    {

        #region data Members

        clsCompaniesSql _dataObject = null;

        #endregion

        #region Constructor

        public clsCompaniesFactory()
        {
            _dataObject = new clsCompaniesSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new clsCompanies
        /// </summary>
        /// <param name="businessObject">clsCompanies object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(clsCompanies businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing clsCompanies
        /// </summary>
        /// <param name="businessObject">clsCompanies object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(clsCompanies businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get clsCompanies by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public clsCompanies GetByPrimaryKey(clsCompaniesKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all clsCompaniess
        /// </summary>
        /// <returns>list</returns>
        public List<clsCompanies> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of clsCompanies by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<clsCompanies> GetAllBy(clsCompanies.clsCompaniesFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(clsCompaniesKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete clsCompanies by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(clsCompanies.clsCompaniesFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
