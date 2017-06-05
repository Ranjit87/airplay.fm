using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SQLSoundManagement_BL.BusinessLayer;
using System.Data;

namespace SQLMusicManagement
{
    public partial class Charts : System.Web.UI.Page
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
                    ManageEmergenti.Attributes.Add("class", "current");
                    HtmlGenericControl ImportData = (HtmlGenericControl)Master.FindControl("ImportData");
                    ImportData.Attributes.Add("class", "select");
                    HtmlGenericControl audienceFigures = (HtmlGenericControl)Master.FindControl("audienceFigures");
                    audienceFigures.Attributes.Add("class", "select");
                    HtmlGenericControl digitalData = (HtmlGenericControl)Master.FindControl("digitalData");
                    digitalData.Attributes.Add("class", "select");
                    HtmlGenericControl MoveFiles = (HtmlGenericControl)Master.FindControl("MoveFiles");
                    MoveFiles.Attributes.Add("class", "select");
                    HtmlGenericControl Promoter = (HtmlGenericControl)Master.FindControl("Promoter");
                    Promoter.Attributes.Add("class", "select");

                    Session["Emergenti"] = null;
                    Session["eEmergenti"] = null;

                    ViewState["PageNumber"] = 1;
                    ViewState["SortColumn"] = "ID d";
                    ViewState["SortDirection"] = "d";
                    LoadData();
                }
            }
            else
            { Response.Redirect("Login.aspx"); }
        }

        private void LoadData()
        {
            BindTaskList();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "_Edit")
            {
                Response.Redirect("EditChart.aspx?id=" + e.CommandArgument);
            }
            else if (e.CommandName == "_delete")
            {
                clsEmergentiFactory fac = new clsEmergentiFactory();
                clsEmergentiKeys key = new clsEmergentiKeys(Convert.ToInt32(e.CommandArgument));
                List<clsEmergenti> Emergenti = fac.GetAllBy(clsEmergenti.clsEmergentiFields.ID, e.CommandArgument);
                if (Emergenti != null && Emergenti.Count > 1)
                {
                    pnlError.Visible = true;
                    pnlSuccess.Visible = false;
                    lblError.Text = "Can't delete this Emergenti";
                }
                else
                {
                    fac.Delete(key);
                    LoadData();
                    pnlSuccess.Visible = true;
                    pnlError.Visible = false;
                    lblSuccess.Text = "Emergenti deleted successfully";
                }
            }
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
            }
        }


        //Bind your Grid View here
        private void BindTaskList()
        {
            clsEmergentiFactory fac = new clsEmergentiFactory();
            DataSet Emergenti = fac.GetAll(Convert.ToInt32(ViewState["PageNumber"]), 100, ViewState["SortColumn"].ToString(), null);
            DataTable myDataTable = Emergenti.Tables[0]; //Set your DataTable here
            ViewState["Count"] = Emergenti.Tables[1];
            grd.DataSource = myDataTable;
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

        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ViewState["PageNumber"] = e.NewPageIndex;
            grd.PageIndex = e.NewPageIndex;
            BindTaskList();
        }

        //This is invoked when the grid column is Clicked for Sorting, 
        //Clicking again will Toggle Descending/Ascending through the Sort Expression
        protected void grd_Sorting(object sender, GridViewSortEventArgs e)
        {

            if (ViewState["SortDirection"].ToString() == "a")
            {
                ViewState["SortColumn"] = e.SortExpression + " a";
                ViewState["SortDirection"] = "d";
            }
            else
            {
                ViewState["SortColumn"] = e.SortExpression + " d";
                ViewState["SortDirection"] = "a";
            }
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string Keyword = txtSearch.Text;
            if (!string.IsNullOrEmpty(Keyword))
            {
                clsEmergentiFactory fac = new clsEmergentiFactory();
                DataSet Emergenti = fac.GetAll(Convert.ToInt32(ViewState["PageNumber"]), 100000, ViewState["SortColumn"].ToString(), Keyword);

                DataTable myDataTable = Emergenti.Tables[0]; //Set your DataTable here

                ViewState["Count"] = Emergenti.Tables[1];

                grd.DataSource = myDataTable;
                grd.DataBind();
            }
            else
            {
                BindTaskList();
            }
        }

        protected void btnAddNewChart_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCharts.aspx");
        }
    }
}