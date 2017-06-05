using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SQLSoundManagement_BL.BusinessLayer.DataLayer
{
    partial class clsPromotionSql : DataLayerBase
    {
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public clsPromotionSql()
        {
            // Nothing for now.
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Select all rescords
        /// </summary>
        /// <returns>list of clsLabels</returns>
        public DataTable SelectAll(string FromMonth, string ToMonth, int CurrentYear, int IsAll)
        {
            SqlCommand sqlCommand = new SqlCommand();
            if (IsAll == 1)
            {
                sqlCommand.CommandText = "dbo.[sp_GetPromotions]";
            }
            else
            {
                sqlCommand.CommandText = "dbo.[sp_GetPromotionsByMonth]";
            }
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                if (IsAll == 0)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@FromMonth", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, FromMonth));
                    sqlCommand.Parameters.Add(new SqlParameter("@ToMonth", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ToMonth));
                    sqlCommand.Parameters.Add(new SqlParameter("@Year", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, CurrentYear));
                }



                MainConnection.Open();

                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception("clsPromotion::SelectAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }


        public DataSet SelectAllWithPaging(int pageNumber, int PageSize, string sortcolumn, string Keyword)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_Promotion_SelectAll]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            if (string.IsNullOrEmpty(Keyword))
            {
                Keyword = string.Empty;
            }

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@pageSize", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, PageSize));
                sqlCommand.Parameters.Add(new SqlParameter("@pageNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pageNumber));
                sqlCommand.Parameters.Add(new SqlParameter("@SORTCOLUMN", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, sortcolumn));
                sqlCommand.Parameters.Add(new SqlParameter("@Keyword", SqlDbType.VarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Keyword));


                MainConnection.Open();

                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception("clsPromotion::SelectAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public DataSet SelectSongByPromoterID(int PromoterID, string FromMonth, string ToMonth, int CurrentYear, int IsAll, int pageNumber, int PageSize, string sortcolumn, string Keyword)
        {
            SqlCommand sqlCommand = new SqlCommand();
            if (IsAll == 1)
            {
                sqlCommand.CommandText = "dbo.[sp_Songs_ByPromoterID_All]";
            }
            else
            {
                sqlCommand.CommandText = "dbo.[sp_Songs_ByPromoterID]";
            }

            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@pageSize", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, PageSize));
                sqlCommand.Parameters.Add(new SqlParameter("@pageNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pageNumber));
                sqlCommand.Parameters.Add(new SqlParameter("@SORTCOLUMN", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, sortcolumn));
                sqlCommand.Parameters.Add(new SqlParameter("@Keyword", SqlDbType.VarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Keyword));


                if (IsAll == 0)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@PromoterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, PromoterID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromMonth", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, FromMonth));
                    sqlCommand.Parameters.Add(new SqlParameter("@ToMonth", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ToMonth));
                    sqlCommand.Parameters.Add(new SqlParameter("@Year", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, CurrentYear));
                }
                else
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@PromoterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, PromoterID));
                    
                }

                MainConnection.Open();

                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception("clsPromotion::SelectAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        #endregion

    }
}
