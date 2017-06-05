using SQLSoundManagement_BL.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SQLMusicManagement
{
    public partial class SongDetail : System.Web.UI.Page
    {
        public bool IsEnglish(string inputstring)
        {
            Regex regex = new Regex(@"[A-Za-z0-9_ .,-=+()!#$%^&*~{}\[\]\\]");
            MatchCollection matches = regex.Matches(inputstring);

            if (matches.Count.Equals(inputstring.Length))
                return true;
            else
                return false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    Session["eSongs"] = null;
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

                    if (Request.QueryString != null && Request.QueryString["id"] != null)
                    {
                        hf.Value = Request.QueryString["id"];
                        hfprevid.Value = Request.QueryString["id"];
                        clsSongsFactory fac = new clsSongsFactory();
                        List<clsSongs> Songs = fac.GetAllByVersions(Convert.ToInt32(hf.Value));

                        pnlButtons.Visible = true;
                        pnlSave.Visible = false;

                        if (Songs != null && Songs.Count > 0 && Session["Songs"] == null)
                        {
                            grd.DataSource = Songs;
                            grd.DataBind();
                            Session["Songs"] = Songs;

                            clsSongs Song = Songs.First(x => x.IdSong == Convert.ToInt32(hf.Value));

                            lblVersion.Text = Song.VERSION;
                            chkAbsoluteBegin.Checked = Song.IncludeInNewTalent;
                            chkAlternativeCharts.Checked = Song.AlternativeChart;
                            chkFirstPlay.Checked = Song.IncludeInFirstPlay;
                            lblGenre.Text = Song.GENRE;
                            lblLanguage.Text = Song.LANGUAGE;
                            lblRadio.Text = Song.RadioDate == null ? "" : Song.RadioDate.Value.ToString("dd/MM/yyyy");
                            lblTvShow.Text = Song.TVSHOW;

                            lblArtist.Text = Song.ARTIST;
                            lblTitle.Text = Song.TITLE;
                            lblAuthor.Text = Song.Author;
                            lblPublisher.Text = Song.Publisher;
                            lblDuration.Text = Song.Duration;
                            lblISRC.Text = Song.ISRC;

                            lblLabel.Text = Song.LABEL;
                            clsCompaniesFactory facC = new clsCompaniesFactory();
                            clsCompaniesKeys k = new clsCompaniesKeys(Songs[0].CompanyId.Value);
                            clsCompanies c = facC.GetByPrimaryKey(k);
                            lblCompany.Text = c.FullName;
                        }
                        else
                        {
                            Songs = (List<clsSongs>)Session["Songs"];
                            grd.DataSource = Songs;
                            grd.DataBind();
                            clsSongs Song = Songs.Where(x => x.IdSong == Convert.ToInt32(hf.Value)).FirstOrDefault();

                            pnlButtons.Visible = false;
                            pnlSave.Visible = true;

                            lblVersion.Text = Song.VERSION;
                            chkAbsoluteBegin.Checked = Song.IncludeInNewTalent;
                            chkAlternativeCharts.Checked = Song.AlternativeChart;
                            chkFirstPlay.Checked = Song.IncludeInFirstPlay;
                            lblGenre.Text = Song.GENRE;
                            lblLanguage.Text = Song.LANGUAGE;
                            lblRadio.Text = Song.RadioDate.Value.ToString("dd/MM/yyyy");
                            lblTvShow.Text = Song.TVSHOW;

                            lblArtist.Text = Song.ARTIST;
                            lblTitle.Text = Song.TITLE;

                            lblAuthor.Text = Song.Author;
                            lblPublisher.Text = Song.Publisher;
                            lblDuration.Text = Song.Duration;
                            lblISRC.Text = Song.ISRC;

                            lblLabel.Text = Song.LABEL;
                            clsCompaniesFactory facC = new clsCompaniesFactory();
                            clsCompaniesKeys k = new clsCompaniesKeys(Song.CompanyId.Value);
                            clsCompanies c = facC.GetByPrimaryKey(k);
                            lblCompany.Text = c.FullName;
                        }
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string previd = hfprevid.Value;
            hfprevid.Value = e.CommandArgument.ToString();

            List<clsSongs> Songs = (List<clsSongs>)Session["Songs"];
            for (int i = 0; i < Songs.Count; i++
                )
            {
                if (Songs[i].IdSong.ToString() == previd)
                {
                    Songs[i].VERSION = lblVersion.Text;
                    string[] d = lblRadio.Text.Split('/');
                    DateTime date = new DateTime(Convert.ToInt16(d[2]), Convert.ToInt16(d[1]), Convert.ToInt16(d[0]));
                    Songs[i].RadioDate = date;
                    Songs[i].GENRE = lblGenre.Text;
                    Songs[i].LANGUAGE = lblLanguage.Text;
                    Songs[i].TVSHOW = lblTvShow.Text;
                    Songs[i].IncludeInNewTalent = chkAbsoluteBegin.Checked;
                    Songs[i].AlternativeChart = chkAlternativeCharts.Checked;
                    Songs[i].IncludeInFirstPlay = chkFirstPlay.Checked;

                    Songs[i].Duration = lblDuration.Text;
                    Songs[i].ISRC = lblISRC.Text;
                }
            }
            Session["Songs"] = Songs;

            Response.Redirect("songdetail.aspx?id=" + e.CommandArgument);
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
            Session["Songs"] = null;
            Response.Redirect("Songs.aspx");
        }

        protected void AddNewVersion_Click(object sender, EventArgs e)
        {
            pnlButtons.Visible = false;
            pnlSave.Visible = true;
        }

        protected void EditSong_Click(object sender, EventArgs e)
        {
            List<clsSongs> Songs = (List<clsSongs>)Session["Songs"];
            Session["Songs"] = null;
            Response.Redirect("EditSong.aspx?id=" + Songs[0].IdSong);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool error = false;
            if (Session["Songs"] != null)
            {

                string previd = hfprevid.Value;

                List<clsSongs> Songs1 = (List<clsSongs>)Session["Songs"];
                for (int i = 0; i < Songs1.Count; i++)
                {
                    if (Songs1[i].IdSong.ToString() == previd)
                    {
                        Songs1[i].VERSION = lblVersion.Text;
                        string[] d = lblRadio.Text.Split('/');
                        DateTime date = new DateTime(Convert.ToInt16(d[2]), Convert.ToInt16(d[1]), Convert.ToInt16(d[0]));
                        Songs1[i].RadioDate = date;
                        Songs1[i].GENRE = lblGenre.Text;
                        Songs1[i].LANGUAGE = lblLanguage.Text;
                        Songs1[i].TVSHOW = lblTvShow.Text;
                        Songs1[i].IncludeInNewTalent = chkAbsoluteBegin.Checked;
                        Songs1[i].AlternativeChart = chkAlternativeCharts.Checked;
                        Songs1[i].IncludeInFirstPlay = chkFirstPlay.Checked;

                        Songs1[i].Duration = lblDuration.Text;
                        Songs1[i].ISRC = lblISRC.Text;

                    }
                }
                Session["Songs"] = Songs1;

                List<clsSongs> Songs = (List<clsSongs>)Session["Songs"];
                if (Songs.Count > 0)
                {
                    foreach (clsSongs s in Songs)
                    {
                        if (string.IsNullOrEmpty(s.VERSION) || string.IsNullOrEmpty(s.LANGUAGE) || string.IsNullOrEmpty(s.GENRE) || string.IsNullOrEmpty(s.RadioDate.ToString()))
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
                            clsSongsKeys key = new clsSongsKeys(s.IdSong);
                            clsSongs _song = fac.GetByPrimaryKey(key);

                            if (_song != null)
                            {
                                fac.Update(s);
                                Session["SuccessMsg"] = "Record Updated Successfully.";
                            }
                            else
                            {
                                fac.Insert(s);
                                Session["SuccessMsg"] = "Record Added Successfully.";
                            }
                        }
                        Session["Songs"] = null;
                        Response.Redirect("Songs.aspx");

                    }
                    else
                    {
                        Session["ErrorMsg"] = "Error occured! Please try again later.";
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

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hfname.Value))
            {
                if (IsEnglish(hfname.Value))
                {
                    Helper h = new Helper();

                    List<clsSongs> Songs = (List<clsSongs>)Session["Songs"];
                    clsSongs Song = new clsSongs();
                    Song.ARTIST = Songs[0].ARTIST;
                    Song.CompanyId = Songs[0].CompanyId;
                    Song.FILENAME = hfname.Value;
                    Song.FirstPlayDate = Songs[0].FirstPlayDate;
                    Song.GENRE = Songs[0].GENRE;
                    Song.IncludeInFirstPlay = Songs[0].IncludeInFirstPlay;
                    Song.IncludeInNewTalent = Songs[0].IncludeInNewTalent;
                    Song.LABEL = Songs[0].LABEL;
                    Song.LabelId = Songs[0].LabelId;
                    Song.LANGUAGE = Songs[0].LANGUAGE;
                    Song.ParentSongId = Songs[0].IdSong;
                    Song.RadioDate = Songs[0].RadioDate;
                    Song.TITLE = Songs[0].TITLE;
                    Song.TVSHOW = Songs[0].TVSHOW;
                    //Song.VERSION = Songs[0].VERSION;
                    Song.IdSong = h.GetNewInt();

                    Song.Author = Songs[0].Author;
                    Song.Publisher = Songs[0].Publisher;
                    Song.Duration = Songs[0].Duration;
                    Song.ISRC = Songs[0].ISRC;

                    Songs.Add(Song);

                    grd.DataSource = Songs;
                    grd.DataBind();
                    pnlError.Visible = false;
                    pnlSuccess.Visible = true;
                    lblSuccess.Text = "Version added successfully";
                }
                else
                {
                    pnlError.Visible = true;
                    pnlSuccess.Visible = false;
                    lblError.Text = "File name contains illegal characters";
                }
            }
            else
            {
                pnlError.Visible = true;
                pnlSuccess.Visible = false;
                lblError.Text = "Please select file first";
            }
        }
    }
}