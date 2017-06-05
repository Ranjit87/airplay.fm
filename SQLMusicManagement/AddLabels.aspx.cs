using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SQLSoundManagement_BL.BusinessLayer;

namespace SQLMusicManagement
{
    public partial class AddLabels : System.Web.UI.Page
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
                    ManageLabel.Attributes.Add("class", "current");
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
                    if (Request.QueryString != null && Request.QueryString["id"] != null)
                    {
                        hf.Value = Request.QueryString["id"];
                        clsLabelsFactory fac = new clsLabelsFactory();
                        clsLabelsKeys key = new clsLabelsKeys(Convert.ToInt32(hf.Value));
                        clsLabels lvl = fac.GetByPrimaryKey(key);

                        txtLable.Text = lvl.Title;
                        ddlFirst.SelectedValue = lvl.Data == true ? "0" : "1";
                    }
                }
                else
                { Response.Redirect("Login.aspx"); }
            }
            
            
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            clsLabelsFactory fac = new clsLabelsFactory();
            if (string.IsNullOrEmpty(hf.Value))
            {
                
                List<clsLabels> lbl = fac.GetAllBy(clsLabels.clsLabelsFields.Title, txtLable.Text);
                if (lbl != null && lbl.Count > 0)
                {
                    pnlSuccess.Visible = false;
                    pnlError.Visible = true;
                }
                else
                {
                    clsLabels label = new clsLabels();
                    label.Title = txtLable.Text;
                    label.Data = ddlFirst.SelectedValue == "1" ? false : true;
                    fac.Insert(label);
                    pnlSuccess.Visible = true;
                    lblSuccess.Text = "Label added successfully";
                    pnlError.Visible = false;
                }
            }
            else
            {
                clsLabelsKeys key = new clsLabelsKeys(Convert.ToInt32(hf.Value));
                clsLabels label = fac.GetByPrimaryKey(key);
                label.Title = txtLable.Text;
                label.Data = ddlFirst.SelectedValue == "1" ? false : true;
                fac.Update(label);
                pnlSuccess.Visible = true;
                lblSuccess.Text = "Label updated successfully";
                pnlError.Visible = false;
            }

        }

        protected void btjcancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLabels.aspx");
        }
    }
}