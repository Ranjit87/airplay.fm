using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SQLSoundManagement_BL.BusinessLayer;
using System.Data;
using System.Globalization;
namespace SQLMusicManagement
{
    public partial class Promoter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                if (!IsPostBack)
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
                    audienceFigures.Attributes.Add("class", "select");
                    HtmlGenericControl digitalData = (HtmlGenericControl)Master.FindControl("digitalData");
                    digitalData.Attributes.Add("class", "select");
                    HtmlGenericControl MoveFiles = (HtmlGenericControl)Master.FindControl("MoveFiles");
                    MoveFiles.Attributes.Add("class", "select");
                    HtmlGenericControl Promoter = (HtmlGenericControl)Master.FindControl("Promoter");
                    Promoter.Attributes.Add("class", "current");

                    Session["Promoter"] = null;
                    Session["ePromoter"] = null;

                    ViewState["PageNumber"] = 1;
                    ViewState["SortColumn"] = "Id d";
                    ViewState["SortDirection"] = "d";
                    LoadData();
                }
            }
            else
            { Response.Redirect("Login.aspx"); }
        }

        private void LoadData()
        {
            DateTime Currentdate = DateTime.Now;
            int CurrentYear = Currentdate.Year;
            Dictionary<string, string> MonthList = new Dictionary<string, string>();
            MonthList.Add("January_" + CurrentYear, "January " + CurrentYear);
            MonthList.Add("February_" + CurrentYear, "February " + CurrentYear);
            MonthList.Add("March_" + CurrentYear, "March " + CurrentYear);
            MonthList.Add("April_" + CurrentYear, "April " + CurrentYear);
            MonthList.Add("May_" + CurrentYear, "May " + CurrentYear);
            MonthList.Add("June_" + CurrentYear, "June " + CurrentYear);
            MonthList.Add("July_" + CurrentYear, "July " + CurrentYear);
            MonthList.Add("August_" + CurrentYear, "August " + CurrentYear);
            MonthList.Add("September_" + CurrentYear, "September " + CurrentYear);
            MonthList.Add("October_" + CurrentYear, "October " + CurrentYear);
            MonthList.Add("November_" + CurrentYear, "November " + CurrentYear);
            MonthList.Add("December_" + CurrentYear, "December " + CurrentYear);

            string CurrentMonth = Currentdate.ToString("MMMM");
            string FromMonth = (CurrentMonth == "gennaio" ? "January" : CurrentMonth == "febbraio" ? "February" : CurrentMonth == "marzo" ? "March" : CurrentMonth == "aprile" ? "April" : CurrentMonth == "maggio" ? "May" : CurrentMonth == "giugno" ? "June" : CurrentMonth == "luglio" ? "July" : CurrentMonth == "agosto" ? "August" : CurrentMonth == "settembre" ? "September" : CurrentMonth == "ottobre" ? "October" : CurrentMonth == "novembre" ? "November" : CurrentMonth == "dicembre" ? "December" : CurrentMonth);
            string GetCurrent = FromMonth + "_" + CurrentYear;

            ddlFrom.DataSource = MonthList;
            ddlFrom.DataTextField = "Value";
            ddlFrom.DataValueField = "Key";
            ddlFrom.SelectedValue = GetCurrent.ToString();
            ddlFrom.DataBind();

            ddlTo.DataSource = MonthList;
            ddlTo.DataTextField = "Value";
            ddlTo.DataValueField = "Key";
            ddlTo.SelectedValue = GetCurrent.ToString();
            ddlTo.DataBind();

            string ToMonth = FromMonth;

            BindTaskList(FromMonth, ToMonth, CurrentYear, 0);
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "_detail")
            {
                Response.Redirect("PromoterDetails.aspx?id=" + e.CommandArgument);
            }
        }

        ////Bind your Grid View here
        //private void BindTaskList()
        //{
        //    clsPromotionFactory fac = new clsPromotionFactory();
        //    //DataSet Emergenti = fac.GetAllWithPaging(Convert.ToInt32(ViewState["PageNumber"]), 100, ViewState["SortColumn"].ToString(), null);
        //    DataTable Emergenti = fac.GetAll();
        //    //DataTable myDataTable = Emergenti.Tables[0]; //Set your DataTable here
        //    //ViewState["Count"] = Emergenti.Tables[1];
        //    grd.DataSource = Emergenti;
        //    grd.DataBind();
        //}

        private void BindTaskList(string FromMonth, string ToMonth, int CurrentYear, int IsAll)
        {
            clsPromotionFactory fac = new clsPromotionFactory();
            DataTable Emergenti = fac.GetAll(FromMonth, ToMonth, CurrentYear, IsAll);
            grd.DataSource = Emergenti;
            grd.DataBind();
        }

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["myDataTable"];
        }

        private void SetViewState(DataTable myDataTable)
        {
            //Sets the ViewState
            ViewState["myDataTable"] = myDataTable;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string FromMonths = ddlFrom.SelectedItem.Value;
            string ToMonths = ddlTo.SelectedItem.Value;
            if (!string.IsNullOrEmpty(FromMonths))
            {
                string[] FromArr = FromMonths.Split('_');
                string FromMonth = FromArr[0].ToString();

                string[] ToArr = ToMonths.Split('_');
                string ToMonth = ToArr[0].ToString();

                int YearName = Convert.ToInt32(FromArr[1].ToString());

                clsPromotionFactory fac = new clsPromotionFactory();
                DataTable myDataTable = fac.GetAll(FromMonth, ToMonth, YearName, 0);

                grd.DataSource = myDataTable;
                grd.DataBind();
            }
            else
            {
                DateTime Currentdate = DateTime.Now;
                int CurrentYear = Currentdate.Year;

                string CurrentMonth = Currentdate.ToString("MMMM");
                string FromMonth = (CurrentMonth == "gennaio" ? "January" : CurrentMonth == "febbraio" ? "February" : CurrentMonth == "marzo" ? "March" : CurrentMonth == "aprile" ? "April" : CurrentMonth == "maggio" ? "May" : CurrentMonth == "giugno" ? "June" : CurrentMonth == "luglio" ? "July" : CurrentMonth == "agosto" ? "August" : CurrentMonth == "settembre" ? "September" : CurrentMonth == "ottobre" ? "October" : CurrentMonth == "novembre" ? "November" : CurrentMonth == "dicembre" ? "December" : CurrentMonth);

                string ToMonth = FromMonth;

                BindTaskList(FromMonth, ToMonth, CurrentYear, 0);
            }
        }

        protected void btnComplete_Click(object sender, EventArgs e)
        {
            clsPromotionFactory fac = new clsPromotionFactory();
            DataTable myDataTable = fac.GetAll(string.Empty, string.Empty, DateTime.Now.Year, 1);

            grd.DataSource = myDataTable;
            grd.DataBind();
        }




        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ViewState["PageNumber"] = e.NewPageIndex;
            grd.PageIndex = e.NewPageIndex;
            //BindTaskList();
        }

        //protected void grd_Sorting(object sender, GridViewSortEventArgs e)
        //{

        //    if (ViewState["SortDirection"].ToString() == "a")
        //    {
        //        ViewState["SortColumn"] = e.SortExpression + " a";
        //        ViewState["SortDirection"] = "d";
        //    }
        //    else
        //    {
        //        ViewState["SortColumn"] = e.SortExpression + " d";
        //        ViewState["SortDirection"] = "a";
        //    }
        //    BindTaskList();
        //}

        //protected void grd_DataBound(object sender, EventArgs e)
        //{
        //    DataTable dt = (DataTable)ViewState["Count"];
        //    int Count = Convert.ToInt32(dt.Rows[0]["totalRecord"]);
        //    decimal c = Convert.ToDecimal(Count) / Convert.ToDecimal(100);
        //    int PageCount = (int)Math.Ceiling(c);
        //    if (dt != null)
        //    {
        //        ddCurrentPage.Items.Clear();

        //        //Populate Pager
        //        for (int i = 0; i < PageCount; i++)
        //        {
        //            int iPageNumber = i + 1;
        //            ListItem myListItem = new ListItem(iPageNumber.ToString());

        //            if (iPageNumber == Convert.ToInt32(ViewState["PageNumber"]))
        //                myListItem.Selected = true;

        //            ddCurrentPage.Items.Add(myListItem);
        //        }
        //    }

        //    // Populate the Page Count            
        //    lblTotalPage.Text = PageCount.ToString();

        //}

        ////Change to a different page when the DropDown Page is changed
        //protected void ddCurrentPage_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ViewState["PageNumber"] = ddCurrentPage.SelectedIndex + 1;

        //    BindTaskList();
        //}

        ////Images for |<, <<, >>, and >|
        //protected void imgPageFirst_Command(object sender, CommandEventArgs e)
        //{
        //    Paginate(sender, e);
        //}
        //protected void imgPagePrevious_Command(object sender, CommandEventArgs e)
        //{
        //    Paginate(sender, e);
        //}
        //protected void imgPageNext_Command(object sender, CommandEventArgs e)
        //{
        //    Paginate(sender, e);
        //}
        //protected void imgPageLast_Command(object sender, CommandEventArgs e)
        //{
        //    Paginate(sender, e);
        //}
        //protected void Paginate(object sender, CommandEventArgs e)
        //{
        //    DataTable dt = (DataTable)ViewState["Count"];
        //    int Count = Convert.ToInt32(dt.Rows[0]["totalRecord"]);
        //    decimal c = Convert.ToDecimal(Count) / Convert.ToDecimal(100);
        //    int PageCount = (int)Math.Ceiling(c);


        //    ViewState["PageNumber"] = ddCurrentPage.SelectedIndex + 1;

        //    // Get the Current Page Selected
        //    int iCurrentIndex = grd.PageIndex;

        //    switch (e.CommandArgument.ToString().ToLower())
        //    {
        //        case "first":
        //            ViewState["PageNumber"] = 1;
        //            break;
        //        case "prev":
        //            if (ddCurrentPage.SelectedIndex != 0)
        //            {
        //                ViewState["PageNumber"] = ddCurrentPage.SelectedIndex;
        //            }
        //            break;
        //        case "next":
        //            if (ddCurrentPage.SelectedIndex + 1 != PageCount)
        //            {
        //                ViewState["PageNumber"] = ddCurrentPage.SelectedIndex + 2;
        //            }
        //            break;
        //        case "last":
        //            ViewState["PageNumber"] = PageCount;
        //            break;
        //    }

        //    BindTaskList();
        //}
    }
}

