using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using SQLSoundManagement_BL.BusinessLayer;
using System.Web.UI.WebControls;
using System.Text;

namespace SQLMusicManagement
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            clsJP_ADMINFactory fac = new clsJP_ADMINFactory();
            List<clsJP_ADMIN> User = fac.GetAllBy(clsJP_ADMIN.clsJP_ADMINFields.Username, txtUserName.Text);
            Helper h = new Helper();
            if (User != null && User.Count > 0)
            {
                string Decrypt = h.Decrypt(User[0].Pswd);

                if (User[0].Pswd == h.Encrypt(txtPassword.Text))
                {
                    Session["User"] = User[0];
                    Response.Redirect("Songs.aspx");
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Password is not correct";
                }
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "UserName is not correct";
            }
        }
        
    }
}