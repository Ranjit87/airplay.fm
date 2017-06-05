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
    public partial class Songs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                if (!IsPostBack)
                {
                    HtmlGenericControl ManageSongs = (HtmlGenericControl)Master.FindControl("ManageSongs");
                    ManageSongs.Attributes.Add("class", "current");
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
                    Promoter.Attributes.Add("class", "select");

                    Session["Songs"] = null;
                    Session["eSongs"] = null;

                    ViewState["PageNumber"] = 1;
                    ViewState["SortColumn"] = "IdSong d";
                    ViewState["SortDirection"] = "d";
                    LoadData();



                    if (Session["SuccessMsg"] != null)
                    {
                        lblSuccess.Text = Session["SuccessMsg"].ToString();
                        pnlSuccess.Visible = true;
                        Session["SuccessMsg"] = null;
                    }
                    if (Session["ErrorMsg"] != null)
                    {
                        lblError.Text = Session["ErrorMsg"].ToString();
                        pnlError.Visible = true;
                        Session["ErrorMsg"] = null;
                    }
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
            if (e.CommandName == "_detail")
            {
                Session["Songs"] = null;
                Response.Redirect("songdetail.aspx?id=" + e.CommandArgument);
            }
            else if (e.CommandName == "_Edit")
            {
                Response.Redirect("EditSong.aspx?id=" + e.CommandArgument);
            }
            else if (e.CommandName == "_delete")
            {
                clsSongsFactory fac = new clsSongsFactory();
                clsSongsKeys key = new clsSongsKeys(Convert.ToInt32(e.CommandArgument));
                List<clsSongs> Songs = fac.GetAllBy(clsSongs.clsSongsFields.ParentSongId, e.CommandArgument);
                if (Songs != null && Songs.Count > 1)
                {
                    pnlError.Visible = true;
                    pnlSuccess.Visible = false;
                    lblError.Text = "Can't delete this Song";
                }
                else
                {
                    fac.Delete(key);
                    LoadData();
                    pnlSuccess.Visible = true;
                    pnlError.Visible = false;
                    lblSuccess.Text = "Song deleted successfully";
                }
            }
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label l = (Label)e.Row.FindControl("Company");
                Label lb = (Label)e.Row.FindControl("RadioDate");
                Label lblFirstPlayDate = (Label)e.Row.FindControl("FirstPlayDate");

                try
                {
                    DateTime d = Convert.ToDateTime(lb.Text);
                    lb.Text = d.ToString("dd/MM/yyyy");

                    string FirstPlayDate = lblFirstPlayDate.Text;
                    if (!string.IsNullOrEmpty(FirstPlayDate))
                    {
                        lblFirstPlayDate.Text = "<span style='color:green'>Active</span>";
                    }
                    else
                    {
                        lblFirstPlayDate.Text = "<span style='color:red'>-</span>";
                    }
                }
                catch (Exception ex)
                { }
            }
        }


        //Bind your Grid View here
        private void BindTaskList()
        {
            clsSongsFactory fac = new clsSongsFactory();
            DataSet Songs = fac.GetAll(Convert.ToInt32(ViewState["PageNumber"]), 100, ViewState["SortColumn"].ToString(), null);

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
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string Keyword = txtSearch.Text;
            if (!string.IsNullOrEmpty(Keyword))
            {
                clsSongsFactory fac = new clsSongsFactory();
                DataSet Songs = fac.GetAll(Convert.ToInt32(ViewState["PageNumber"]), 100000, ViewState["SortColumn"].ToString(), Keyword);

                DataTable myDataTable = Songs.Tables[0]; //Set your DataTable here

                ViewState["Count"] = Songs.Tables[1];

                grd.DataSource = myDataTable;
                grd.DataBind();
            }
            else
            {
                BindTaskList();
            }
        }





    }
}