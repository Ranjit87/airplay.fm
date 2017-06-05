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
    public partial class EditSong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    Session["Songs"] = null;
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

                    if (Request.QueryString != null && Request.QueryString["id"] != null)
                    {
                        hf.Value = Request.QueryString["id"];
                        hfprevid.Value = Request.QueryString["id"];
                        clsSongsFactory fac = new clsSongsFactory();
                        List<clsSongs> Songs = fac.GetAllByVersions(Convert.ToInt32(hf.Value));
                        LoadData();

                        if (Songs != null && Songs.Count > 0 && Session["eSongs"] == null)
                        {
                            grd.DataSource = Songs;
                            grd.DataBind();
                            Session["eSongs"] = Songs;

                            clsSongs Song = Songs.First(x => x.IdSong == Convert.ToInt32(hf.Value));

                            lblVersion.Text = Song.VERSION;
                            chkAbsoluteBegin.Checked = Song.IncludeInNewTalent;
                            chkAlternativeCharts.Checked = Song.AlternativeChart;
                            chkFirstPlay.Checked = Song.IncludeInFirstPlay;
                            //lblGenre.Text = Song.GENRE;
                            ddlGenre.SelectedValue = Song.GENRE == "Pop" ? "0" : Song.GENRE == "Rock" ? "1" : Song.GENRE == "Dance" ? "2" : Song.GENRE == "Hip Hop / Rap" ? "3" : "0";

                            //lblLanguage.Text = Song.LANGUAGE;
                            ddlLanguage.SelectedValue = Song.LANGUAGE == "ita" ? "1" : Song.LANGUAGE == "int" ? "0" : "0";

                            lblRadio.Text = Song.RadioDate.Value.ToString("dd/MM/yyyy");
                            lblTvShow.Text = Song.TVSHOW;

                            lblArtist.Text = Song.ARTIST;
                            lblTitle.Text = Song.TITLE;
                            ddlLabel.SelectedValue = Songs[0].LabelId.ToString();
                            ddlPromoter.SelectedValue = Songs[0].PromotionId.ToString();
                            //clsCompaniesFactory facC = new clsCompaniesFactory();
                            //clsCompaniesKeys k = new clsCompaniesKeys(Songs[0].CompanyId.Value);
                            //clsCompanies c = facC.GetByPrimaryKey(k);
                            ddlCompany.SelectedValue = Song.CompanyId.ToString();

                            lblAuthor.Text = Song.Author;
                            lblPublisher.Text = Song.Publisher;
                            txtDuration.Text = Song.Duration;
                            txtISRC.Text = Song.ISRC;
                        }
                        else
                        {
                            Songs = (List<clsSongs>)Session["eSongs"];
                            grd.DataSource = Songs;
                            grd.DataBind();
                            clsSongs Song = Songs.Where(x => x.IdSong == Convert.ToInt32(hf.Value)).FirstOrDefault();

                            lblVersion.Text = Song.VERSION;
                            chkAbsoluteBegin.Checked = Song.IncludeInNewTalent;
                            chkAlternativeCharts.Checked = Song.AlternativeChart;
                            chkFirstPlay.Checked = Song.IncludeInFirstPlay;
                            //lblGenre.Text = Song.GENRE;
                            Song.GENRE = ddlGenre.SelectedValue == "0" ? "Pop" : ddlGenre.SelectedValue == "1" ? "Rock" : ddlGenre.SelectedValue == "2" ? "Dance" : ddlGenre.SelectedValue == "3" ? "Hip Hop / Rap" : "Pop";// txtGenre.Text;
                            //lblLanguage.Text = Song.LANGUAGE;
                            Song.LANGUAGE = ddlLanguage.SelectedValue == "1" ? "ita" : ddlLanguage.SelectedValue == "0" ? "int" : "int";// txtLanguage.Text;
                            lblRadio.Text = Song.RadioDate.Value.ToString("dd/MM/yyyy");
                            lblTvShow.Text = Song.TVSHOW;

                            lblArtist.Text = Song.ARTIST;
                            lblTitle.Text = Song.TITLE;
                            ddlLabel.SelectedValue = Songs[0].LabelId.ToString();
                            ddlPromoter.SelectedValue = Songs[0].PromotionId.ToString();
                            //clsCompaniesFactory facC = new clsCompaniesFactory();
                            //clsCompaniesKeys k = new clsCompaniesKeys(Song.CompanyId.Value);
                            //clsCompanies c = facC.GetByPrimaryKey(k);
                            ddlCompany.SelectedValue = Songs[0].CompanyId.ToString();

                            lblAuthor.Text = Song.Author;
                            lblPublisher.Text = Song.Publisher;
                            txtDuration.Text = Song.Duration;
                            txtISRC.Text = Song.ISRC;
                        }
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        private void LoadData()
        {
            clsCompaniesFactory fac = new clsCompaniesFactory();
            DataTable comp = fac.GetAll();
            DataView dv = comp.DefaultView;
            dv.Sort = "Company";
            ddlCompany.DataSource = dv;
            ddlCompany.DataTextField = "Company";
            ddlCompany.DataValueField = "Id";
            ddlCompany.DataBind();

            clsLabelsFactory facl = new clsLabelsFactory();
            DataTable lbl = facl.GetAll();
            DataView dv1 = lbl.DefaultView;
            dv1.Sort = "Title";
            ddlLabel.DataSource = dv1;
            ddlLabel.DataTextField = "Title";
            ddlLabel.DataValueField = "Id";
            ddlLabel.DataBind();

            clsPromotionFactory facp = new clsPromotionFactory();
            DataSet prmtn = facp.GetAllWithPaging(1, 1000, "Id", string.Empty);
            DataTable myDataTable = prmtn.Tables[0];
            DataView dv2 = myDataTable.DefaultView;
            dv2.Sort = "Title";
            ddlPromoter.DataSource = dv2;
            ddlPromoter.DataTextField = "Title";
            ddlPromoter.DataValueField = "Id";
            ddlPromoter.DataBind();

        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string previd = hfprevid.Value;
            hfprevid.Value = e.CommandArgument.ToString();

            List<clsSongs> Songs = (List<clsSongs>)Session["eSongs"];
            for (int i = 0; i < Songs.Count; i++)
            {
                if (Songs[i].IdSong.ToString() == previd)
                {
                    Songs[i].VERSION = lblVersion.Text;
                    string[] d = lblRadio.Text.Split('/');
                    DateTime date = new DateTime(Convert.ToInt16(d[2]), Convert.ToInt16(d[1]), Convert.ToInt16(d[0]));
                    Songs[i].RadioDate = date;
                    //Songs[i].GENRE = lblGenre.Text;
                    Songs[i].GENRE = ddlGenre.SelectedValue == "0" ? "Pop" : ddlGenre.SelectedValue == "1" ? "Rock" : ddlGenre.SelectedValue == "2" ? "Dance" : ddlGenre.SelectedValue == "3" ? "Hip Hop / Rap" : "Pop";// txtGenre.Text;
                    //Songs[i].LANGUAGE = lblLanguage.Text;
                    Songs[i].LANGUAGE = ddlLanguage.SelectedValue == "1" ? "ita" : ddlLanguage.SelectedValue == "0" ? "int" : "int";
                    Songs[i].TVSHOW = lblTvShow.Text;
                    Songs[i].IncludeInNewTalent = chkAbsoluteBegin.Checked;
                    Songs[i].AlternativeChart = chkAlternativeCharts.Checked;
                    Songs[i].IncludeInFirstPlay = chkFirstPlay.Checked;
                    Songs[i].ARTIST = lblArtist.Text;
                    Songs[i].TITLE = lblTitle.Text;
                    Songs[i].CompanyId = Convert.ToInt32(ddlCompany.SelectedValue);
                    Songs[i].LabelId = Convert.ToInt32(ddlLabel.SelectedValue);
                    Songs[i].PromotionId = Convert.ToInt32(ddlPromoter.SelectedValue);
                    Songs[i].LABEL = ddlLabel.SelectedItem.Text;

                    Songs[i].Author = lblAuthor.Text;
                    Songs[i].Publisher = lblPublisher.Text;
                    Songs[i].Duration = txtDuration.Text;
                    Songs[i].ISRC = txtISRC.Text;


                }
                else
                {
                    Songs[i].CompanyId = Convert.ToInt32(ddlCompany.SelectedValue);
                    Songs[i].LabelId = Convert.ToInt32(ddlLabel.SelectedValue);
                    Songs[i].PromotionId = Convert.ToInt32(ddlPromoter.SelectedValue);
                    Songs[i].LABEL = ddlLabel.SelectedItem.Text;
                    Songs[i].AlternativeChart = chkAlternativeCharts.Checked;
                }
            }
            Session["eSongs"] = Songs;

            Response.Redirect("EditSong.aspx?id=" + e.CommandArgument);
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnk = (LinkButton)e.Row.FindControl("lnk");
                HiddenField hff = (HiddenField)e.Row.FindControl("hf");
                if (hff.Value != hf.Value)
                {
                    lnk.ForeColor = System.Drawing.Color.Gray;
                }
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Session["eSongs"] = null;
            Response.Redirect("Songs.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool error = false;
            if (Session["eSongs"] != null)
            {

                string previd = hfprevid.Value;

                List<clsSongs> Songs1 = (List<clsSongs>)Session["eSongs"];
                for (int i = 0; i < Songs1.Count; i++)
                {
                    if (Songs1[i].IdSong.ToString() == previd)
                    {
                        Songs1[i].VERSION = lblVersion.Text;
                        string[] d = lblRadio.Text.Split('/');
                        DateTime date = new DateTime(Convert.ToInt16(d[2]), Convert.ToInt16(d[1]), Convert.ToInt16(d[0]));
                        Songs1[i].RadioDate = date;
                        //Songs1[i].GENRE = lblGenre.Text;
                        Songs1[i].GENRE = ddlGenre.SelectedValue == "0" ? "Pop" : ddlGenre.SelectedValue == "1" ? "Rock" : ddlGenre.SelectedValue == "2" ? "Dance" : ddlGenre.SelectedValue == "3" ? "Hip Hop / Rap" : "Pop";// txtGenre.Text;;
                        //Songs1[i].LANGUAGE = lblLanguage.Text;
                        Songs1[i].LANGUAGE = ddlLanguage.SelectedValue == "1" ? "ita" : ddlLanguage.SelectedValue == "0" ? "int" : "int";


                        Songs1[i].TVSHOW = lblTvShow.Text;
                        Songs1[i].IncludeInNewTalent = chkAbsoluteBegin.Checked;
                        Songs1[i].AlternativeChart = chkAlternativeCharts.Checked;
                        Songs1[i].IncludeInFirstPlay = chkFirstPlay.Checked;
                        Songs1[i].ARTIST = lblArtist.Text;
                        Songs1[i].TITLE = lblTitle.Text;
                        Songs1[i].CompanyId = Convert.ToInt32(ddlCompany.SelectedValue);
                        Songs1[i].LabelId = Convert.ToInt32(ddlLabel.SelectedValue);
                        Songs1[i].PromotionId = Convert.ToInt32(ddlPromoter.SelectedValue);
                        Songs1[i].LABEL = ddlLabel.SelectedItem.Text;

                        Songs1[i].Author = lblAuthor.Text;
                        Songs1[i].Publisher = lblPublisher.Text;
                        Songs1[i].Duration = txtDuration.Text;
                        Songs1[i].ISRC = txtISRC.Text;

                    }
                    else
                    {
                        Songs1[i].CompanyId = Convert.ToInt32(ddlCompany.SelectedValue);
                        Songs1[i].LabelId = Convert.ToInt32(ddlLabel.SelectedValue);
                        Songs1[i].PromotionId = Convert.ToInt32(ddlPromoter.SelectedValue);
                        Songs1[i].LABEL = ddlLabel.SelectedItem.Text;
                        Songs1[i].AlternativeChart = chkAlternativeCharts.Checked;
                    }
                }
                Session["eSongs"] = Songs1;



                List<clsSongs> Songs = (List<clsSongs>)Session["eSongs"];
                if (Songs.Count > 0)
                {
                    foreach (clsSongs s in Songs)
                    {
                        if (string.IsNullOrEmpty(s.VERSION) || string.IsNullOrEmpty(s.LANGUAGE) || string.IsNullOrEmpty(s.GENRE) || string.IsNullOrEmpty(s.RadioDate.ToString())
                            || string.IsNullOrEmpty(s.ARTIST) || string.IsNullOrEmpty(s.TITLE))
                        {
                            error = true;
                            break;
                        }
                    }

                    if (!error)
                    {
                        foreach (clsSongs s in Songs)
                        {
                            clsSongsFactory fac = new clsSongsFactory();

                            fac.Update(s);

                        }
                        Session["eSongs"] = null;
                        Response.Redirect("Songs.aspx");

                    }
                    else
                    {
                        pnlError.Visible = true;
                        lblError.Text = "Please provide all data.";
                    }
                }
                else
                {
                    pnlError.Visible = true;
                    lblError.Text = "Some error ocurred please go back anf try again";
                }
            }
            else
            {
                pnlError.Visible = true;
                lblError.Text = "Some error ocurred please go back anf try again";
            }
        }
    }
}