using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SQLSoundManagement_BL.BusinessLayer;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.OleDb;
using System.Data;

namespace SQLMusicManagement
{
    public partial class ImportSongs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    HtmlGenericControl ManageSongs = (HtmlGenericControl)Master.FindControl("ManageSongs");
                    ManageSongs.Attributes.Add("class", "select");
                    HtmlGenericControl ManageCompany = (HtmlGenericControl)Master.FindControl("ManageCompany");
                    ManageCompany.Attributes.Add("class", "select");
                    HtmlGenericControl ManageLabel = (HtmlGenericControl)Master.FindControl("ManageLabel");
                    ManageLabel.Attributes.Add("class", "select");
                    HtmlGenericControl ManageEmergenti = (HtmlGenericControl)Master.FindControl("ManageEmergenti");
                    ManageEmergenti.Attributes.Add("class", "select");
                    HtmlGenericControl ImportData = (HtmlGenericControl)Master.FindControl("ImportData");
                    ImportData.Attributes.Add("class", "current");
                    HtmlGenericControl audienceFigures = (HtmlGenericControl)Master.FindControl("audienceFigures");
                    audienceFigures.Attributes.Add("class", "select");
                    HtmlGenericControl digitalData = (HtmlGenericControl)Master.FindControl("digitalData");
                    digitalData.Attributes.Add("class", "select");
                    HtmlGenericControl MoveFiles = (HtmlGenericControl)Master.FindControl("MoveFiles");
                    MoveFiles.Attributes.Add("class", "select");
                    HtmlGenericControl Promoter = (HtmlGenericControl)Master.FindControl("Promoter");
                    Promoter.Attributes.Add("class", "select");

                }
                else
                { Response.Redirect("Login.aspx"); }
            }
        }

        public bool IsEnglish(string inputstring)
        {
            Regex regex = new Regex(@"[A-Za-z0-9_ .,-=+()!#$%^&*~{}\[\]\\]");
            MatchCollection matches = regex.Matches(inputstring);

            if (matches.Count.Equals(inputstring.Length))
                return true;
            else
                return false;
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            CultureInfo cinfo = new CultureInfo("it-IT");

            clsSongsFactory fac = new clsSongsFactory();
            clsSongs Song = new clsSongs();
            if (!String.IsNullOrEmpty(hfname.Value))
            {
                if (IsEnglish(hfname.Value))
                {
                    if (filename.HasFile)
                    {
                        string FileName = Path.GetFileName(filename.PostedFile.FileName);
                        string Extension = Path.GetExtension(filename.PostedFile.FileName);
                        if (Extension == ".xls" || Extension == ".xlsx")
                        {
                            try
                            {
                                string FolderPath = Server.MapPath("~/ImportFiles");
                                if (!Directory.Exists(FolderPath))
                                {
                                    Directory.CreateDirectory(FolderPath);
                                }

                                Guid abc = Guid.NewGuid();

                                string FilePath = FolderPath + "/" + abc.ToString();
                                if (System.IO.File.Exists(FilePath))
                                {
                                    System.IO.File.Delete(FilePath);
                                }

                                filename.SaveAs(FilePath);

                                string excelConnectionString = string.Empty;
                                excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + ";Extended Properties=\"Excel 12.0;HDR=" + "No" + ";IMEX=2\"";
                                OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);

                                if (Extension == ".xls")
                                {
                                    excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FilePath + ";Extended Properties=\"Excel 8.0;HDR=" + "No" + ";IMEX=2\"";
                                }
                                else if (Extension == ".xlsx")
                                {
                                    excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + ";Extended Properties=\"Excel 12.0;HDR=" + "No" + ";IMEX=2\"";
                                }
                                excelConnection = new OleDbConnection(excelConnectionString);
                                if (excelConnection.State == ConnectionState.Closed)
                                {
                                    excelConnection.Open();
                                }

                                DataSet ds = new DataSet();
                                DataTable dt = new DataTable();

                                ds = getExcelRecords(excelConnectionString, excelConnection);
                                int totalcolumns = ds.Tables[0].Columns.Count;
                                if (totalcolumns > 0)
                                {
                                    dt = ds.Tables[0];
                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        try
                                        {
                                            Song.GENRE = string.IsNullOrEmpty(dr[0].ToString()) ? null : dr[0].ToString();
                                            Song.LANGUAGE = string.IsNullOrEmpty(dr[1].ToString()) ? null : dr[1].ToString();
                                            if (!string.IsNullOrEmpty(Song.GENRE) && !string.IsNullOrEmpty(Song.LANGUAGE))
                                            {
                                                Song.TVSHOW = string.IsNullOrEmpty(dr[2].ToString()) ? null : dr[2].ToString();
                                                Song.ARTIST = string.IsNullOrEmpty(dr[3].ToString()) ? null : dr[3].ToString();
                                                Song.TITLE = string.IsNullOrEmpty(dr[4].ToString()) ? null : dr[4].ToString();
                                                Song.VERSION = string.IsNullOrEmpty(dr[5].ToString()) ? null : dr[5].ToString();
                                                Song.LABEL = string.IsNullOrEmpty(dr[6].ToString()) ? null : dr[6].ToString();
                                                Song.FILENAME = string.IsNullOrEmpty(dr[7].ToString()) ? null : dr[7].ToString();
                                                Song.Spotify = string.IsNullOrEmpty(dr[8].ToString()) ? null : dr[8].ToString();
                                                Song.CompanyId = Convert.ToInt32(dr[9].ToString());
                                                Song.LabelId = Convert.ToInt32(dr[10].ToString());
                                                Song.RadioDate = Convert.ToDateTime(dr[11].ToString());
                                                Song.IncludeInFirstPlay = dr[12].ToString() == "0" ? false : true;
                                                Song.IncludeInNewTalent = dr[13].ToString() == "0" ? false : true;
                                                Song.PromotionId = null;
                                                Song.SingRing = null;
                                                Song.FirstPlayDate = null;
                                                Song.ParentSongId = null;
                                                Song.Lyric = null;

                                                int IdSong = fac.Insert(Song);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                    }
                                    Response.Redirect("Songs.aspx");
                                }
                            }
                            catch(Exception ex)
                            {
                                pnlError.Visible = true;
                                lblError.Text = ex.Message.ToString();// "Error occured! Please try again later.";
                            }
                        }
                        else
                        {
                            pnlError.Visible = true;
                            lblError.Text = "Upload only excel files.";
                        }
                    }
                }
                else
                {
                    pnlError.Visible = true;
                    lblError.Text = "File name contains illegal characters";
                }
            }
            else
            {
                pnlError.Visible = true;
                lblError.Text = "Please select a file first";
            }
        }

        public DataSet getExcelRecords(string excelConnectionString, OleDbConnection excelConnection)
        {
            DataSet ds = new DataSet(); //To insert the records into tables
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (dt == null)
            {
                return null;
            }
            String[] excelSheets = new String[dt.Rows.Count];
            int t = 0;
            //excel data saves in temp file here.
            foreach (DataRow row in dt.Rows)
            {
                excelSheets[t] = row["TABLE_NAME"].ToString();
                t++;
            }
            OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);
            string query = string.Format("Select * from [{0}]", excelSheets[0]);
            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
            {
                dataAdapter.Fill(ds);
            }
            return ds;
        }

        protected void btjcancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImportSongs.aspx");
        }
    }
}