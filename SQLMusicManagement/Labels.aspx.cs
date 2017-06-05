using SQLSoundManagement_BL.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SQLMusicManagement
{
    public partial class Labels : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                if (!IsPostBack)
                {
                    Session["Songs"] = null;
                    Session["eSongs"] = null;
                    HtmlGenericControl ManageSongs = (HtmlGenericControl)Master.FindControl("ManageSongs");
                    ManageSongs.Attributes.Add("class", "select");
                    HtmlGenericControl ManageCompany = (HtmlGenericControl)Master.FindControl("ManageCompany");
                    ManageCompany.Attributes.Add("class", "select");
                    HtmlGenericControl ManageLabel = (HtmlGenericControl)Master.FindControl("ManageLabel");
                    ManageLabel.Attributes.Add("class", "current");
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

                    ViewState["PageNumber"] = 1;
                    ViewState["SortColumn"] = "Title a";
                    ViewState["SortDirection"] = "a";
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
            if (e.CommandName.ToString() == "_Edit")
            {
                Response.Redirect("AddLabels.aspx?id=" + e.CommandArgument + "");
            }
            else if (e.CommandName.ToString() == "_delete")
            {
                clsLabelsFactory fac = new clsLabelsFactory();
                clsLabelsKeys key = new clsLabelsKeys(Convert.ToInt32(e.CommandArgument));
                fac.Delete(key);
                LoadData();
            }
            
        }


        //Bind your Grid View here
        private void BindTaskList()
        {
            clsLabelsFactory fac = new clsLabelsFactory();
            DataSet Songs = fac.GetAllInTable(Convert.ToInt32(ViewState["PageNumber"]), 100, ViewState["SortColumn"].ToString());

            DataTable myDataTable = Songs.Tables[0]; //Set your DataTable here

            ViewState["Count"] = Songs.Tables[1];

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
            int Count = Convert.ToInt32(dt.Rows[0]["totalsongs"]);
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
            int Count = Convert.ToInt32(dt.Rows[0]["totalsongs"]);
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
    }
}