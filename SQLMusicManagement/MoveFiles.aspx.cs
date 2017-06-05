using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SQLMusicManagement
{
    public partial class MoveFiles : System.Web.UI.Page
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
                    audienceFigures.Attributes.Add("class", "select");
                    HtmlGenericControl digitalData = (HtmlGenericControl)Master.FindControl("digitalData");
                    digitalData.Attributes.Add("class", "select");
                    HtmlGenericControl MoveFiles = (HtmlGenericControl)Master.FindControl("MoveFiles");
                    MoveFiles.Attributes.Add("class", "current");
                }
                else
                { Response.Redirect("Login.aspx"); }
            }
           
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = "";
                string destFile = "";
                if (System.IO.Directory.Exists(@txtFolderPath.Text))
                {
                    if (System.IO.Directory.Exists(Server.MapPath("~") + "/files"))
                    {
                        string[] files = System.IO.Directory.GetFiles(Server.MapPath("~") + "/files");

                        // Copy the files and overwrite destination files if they already exist.
                        foreach (string s in files)
                        {
                            // Use static Path methods to extract only the file name from the path.
                            fileName = System.IO.Path.GetFileName(s);
                            destFile = System.IO.Path.Combine(@txtFolderPath.Text, fileName);
                            System.IO.File.Copy(s, destFile, true);

                            System.IO.File.Delete(Server.MapPath("~") + "/files/" + fileName);
                        }
                        pnlError.Visible = false;
                        pnlSuccess.Visible = true;
                        lblSuccess.Text = "Files moved successfully";
                    }
                    else
                    {
                        pnlError.Visible = true;
                        pnlSuccess.Visible = false;
                        lblError.Text = "Please try again ";
                    }
                }
                else
                {
                    pnlError.Visible = true;
                    pnlSuccess.Visible = false;
                    lblError.Text = "Given path is not correct.";
                }
            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                pnlSuccess.Visible = false;
                lblError.Text = "Access is denied.";
            }
        }
    }
}