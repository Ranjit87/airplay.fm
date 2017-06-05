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
using SQLSoundManagement_BL.BusinessLayer.BusinessLayer;

namespace SQLMusicManagement
{
    public partial class Recognized : System.Web.UI.Page
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

                    clsRecognizedFactory fac = new clsRecognizedFactory();
                    fac.GetAllRecognizedDelete();

                    ViewState["PageNumber"] = 1;

                    //BindTaskList();
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

            clsRecognizedFactory fac = new clsRecognizedFactory();
            if (!String.IsNullOrEmpty(hfname.Value))
            {
                if (IsEnglish(hfname.Value))
                {
                    if (filename.HasFile)
                    {
                        string FileName = Path.GetFileName(filename.PostedFile.FileName);
                        string Extension = Path.GetExtension(filename.PostedFile.FileName);
                        if (Extension == ".csv")
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

                                fac.GetAllRecognizedDelete();

                                string ReadCSV = File.ReadAllText(FilePath);
                                foreach (string csvRow in ReadCSV.Split('\n'))
                                {
                                    if (!string.IsNullOrEmpty(csvRow))
                                    {
                                        string csvFileName = string.Empty;
                                        int IdRadio = 0;
                                        int csvHour = 0;
                                        DateTime FingerprintingTime = DateTime.Now;
                                        string FingerprintingDetails = string.Empty;

                                        string[] xxx = csvRow.ToString().Split('\t');
                                        string item1 = xxx[0];
                                        if (item1 != "\r")
                                        {
                                            if (item1 != null)
                                            {
                                                string[] inner = item1.Split('.');
                                                string Ids = inner[0].Replace(@"\ ", "").Replace(@"""", "");
                                                IdRadio = Convert.ToInt32(Ids);

                                                csvHour = GetInterval(inner[4]);

                                                string DatetimeFor = inner[1] + "-" + inner[2] + "-" + inner[3] + " " + inner[4] + ":" + inner[5] + ":" + inner[6] + ".000";
                                                FingerprintingTime = Convert.ToDateTime(DatetimeFor);

                                            }
                                            csvFileName = xxx[2];
                                            FingerprintingDetails = xxx[3];

                                            clsRecognized recognized = new clsRecognized();
                                            if (csvFileName.EndsWith(".mp3"))
                                            {
                                                recognized.FileName = csvFileName;
                                            }
                                            else
                                            {
                                                recognized.FileName = csvFileName + ".mp3";
                                            }
                                            recognized.IdRadio = IdRadio;
                                            recognized.Hour = csvHour;
                                            recognized.FingerprintingTime = FingerprintingTime;
                                            recognized.FingerprintingDetails = FingerprintingDetails;
                                            try
                                            {
                                                int ID = fac.Insert(recognized);
                                            }
                                            catch (Exception ex)
                                            {
                                                string errorMessage = string.Empty;
                                            }
                                        }
                                    }
                                }

                                int pageNumber = Convert.ToInt32(ViewState["PageNumber"]);
                                int PageSize = 100;
                                DataSet Recognized = fac.GetAllRecognized(pageNumber, PageSize);
                                DataTable myDataTable = Recognized.Tables[0]; //Set your DataTable here
                                ViewState["Count"] = Recognized.Tables[1];
                                grd.DataSource = myDataTable;
                                grd.DataBind();

                                Div1.Style.Add("display", "block");
                                divBtnSave.Style.Add("display", "block");
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
                            lblError.Text = "Upload only csv files.";
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

        private int GetInterval(string Hr)
        {
            int Interval = 0;
            if (Hr == "00")
            {
                Interval = 0;
            }
            else if (Hr == "01" || Hr == "02" || Hr == "03" || Hr == "04" || Hr == "05" || Hr == "06" || Hr == "07" || Hr == "08" || Hr == "09")
            {
                Interval = Convert.ToInt32(Hr.Replace("0", ""));
            }
            else if (Hr == "10" || Hr == "11" || Hr == "12" || Hr == "13" || Hr == "14" || Hr == "15" || Hr == "16" || Hr == "17" || Hr == "18" || Hr == "19" ||
                Hr == "20" || Hr == "21" || Hr == "22" || Hr == "23" || Hr == "24")
            {
                Interval = Convert.ToInt32(Hr);
            }
            return Interval;
        }

        private void BindTaskList()
        {
            clsRecognizedFactory fac = new clsRecognizedFactory();
            int pageNumber = Convert.ToInt32(ViewState["PageNumber"]);
            int PageSize = 100;
            DataSet Recognized = fac.GetAllRecognized(pageNumber, PageSize);
            DataTable myDataTable = Recognized.Tables[0]; //Set your DataTable here
            ViewState["Count"] = Recognized.Tables[1];
            grd.DataSource = myDataTable;
            grd.DataBind();

            Div1.Style.Add("display", "block");
            divBtnSave.Style.Add("display", "block");
        }

        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ViewState["PageNumber"] = e.NewPageIndex;
            grd.PageIndex = e.NewPageIndex;
            BindTaskList();
        }

        protected void grd_DataBound(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["Count"];
            int Count = Convert.ToInt32(dt.Rows[0]["totalRecord"]);
            decimal c = Convert.ToDecimal(Count) / Convert.ToDecimal(100);
            int PageCount = (int)Math.Ceiling(c);
            if (dt != null)
            {
                ddCurrentPage.Items.Clear();

                //Populate Pager
                for (int i = 0; i < PageCount; i++)
                {
                    int iPageNumber = i + 1;
                    ListItem myListItem = new ListItem(iPageNumber.ToString());

                    if (iPageNumber == Convert.ToInt32(ViewState["PageNumber"]))
                        myListItem.Selected = true;

                    ddCurrentPage.Items.Add(myListItem);
                }
            }

            // Populate the Page Count            
            lblTotalPage.Text = PageCount.ToString();

        }
        //Change to a different page when the DropDown Page is changed
        protected void ddCurrentPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["PageNumber"] = ddCurrentPage.SelectedIndex + 1;
            BindTaskList();
        }

        //Images for |<, <<, >>, and >|
        protected void imgPageFirst_Command(object sender, CommandEventArgs e)
        {
            Paginate(sender, e);
        }
        protected void imgPagePrevious_Command(object sender, CommandEventArgs e)
        {
            Paginate(sender, e);
        }
        protected void imgPageNext_Command(object sender, CommandEventArgs e)
        {
            Paginate(sender, e);
        }
        protected void imgPageLast_Command(object sender, CommandEventArgs e)
        {
            Paginate(sender, e);
        }

        protected void Paginate(object sender, CommandEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["Count"];
            int Count = Convert.ToInt32(dt.Rows[0]["totalRecord"]);
            decimal c = Convert.ToDecimal(Count) / Convert.ToDecimal(100);
            int PageCount = (int)Math.Ceiling(c);


            ViewState["PageNumber"] = ddCurrentPage.SelectedIndex + 1;

            // Get the Current Page Selected
            int iCurrentIndex = grd.PageIndex;

            switch (e.CommandArgument.ToString().ToLower())
            {
                case "first":
                    ViewState["PageNumber"] = 1;
                    break;
                case "prev":
                    if (ddCurrentPage.SelectedIndex != 0)
                    {
                        ViewState["PageNumber"] = ddCurrentPage.SelectedIndex;
                    }
                    break;
                case "next":
                    if (ddCurrentPage.SelectedIndex + 1 != PageCount)
                    {
                        ViewState["PageNumber"] = ddCurrentPage.SelectedIndex + 2;
                    }
                    break;
                case "last":
                    ViewState["PageNumber"] = PageCount;
                    break;
            }
            BindTaskList();
        }
        protected void btjcancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Songs.aspx");
        }
        protected void btnSaveData_Click(object sender, EventArgs e)
        {
            clsRecognizedFactory fac = new clsRecognizedFactory();
            try
            {
                int Status = fac.SaveAllInRecognized();
            }
            catch (Exception ex)
            {

            }

            Response.Redirect("Songs.aspx");
        }





    }
}