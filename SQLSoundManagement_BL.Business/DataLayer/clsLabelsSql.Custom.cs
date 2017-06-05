using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SQLSoundManagement_BL.BusinessLayer.DataLayer
{
	/// <summary>
	/// Data access layer class for clsLabels
	/// </summary>
	partial class clsLabelsSql : DataLayerBase 
	{
        public DataSet SelectAllInTable(int pageNumber, int PageSize, string sortcolumn)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_Label_SelectAllInTable]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@pageSize", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, PageSize));
                sqlCommand.Parameters.Add(new SqlParameter("@pageNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pageNumber));
                sqlCommand.Parameters.Add(new SqlParameter("@SORTCOLUMN", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, sortcolumn));
                MainConnection.Open();

                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception("clsCompanies::SelectAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
	}
}
