using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SQLSoundManagement_BL.BusinessLayer.DataLayer;

namespace SQLSoundManagement_BL.BusinessLayer
{
    public partial class clsCompaniesFactory
    {
        public DataSet GetAllInTable(int pageNumber, int PageSize, string sortcolumn)
        {
            return _dataObject.SelectAllInTable(pageNumber, PageSize,sortcolumn);
        }
    }
}
