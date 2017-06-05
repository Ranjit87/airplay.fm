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
    public partial class AddCompany : System.Web.UI.Page
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
                    ManageCompany.Attributes.Add("class", "current");
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
                    if (Request.QueryString != null && Request.QueryString["id"] != null)
                    {
                        hf.Value = Request.QueryString["id"];
                        clsCompaniesFactory fac = new clsCompaniesFactory();
                        clsCompaniesKeys key = new clsCompaniesKeys(Convert.ToInt32(hf.Value));
                        clsCompanies Company = fac.GetByPrimaryKey(key);

                        txtcompany.Text = Company.Company;
                        txtFullName.Text = Company.FullName;
                        ddlFirst.SelectedValue = Company.Data == true ? "0" : "1";
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            clsCompaniesFactory fac = new clsCompaniesFactory();
            if (string.IsNullOrEmpty(hf.Value))
            {
                
                List<clsCompanies> lbl = fac.GetAllBy(clsCompanies.clsCompaniesFields.Company, txtcompany.Text);
                if (lbl != null && lbl.Count > 0)
                {
                    pnlSuccess.Visible = false;
                    pnlError.Visible = true;
                }
                else
                {
                    clsCompanies Company = new clsCompanies();
                    Company.FullName = txtFullName.Text;
                    Company.Company = txtcompany.Text;
                    Company.Data = ddlFirst.SelectedValue == "1" ? false : true;
                    fac.Insert(Company);
                    pnlSuccess.Visible = true;
                    lblSuccess.Text = "company added successfully";
                    pnlError.Visible = false;
                }
            }
            else
            {
                clsCompaniesKeys key = new clsCompaniesKeys(Convert.ToInt32(hf.Value));
                clsCompanies Company = fac.GetByPrimaryKey(key);
                Company.FullName = txtFullName.Text;
                Company.Company = txtcompany.Text;
                Company.Data = ddlFirst.SelectedValue == "1" ? false : true;
                fac.Update(Company);
                pnlSuccess.Visible = true;
                lblSuccess.Text = "company updated successfully";
                pnlError.Visible = false;
            }

        }

        protected void btjcancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCompany.aspx");
        }
    }
}