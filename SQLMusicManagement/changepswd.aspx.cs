using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLSoundManagement_BL.BusinessLayer;
using System.Web.UI.HtmlControls;

namespace SQLMusicManagement
{
    public partial class changepswd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                Session["Songs"] = null;
                Session["eSongs"] = null;
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
                Promoter.Attributes.Add("class", "select");

            }
            else
            { Response.Redirect("Login.aspx"); }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            clsJP_ADMIN U = (clsJP_ADMIN)Session["User"];
            clsJP_ADMINFactory fac = new clsJP_ADMINFactory();
            List<clsJP_ADMIN> User = fac.GetAllBy(clsJP_ADMIN.clsJP_ADMINFields.Username, U.Username);

            Helper h =new Helper();
            if (User != null && User.Count > 0)
            {
                if (User[0].Pswd == h.Encrypt(txtOld.Text))
                {
                    clsJP_ADMIN NewUser = new clsJP_ADMIN();
                    NewUser.Username = U.Username;
                    NewUser.Pswd = h.Encrypt(txtNew.Text);

                    fac.Update(NewUser);
                    pnlSuccess.Visible = true;
                }
                else
                {
                    pnlError.Visible = true;
                }
            }
        }

        protected void btjcancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("changepswd.aspx");
        }
    }
}