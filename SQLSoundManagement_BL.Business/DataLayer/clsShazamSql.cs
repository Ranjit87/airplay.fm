using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SQLSoundManagement_BL.BusinessLayer.DataLayer
{
    /// <summary>
    /// Data access layer class for clsSongs
    /// </summary>
    partial class clsShazamSql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public clsShazamSql()
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
        public Int32 Insert(clsShazam businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                MainConnection.Close();
                sqlCommand.Dispose();

                sqlCommand = new SqlCommand();

                sqlCommand.CommandText = "dbo.[sp_Digital_Shazam_Insert]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Use connection object of base class
                sqlCommand.Connection = MainConnection;
                //sqlCommand.CommandTimeout = 60;



                sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
                sqlCommand.Parameters.Add(new SqlParameter("@Week", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Week));
                sqlCommand.Parameters.Add(new SqlParameter("@Year", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Year));
                sqlCommand.Parameters.Add(new SqlParameter("@Position", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Position));
                sqlCommand.Parameters.Add(new SqlParameter("@Artist", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Artist));
                sqlCommand.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Title));
                

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                businessObject.ID = (int)sqlCommand.Parameters["@ID"].Value;

                return businessObject.ID;
            }
            catch (Exception ex)
            {
                businessObject.ID = -1;
                return -1;
                //throw new Exception("clsSongs::Insert::Error occured.", ex);
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
