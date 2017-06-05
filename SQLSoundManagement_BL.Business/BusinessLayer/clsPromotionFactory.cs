using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SQLSoundManagement_BL.BusinessLayer.DataLayer;

namespace SQLSoundManagement_BL.BusinessLayer
{
    public partial class clsPromotionFactory
    {
        #region data Members

        clsPromotionSql _dataObject = null;

        #endregion

        #region Constructor

        public clsPromotionFactory()
        {
            _dataObject = new clsPromotionSql();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// get list of all clsSongss
        /// </summary>
        /// <returns>list</returns>
        public DataTable GetAll(string FromMonth, string ToMonth, int CurrentYear, int IsAll)
        {
            return _dataObject.SelectAll(FromMonth, ToMonth, CurrentYear, IsAll);
        }

        /// <summary>
        /// get list of all clsPromotion
        /// </summary>
        /// <returns>list</returns>
        public DataSet GetAllWithPaging(int pageNumber, int PageSize, string sortcolumn, string Keyword)
        {
            return _dataObject.SelectAllWithPaging(pageNumber, PageSize, sortcolumn, Keyword);
        }

        /// <summary>
        /// get list of all clsSongss
        /// </summary>
        /// <returns>list</returns>
        public DataSet GetSongByPromoterID(int PromoterID, string FromMonth, string ToMonth, int CurrentYear, int IsAll, int pageNumber, int PageSize, string sortcolumn, string Keyword)
        {
            return _dataObject.SelectSongByPromoterID(PromoterID, FromMonth.ToLower(), ToMonth.ToLower(), CurrentYear, IsAll, pageNumber, PageSize, sortcolumn, Keyword);
        }

        #endregion
    }
}
