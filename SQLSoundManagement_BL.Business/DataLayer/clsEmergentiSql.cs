using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SQLSoundManagement_BL.BusinessLayer.DataLayer
{
    /// <summary>
    /// Data access layer class for clsEmergenti
    /// </summary>
    partial class clsEmergentiSql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public clsEmergentiSql()
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
        public bool Insert(clsEmergenti businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_Emergenti_Insert]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
                sqlCommand.Parameters.Add(new SqlParameter("@Settimana", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Settimana));
                sqlCommand.Parameters.Add(new SqlParameter("@Posizione", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Posizione));
                sqlCommand.Parameters.Add(new SqlParameter("@Artista", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Artista));
                sqlCommand.Parameters.Add(new SqlParameter("@Titolo", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Titolo));
                sqlCommand.Parameters.Add(new SqlParameter("@Etichetta", SqlDbType.VarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Etichetta));
                sqlCommand.Parameters.Add(new SqlParameter("@Anno", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Anno));


                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                businessObject.ID = (int)sqlCommand.Parameters["@Id"].Value;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsEmergenti::Insert::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        /// <summary>
        /// update row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true for successfully updated</returns>
        public bool Update(clsEmergenti businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_Emergenti_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
                sqlCommand.Parameters.Add(new SqlParameter("@Settimana", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Settimana));
                sqlCommand.Parameters.Add(new SqlParameter("@Posizione", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Posizione));
                sqlCommand.Parameters.Add(new SqlParameter("@Artista", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Artista));
                sqlCommand.Parameters.Add(new SqlParameter("@Titolo", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Titolo));
                sqlCommand.Parameters.Add(new SqlParameter("@Etichetta", SqlDbType.VarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Etichetta));
                sqlCommand.Parameters.Add(new SqlParameter("@Anno", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Anno));


                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsEmergenti::Update::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        /// <summary>
        /// Select by primary key
        /// </summary>
        /// <param name="keys">primary keys</param>
        /// <returns>clsEmergenti business object</returns>
        public clsEmergenti SelectByPrimaryKey(clsEmergentiKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_Emergenti_SelectByPrimaryKey]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.ID));


                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    clsEmergenti businessObject = new clsEmergenti();

                    PopulateBusinessObjectFromReader(businessObject, dataReader);

                    return businessObject;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsEmergenti::SelectByPrimaryKey::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        /// <summary>
        /// Select all rescords
        /// </summary>
        /// <returns>list of clsEmergenti</returns>
        public DataSet SelectAll(int pageNumber, int PageSize, string sortcolumn, string Keyword)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_Emergenti_SelectAll]";
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
                throw new Exception("clsEmergenti::SelectAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        /// <summary>
        /// Select records by field
        /// </summary>
        /// <param name="fieldName">name of field</param>
        /// <param name="value">value of field</param>
        /// <returns>list of clsEmergenti</returns>
        public List<clsEmergenti> SelectByField(string fieldName, object value)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_Emergenti_SelectByField]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@FieldName", fieldName));
                sqlCommand.Parameters.Add(new SqlParameter("@Value", value));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsEmergenti::SelectByField::Error occured.", ex);
            }
            finally
            {

                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        /// <summary>
        /// Delete by primary key
        /// </summary>
        /// <param name="keys">primary keys</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(clsEmergentiKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_Emergenti_DeleteByPrimaryKey]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.ID));


                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsEmergenti::DeleteByKey::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        /// <summary>
        /// Delete records by field
        /// </summary>
        /// <param name="fieldName">name of field</param>
        /// <param name="value">value of field</param>
        /// <returns>true for successfully deleted</returns>
        public bool DeleteByField(string fieldName, object value)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_Companies_DeleteByField]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@FieldName", fieldName));
                sqlCommand.Parameters.Add(new SqlParameter("@Value", value));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("clsEmergenti::DeleteByField::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReader(clsEmergenti businessObject, IDataReader dataReader)
        {
            businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(clsEmergenti.clsEmergentiFields.ID.ToString()));
            businessObject.Settimana = dataReader.GetString(dataReader.GetOrdinal(clsEmergenti.clsEmergentiFields.Settimana.ToString()));
            businessObject.Posizione = dataReader.GetString(dataReader.GetOrdinal(clsEmergenti.clsEmergentiFields.Posizione.ToString()));
            businessObject.Artista = dataReader.GetString(dataReader.GetOrdinal(clsEmergenti.clsEmergentiFields.Artista.ToString()));
            businessObject.Titolo = dataReader.GetString(dataReader.GetOrdinal(clsEmergenti.clsEmergentiFields.Titolo.ToString()));
            businessObject.Etichetta = dataReader.GetString(dataReader.GetOrdinal(clsEmergenti.clsEmergentiFields.Etichetta.ToString()));
            businessObject.Anno = dataReader.GetString(dataReader.GetOrdinal(clsEmergenti.clsEmergentiFields.Anno.ToString()));

            //if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsEmergenti.clsEmergentiFields.FullName.ToString())))
            //{
            //    businessObject.FullName = dataReader.GetString(dataReader.GetOrdinal(clsEmergenti.clsEmergentiFields.FullName.ToString()));
            //}
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsEmergenti</returns>
        internal List<clsEmergenti> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<clsEmergenti> list = new List<clsEmergenti>();

            while (dataReader.Read())
            {
                clsEmergenti businessObject = new clsEmergenti();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion
    }
}
