using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SQLSoundManagement_BL.BusinessLayer.DataLayer;

namespace SQLSoundManagement_BL.BusinessLayer
{
    public partial class clsSongsFactory
    {

        #region data Members

        clsSongsSql _dataObject = null;

        #endregion

        #region Constructor

        public clsSongsFactory()
        {
            _dataObject = new clsSongsSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert Exisr Song Check
        /// </summary>
        /// <param name="businessObject">clsSongs object</param>
        /// <returns>true for Not Exist</returns>
        public Int32 InsertExist_Check(clsSongs businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.InsertExist_Check(businessObject);

        }

        /// <summary>
        /// Insert new clsSongs
        /// </summary>
        /// <param name="businessObject">clsSongs object</param>
        /// <returns>true for successfully saved</returns>
        public Int32 Insert(clsSongs businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing clsSongs
        /// </summary>
        /// <param name="businessObject">clsSongs object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(clsSongs businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get clsSongs by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public clsSongs GetByPrimaryKey(clsSongsKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all clsSongss
        /// </summary>
        /// <returns>list</returns>
        public DataSet GetAll(int pageNumber, int PageSize, string sortcolumn, string Keyword)
        {
            return _dataObject.SelectAll(pageNumber, PageSize, sortcolumn, Keyword);
        }

        /// <summary>
        /// get list of clsSongs by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<clsSongs> GetAllBy(clsSongs.clsSongsFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(clsSongsKeys keys)
        {
            return _dataObject.Delete(keys);
        }

        /// <summary>
        /// delete clsSongs by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(clsSongs.clsSongsFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        #endregion

    }
}
