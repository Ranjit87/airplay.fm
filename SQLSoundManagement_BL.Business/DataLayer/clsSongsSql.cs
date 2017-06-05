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
    partial class clsSongsSql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public clsSongsSql()
        {
            // Nothing for now.
        }

        #endregion

        #region Public Methods

        #region Is Song Exist

        public Int32 InsertExist_Check(clsSongs businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                MainConnection.Close();
                sqlCommand.Dispose();
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "dbo.[sp_Songs_Insert_Check]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = MainConnection;

                sqlCommand.Parameters.Add(new SqlParameter("@IdSong", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IdSong));
                sqlCommand.Parameters.Add(new SqlParameter("@ARTIST", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ARTIST));
                sqlCommand.Parameters.Add(new SqlParameter("@TITLE", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TITLE));
                sqlCommand.Parameters.Add(new SqlParameter("@FILENAME", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FILENAME));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                businessObject.IdSong = (int)sqlCommand.Parameters["@IdSong"].Value;

                return businessObject.IdSong;
            }
            catch (Exception ex)
            {
                businessObject.IdSong = -1;
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

        /// <summary>
        /// insert new row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true of successfully insert</returns>
        public Int32 Insert(clsSongs businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                MainConnection.Close();
                sqlCommand.Dispose();

                sqlCommand = new SqlCommand();

                sqlCommand.CommandText = "dbo.[sp_Songs_Insert]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Use connection object of base class
                sqlCommand.Connection = MainConnection;
                //sqlCommand.CommandTimeout = 60;



                sqlCommand.Parameters.Add(new SqlParameter("@IdSong", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IdSong));
                sqlCommand.Parameters.Add(new SqlParameter("@GENRE", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.GENRE));
                sqlCommand.Parameters.Add(new SqlParameter("@LANGUAGE", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LANGUAGE));
                sqlCommand.Parameters.Add(new SqlParameter("@TVSHOW", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TVSHOW));
                sqlCommand.Parameters.Add(new SqlParameter("@ARTIST", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ARTIST));
                sqlCommand.Parameters.Add(new SqlParameter("@TITLE", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TITLE));
                sqlCommand.Parameters.Add(new SqlParameter("@VERSION", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.VERSION));
                sqlCommand.Parameters.Add(new SqlParameter("@LABEL", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LABEL));
                sqlCommand.Parameters.Add(new SqlParameter("@FILENAME", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FILENAME));
                sqlCommand.Parameters.Add(new SqlParameter("@Spotify", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Spotify));
                sqlCommand.Parameters.Add(new SqlParameter("@CompanyId", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CompanyId));
                sqlCommand.Parameters.Add(new SqlParameter("@LabelId", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LabelId));
                sqlCommand.Parameters.Add(new SqlParameter("@RadioDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.RadioDate));
                sqlCommand.Parameters.Add(new SqlParameter("@IncludeInFirstPlay", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IncludeInFirstPlay));
                sqlCommand.Parameters.Add(new SqlParameter("@IncludeInNewTalent", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IncludeInNewTalent));
                sqlCommand.Parameters.Add(new SqlParameter("@PromotionId", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PromotionId));
                sqlCommand.Parameters.Add(new SqlParameter("@SingRing", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SingRing));
                sqlCommand.Parameters.Add(new SqlParameter("@FirstPlayDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FirstPlayDate));
                sqlCommand.Parameters.Add(new SqlParameter("@ParentSongId", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ParentSongId));
                sqlCommand.Parameters.Add(new SqlParameter("@Lyric", SqlDbType.Text, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Lyric));
                sqlCommand.Parameters.Add(new SqlParameter("@AlternativeChart", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.AlternativeChart));

                sqlCommand.Parameters.Add(new SqlParameter("@Author", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Author));
                sqlCommand.Parameters.Add(new SqlParameter("@Publisher", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Publisher));
                sqlCommand.Parameters.Add(new SqlParameter("@Duration", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Duration));
                sqlCommand.Parameters.Add(new SqlParameter("@ISRC", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ISRC));


                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                businessObject.IdSong = (int)sqlCommand.Parameters["@IdSong"].Value;

                return businessObject.IdSong;
            }
            catch (Exception ex)
            {
                businessObject.IdSong = -1;
                return -1;
                //throw new Exception("clsSongs::Insert::Error occured.", ex);
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
        public bool Update(clsSongs businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_Songs_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@IdSong", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IdSong));
                sqlCommand.Parameters.Add(new SqlParameter("@GENRE", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.GENRE));
                sqlCommand.Parameters.Add(new SqlParameter("@LANGUAGE", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LANGUAGE));
                sqlCommand.Parameters.Add(new SqlParameter("@TVSHOW", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TVSHOW));
                sqlCommand.Parameters.Add(new SqlParameter("@ARTIST", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ARTIST));
                sqlCommand.Parameters.Add(new SqlParameter("@TITLE", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TITLE));
                sqlCommand.Parameters.Add(new SqlParameter("@VERSION", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.VERSION));
                sqlCommand.Parameters.Add(new SqlParameter("@LABEL", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LABEL));
                sqlCommand.Parameters.Add(new SqlParameter("@FILENAME", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FILENAME));
                sqlCommand.Parameters.Add(new SqlParameter("@Spotify", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Spotify));
                sqlCommand.Parameters.Add(new SqlParameter("@CompanyId", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CompanyId));
                sqlCommand.Parameters.Add(new SqlParameter("@LabelId", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LabelId));
                sqlCommand.Parameters.Add(new SqlParameter("@RadioDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.RadioDate));
                sqlCommand.Parameters.Add(new SqlParameter("@IncludeInFirstPlay", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IncludeInFirstPlay));
                sqlCommand.Parameters.Add(new SqlParameter("@IncludeInNewTalent", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IncludeInNewTalent));
                sqlCommand.Parameters.Add(new SqlParameter("@PromotionId", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PromotionId));
                sqlCommand.Parameters.Add(new SqlParameter("@SingRing", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SingRing));
                sqlCommand.Parameters.Add(new SqlParameter("@FirstPlayDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FirstPlayDate));
                sqlCommand.Parameters.Add(new SqlParameter("@ParentSongId", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ParentSongId));
                sqlCommand.Parameters.Add(new SqlParameter("@Lyric", SqlDbType.Text, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Lyric));
                sqlCommand.Parameters.Add(new SqlParameter("@AlternativeChart", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.AlternativeChart));

                sqlCommand.Parameters.Add(new SqlParameter("@Author", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Author));
                sqlCommand.Parameters.Add(new SqlParameter("@Publisher", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Publisher));
                sqlCommand.Parameters.Add(new SqlParameter("@Duration", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Duration));
                sqlCommand.Parameters.Add(new SqlParameter("@ISRC", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ISRC));


                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsSongs::Update::Error occured.", ex);
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
        /// <returns>clsSongs business object</returns>
        public clsSongs SelectByPrimaryKey(clsSongsKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_Songs_SelectByPrimaryKey]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@IdSong", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.IdSong));


                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    clsSongs businessObject = new clsSongs();

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
                throw new Exception("clsSongs::SelectByPrimaryKey::Error occured.", ex);
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
        /// <returns>list of clsSongs</returns>
        public DataSet SelectAll(int pageNumber, int PageSize, string sortcolumn, string Keyword)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_Songs_SelectAll]";
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
                throw new Exception("clsSongs::SelectAll::Error occured.", ex);
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
        /// <returns>list of clsSongs</returns>
        public List<clsSongs> SelectByField(string fieldName, object value)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_Songs_SelectByField]";
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
                throw new Exception("clsSongs::SelectByField::Error occured.", ex);
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
        public bool Delete(clsSongsKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_Songs_DeleteByPrimaryKey]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@IdSong", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.IdSong));


                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsSongs::DeleteByKey::Error occured.", ex);
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
            sqlCommand.CommandText = "dbo.[sp_Songs_DeleteByField]";
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
                throw new Exception("clsSongs::DeleteByField::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(clsSongs businessObject, IDataReader dataReader)
        {


            businessObject.IdSong = dataReader.GetInt32(dataReader.GetOrdinal(clsSongs.clsSongsFields.IdSong.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSongs.clsSongsFields.GENRE.ToString())))
            {
                businessObject.GENRE = dataReader.GetString(dataReader.GetOrdinal(clsSongs.clsSongsFields.GENRE.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSongs.clsSongsFields.LANGUAGE.ToString())))
            {
                businessObject.LANGUAGE = dataReader.GetString(dataReader.GetOrdinal(clsSongs.clsSongsFields.LANGUAGE.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSongs.clsSongsFields.TVSHOW.ToString())))
            {
                businessObject.TVSHOW = dataReader.GetString(dataReader.GetOrdinal(clsSongs.clsSongsFields.TVSHOW.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSongs.clsSongsFields.ARTIST.ToString())))
            {
                businessObject.ARTIST = dataReader.GetString(dataReader.GetOrdinal(clsSongs.clsSongsFields.ARTIST.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSongs.clsSongsFields.TITLE.ToString())))
            {
                businessObject.TITLE = dataReader.GetString(dataReader.GetOrdinal(clsSongs.clsSongsFields.TITLE.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSongs.clsSongsFields.VERSION.ToString())))
            {
                businessObject.VERSION = dataReader.GetString(dataReader.GetOrdinal(clsSongs.clsSongsFields.VERSION.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSongs.clsSongsFields.LABEL.ToString())))
            {
                businessObject.LABEL = dataReader.GetString(dataReader.GetOrdinal(clsSongs.clsSongsFields.LABEL.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSongs.clsSongsFields.FILENAME.ToString())))
            {
                businessObject.FILENAME = dataReader.GetString(dataReader.GetOrdinal(clsSongs.clsSongsFields.FILENAME.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSongs.clsSongsFields.Spotify.ToString())))
            {
                businessObject.Spotify = dataReader.GetString(dataReader.GetOrdinal(clsSongs.clsSongsFields.Spotify.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSongs.clsSongsFields.CompanyId.ToString())))
            {
                businessObject.CompanyId = dataReader.GetInt32(dataReader.GetOrdinal(clsSongs.clsSongsFields.CompanyId.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSongs.clsSongsFields.LabelId.ToString())))
            {
                businessObject.LabelId = dataReader.GetInt32(dataReader.GetOrdinal(clsSongs.clsSongsFields.LabelId.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSongs.clsSongsFields.RadioDate.ToString())))
            {
                businessObject.RadioDate = dataReader.GetDateTime(dataReader.GetOrdinal(clsSongs.clsSongsFields.RadioDate.ToString()));
            }

            businessObject.IncludeInFirstPlay = dataReader.GetBoolean(dataReader.GetOrdinal(clsSongs.clsSongsFields.IncludeInFirstPlay.ToString()));

            businessObject.IncludeInNewTalent = dataReader.GetBoolean(dataReader.GetOrdinal(clsSongs.clsSongsFields.IncludeInNewTalent.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSongs.clsSongsFields.PromotionId.ToString())))
            {
                businessObject.PromotionId = dataReader.GetInt32(dataReader.GetOrdinal(clsSongs.clsSongsFields.PromotionId.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSongs.clsSongsFields.SingRing.ToString())))
            {
                businessObject.SingRing = dataReader.GetInt64(dataReader.GetOrdinal(clsSongs.clsSongsFields.SingRing.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSongs.clsSongsFields.FirstPlayDate.ToString())))
            {
                businessObject.FirstPlayDate = dataReader.GetDateTime(dataReader.GetOrdinal(clsSongs.clsSongsFields.FirstPlayDate.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSongs.clsSongsFields.ParentSongId.ToString())))
            {
                businessObject.ParentSongId = dataReader.GetInt32(dataReader.GetOrdinal(clsSongs.clsSongsFields.ParentSongId.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSongs.clsSongsFields.Lyric.ToString())))
            {
                businessObject.Lyric = dataReader.GetString(dataReader.GetOrdinal(clsSongs.clsSongsFields.Lyric.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSongs.clsSongsFields.AlternativeChart.ToString())))
            {
                businessObject.AlternativeChart = dataReader.GetBoolean(dataReader.GetOrdinal(clsSongs.clsSongsFields.AlternativeChart.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSongs.clsSongsFields.Author.ToString())))
            {
                businessObject.Author = dataReader.GetString(dataReader.GetOrdinal(clsSongs.clsSongsFields.Author.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSongs.clsSongsFields.Publisher.ToString())))
            {
                businessObject.Publisher = dataReader.GetString(dataReader.GetOrdinal(clsSongs.clsSongsFields.Publisher.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSongs.clsSongsFields.Duration.ToString())))
            {
                businessObject.Duration = dataReader.GetString(dataReader.GetOrdinal(clsSongs.clsSongsFields.Duration.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsSongs.clsSongsFields.ISRC.ToString())))
            {
                businessObject.ISRC = dataReader.GetString(dataReader.GetOrdinal(clsSongs.clsSongsFields.ISRC.ToString()));
            }


        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsSongs</returns>
        internal List<clsSongs> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<clsSongs> list = new List<clsSongs>();

            while (dataReader.Read())
            {
                clsSongs businessObject = new clsSongs();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion

    }
}
