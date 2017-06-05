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
    public partial class AudienceFigures : System.Web.UI.Page
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
                    ImportData.Attributes.Add("class", "select");
                    HtmlGenericControl audienceFigures = (HtmlGenericControl)Master.FindControl("audienceFigures");
                    audienceFigures.Attributes.Add("class", "current");
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
            int FileType = 0;

            CultureInfo cinfo = new CultureInfo("it-IT");

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

                                if (rdbRadio.Checked)
                                {
                                    FileType = 1;
                                }
                                else if (rdbData.Checked)
                                {
                                    FileType = 2;
                                }

                                if (FileType == 0)
                                {
                                    pnlError.Visible = true;
                                    lblError.Text = "Please select one table.";
                                }
                                else
                                {
                                    DataSet ds = new DataSet();
                                    DataTable dt = new DataTable();

                                    List<string> LastColVal = new List<string>();

                                    ds = getExcelRecords(excelConnectionString, excelConnection);
                                    int totalcolumns = ds.Tables[0].Columns.Count;
                                    if (totalcolumns > 0)
                                    {
                                        dt = ds.Tables[0];

                                        foreach (DataRow dr in dt.Rows)
                                        {
                                            try
                                            {
                                                if (dt.Rows.IndexOf(dr) != 0)
                                                {
                                                    int RadioId = Convert.ToInt32(dr[0].ToString());
                                                    string RadioName = string.IsNullOrEmpty(dr[1].ToString()) ? null : dr[1].ToString();
                                                    string Semester = string.IsNullOrEmpty(dr[2].ToString()) ? null : dr[2].ToString();
                                                    string TotalAudience = string.IsNullOrEmpty(dr[3].ToString()) ? null : dr[3].ToString();

                                                    decimal I = Convert.ToDecimal(dr[4].ToString());
                                                    SaveDataInTable(RadioId, 0, I, RadioName, Semester, TotalAudience, FileType);

                                                    decimal II = Convert.ToDecimal(dr[5].ToString());
                                                    SaveDataInTable(RadioId, 1, II, RadioName, Semester, TotalAudience, FileType);

                                                    decimal III = Convert.ToDecimal(dr[6].ToString());
                                                    SaveDataInTable(RadioId, 2, III, RadioName, Semester, TotalAudience, FileType);

                                                    decimal IV = Convert.ToDecimal(dr[7].ToString());
                                                    SaveDataInTable(RadioId, 3, IV, RadioName, Semester, TotalAudience, FileType);

                                                    decimal V = Convert.ToDecimal(dr[8].ToString());
                                                    SaveDataInTable(RadioId, 4, V, RadioName, Semester, TotalAudience, FileType);

                                                    decimal VI = Convert.ToDecimal(dr[9].ToString());
                                                    SaveDataInTable(RadioId, 5, VI, RadioName, Semester, TotalAudience, FileType);

                                                    decimal VII = Convert.ToDecimal(dr[10].ToString());
                                                    SaveDataInTable(RadioId, 6, VII, RadioName, Semester, TotalAudience, FileType);

                                                    decimal VIII = Convert.ToDecimal(dr[11].ToString());
                                                    SaveDataInTable(RadioId, 7, VIII, RadioName, Semester, TotalAudience, FileType);

                                                    decimal IX = Convert.ToDecimal(dr[12].ToString());
                                                    SaveDataInTable(RadioId, 8, IX, RadioName, Semester, TotalAudience, FileType);

                                                    decimal X = Convert.ToDecimal(dr[13].ToString());
                                                    SaveDataInTable(RadioId, 9, X, RadioName, Semester, TotalAudience, FileType);

                                                    decimal XI = Convert.ToDecimal(dr[14].ToString());
                                                    SaveDataInTable(RadioId, 10, XI, RadioName, Semester, TotalAudience, FileType);

                                                    decimal XII = Convert.ToDecimal(dr[15].ToString());
                                                    SaveDataInTable(RadioId, 11, XII, RadioName, Semester, TotalAudience, FileType);

                                                    decimal XIII = Convert.ToDecimal(dr[16].ToString());
                                                    SaveDataInTable(RadioId, 12, XIII, RadioName, Semester, TotalAudience, FileType);

                                                    decimal XIV = Convert.ToDecimal(dr[17].ToString());
                                                    SaveDataInTable(RadioId, 13, XIV, RadioName, Semester, TotalAudience, FileType);

                                                    decimal XV = Convert.ToDecimal(dr[18].ToString());
                                                    SaveDataInTable(RadioId, 14, XV, RadioName, Semester, TotalAudience, FileType);

                                                    decimal XVI = Convert.ToDecimal(dr[19].ToString());
                                                    SaveDataInTable(RadioId, 15, XVI, RadioName, Semester, TotalAudience, FileType);

                                                    decimal XVII = Convert.ToDecimal(dr[20].ToString());
                                                    SaveDataInTable(RadioId, 16, XVII, RadioName, Semester, TotalAudience, FileType);

                                                    decimal XVIII = Convert.ToDecimal(dr[21].ToString());
                                                    SaveDataInTable(RadioId, 17, XVIII, RadioName, Semester, TotalAudience, FileType);

                                                    decimal XIX = Convert.ToDecimal(dr[22].ToString());
                                                    SaveDataInTable(RadioId, 18, XIX, RadioName, Semester, TotalAudience, FileType);

                                                    decimal XX = Convert.ToDecimal(dr[23].ToString());
                                                    SaveDataInTable(RadioId, 19, XX, RadioName, Semester, TotalAudience, FileType);

                                                    decimal XXI = Convert.ToDecimal(dr[24].ToString());
                                                    SaveDataInTable(RadioId, 20, XXI, RadioName, Semester, TotalAudience, FileType);

                                                    decimal XXII = Convert.ToDecimal(dr[25].ToString());
                                                    SaveDataInTable(RadioId, 21, XXII, RadioName, Semester, TotalAudience, FileType);

                                                    decimal XXIII = Convert.ToDecimal(dr[26].ToString());
                                                    SaveDataInTable(RadioId, 22, XXIII, RadioName, Semester, TotalAudience, FileType);

                                                    decimal XXIV = Convert.ToDecimal(dr[27].ToString());
                                                    SaveDataInTable(RadioId, 23, XXIV, RadioName, Semester, TotalAudience, FileType);
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                            }
                                        }
                                        Response.Redirect("Songs.aspx");
                                    }
                                }
                            }
                            catch (Exception ex)
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

        public int SaveDataInTable(int RadioId, int Interval, decimal Audience, string RadioName, string Semester, string TotalAudience, int FileType)
        {
            int Status = -1;
            try
            {
                clsAudienceFigureFactory fac = new clsAudienceFigureFactory();
                clsAudienceFigure AudienceFigure = new clsAudienceFigure();

                AudienceFigure.RadioId = RadioId;
                AudienceFigure.Interval = Interval;
                AudienceFigure.Audience = Audience;
                AudienceFigure.RadioName = RadioName;
                AudienceFigure.Semester = Semester;
                AudienceFigure.TotalAudience = TotalAudience;

                Status = fac.Insert(AudienceFigure,FileType);
            }
            catch { Status = -1; }

            return Status;

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
            Response.Redirect("AudienceFigures.aspx");
        }
    }
}