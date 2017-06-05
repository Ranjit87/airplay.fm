using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SQLSoundManagement_BL.BusinessLayer.DataLayer
{
    /// <summary>
    /// Data access layer class for clsAudienceFigures
    /// </summary>
    partial class clsAudienceFiguresSql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public clsAudienceFiguresSql()
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
        public Int32 Insert(clsAudienceFigure businessObject, int FileType)
        {
            int IdRow = -1;
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                MainConnection.Close();
                sqlCommand.Dispose();

                sqlCommand = new SqlCommand();

                if (FileType == 1)
                {
                    sqlCommand.CommandText = "dbo.[sp_AudienceRadio_Insert]";
                }
                else if (FileType == 2)
                {
                    sqlCommand.CommandText = "dbo.[sp_AudienceFigures_Insert]";
                }

                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Use connection object of base class
                sqlCommand.Connection = MainConnection;
                //sqlCommand.CommandTimeout = 60;

                if (FileType == 1)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@RadioId", SqlDbType.Int, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.RadioId));
                    sqlCommand.Parameters.Add(new SqlParameter("@Interval", SqlDbType.Int, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Interval));
                    sqlCommand.Parameters.Add(new SqlParameter("@Audience", SqlDbType.Decimal, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Audience));
                }
                else if (FileType == 2)
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@RadioId", SqlDbType.Int, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.RadioId));
                    sqlCommand.Parameters.Add(new SqlParameter("@Interval", SqlDbType.Int, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Interval));
                    sqlCommand.Parameters.Add(new SqlParameter("@Audience", SqlDbType.Decimal, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Audience));
                    sqlCommand.Parameters.Add(new SqlParameter("@RadioName", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.RadioName));
                    sqlCommand.Parameters.Add(new SqlParameter("@Semester", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Semester));
                    sqlCommand.Parameters.Add(new SqlParameter("@TotalAudience", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TotalAudience));
                }
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                //IdRow = (int)sqlCommand.Parameters["@IdRow"].Value;
                IdRow = 1;
                return IdRow;
            }
            catch (Exception ex)
            {
                IdRow = -1;
                return -1;
                //throw new Exception("clsAudienceFigure::Insert::Error occured.", ex);
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
