using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SQLSoundManagement_BL.BusinessLayer.DataLayer
{
	/// <summary>
	/// Data access layer class for clsCompanies
	/// </summary>
	partial class clsCompaniesSql : DataLayerBase 
	{
        public List<clsCompanies> SelectAllSuggestion(string prefix)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_Companies_SelectAll]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@suggestion", prefix));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

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

        public DataSet SelectAllInTable(int pageNumber, int PageSize, string sortcolumn)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_Companies_SelectAllInTable]";
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
