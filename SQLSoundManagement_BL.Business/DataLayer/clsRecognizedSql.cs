using SQLSoundManagement_BL.BusinessLayer.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SQLSoundManagement_BL.BusinessLayer.DataLayer
{
    partial class clsRecognizedSql : DataLayerBase
    {
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public clsRecognizedSql()
        {
            // Nothing for now.
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// insert new row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true of successfully insert</returns>
        public Int32 Insert(clsRecognized businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                MainConnection.Close();
                sqlCommand.Dispose();

                sqlCommand = new SqlCommand();

                sqlCommand.CommandText = "dbo.[sp_Recognized_Temp_Insert]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = MainConnection;

                sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
                sqlCommand.Parameters.Add(new SqlParameter("@FileName", SqlDbType.NVarChar, 512, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FileName));
                sqlCommand.Parameters.Add(new SqlParameter("@IdRadio", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IdRadio));
                sqlCommand.Parameters.Add(new SqlParameter("@Hour", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Hour));
                sqlCommand.Parameters.Add(new SqlParameter("@FingerprintingTime", SqlDbType.DateTime, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FingerprintingTime));
                sqlCommand.Parameters.Add(new SqlParameter("@FingerprintingDetails", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FingerprintingDetails));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                businessObject.ID = (int)sqlCommand.Parameters["@ID"].Value;

                return businessObject.ID;
            }
            catch (Exception ex)
            {
                businessObject.ID = -1;
                return -1;
                //throw new Exception("clsRecognized::Insert::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public DataSet GetAllRecognized(int pageNumber, int PageSize)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_Recognized_Temp_SelectAll]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@pageSize", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, PageSize));
                sqlCommand.Parameters.Add(new SqlParameter("@pageNumber", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pageNumber));

                MainConnection.Open();

                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception("clsRecognized::SelectAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public int GetAllRecognizedDelete()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_Recognized_Temp_DeleteAll]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataSet dt = new DataSet();
                da.Fill(dt);
                return 1;

            }
            catch (Exception ex)
            {
                throw new Exception("clsRecognized::AllDelete::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public int SaveAllInRecognized()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_Recognized_TempTo_Recognized_Save]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataSet dt = new DataSet();
                da.Fill(dt);
                return 1;

            }
            catch (Exception ex)
            {
                throw new Exception("clsRecognized::AllDelete::Error occured.", ex);
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
