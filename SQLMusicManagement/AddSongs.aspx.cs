using SQLSoundManagement_BL.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SQLMusicManagement
{


    public partial class AddSongs : System.Web.UI.Page
    {
        public bool IsEnglish(string inputstring)
        {
            return true;

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
                    Session["Songs"] = null;
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
                        clsCompaniesFactory fac = new clsCompaniesFactory();
                        clsCompaniesKeys key = new clsCompaniesKeys(Convert.ToInt32(hf.Value));
                        clsCompanies Company = fac.GetByPrimaryKey(key);

                    }
                    LoadData();
                }
                else
                { Response.Redirect("Login.aspx"); }
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
            ddlPromoter.SelectedValue = "11";
            ddlPromoter.DataBind();

            //List<clsGenre> GenreList = new List<clsGenre>();
            //clsSongsFactory fac2 = new clsSongsFactory();
            //List<clsSongs> Songs1 = fac2.GetAllArtists("");
            //foreach (clsSongs s in Songs1)
            //{
            //    if (!string.IsNullOrEmpty(s.GENRE))
            //    {
            //        if (!GenreList.Any(d => d.Value.Contains(s.GENRE)))// s.GENRE.ToLower() == "pop" || s.GENRE.ToLower() == "rock" || s.GENRE.ToLower() == "dance")
            //            GenreList.Add(new clsGenre { Key = s.GENRE.ToLower(), Value = s.GENRE });
            //    }
            //}
            //GenreList = GenreList.Distinct().ToList();
            //ddlGenre.DataSource = GenreList;
            //ddlGenre.DataTextField = "Value";
            //ddlGenre.DataValueField = "Key";
            //ddlGenre.DataBind();

            //List<clsLanguage> LanguageList = new List<clsLanguage>();
            //List<clsSongs> Songs2 = fac2.GetAllTitle("");
            //foreach (clsSongs s in Songs2)
            //{
            //    if (!string.IsNullOrEmpty(s.LANGUAGE))
            //    {
            //        if (s.LANGUAGE.ToLower() == "int" || s.LANGUAGE.ToLower() == "ita")
            //            LanguageList.Add(new clsLanguage { Key = s.LANGUAGE.ToLower(), Value = s.LANGUAGE });
            //    }
            //}
            //LanguageList = LanguageList.Distinct().ToList();
            //ddlLanguage.DataSource = LanguageList;
            //ddlLanguage.DataTextField = "Value";
            //ddlLanguage.DataValueField = "Key";
            //ddlLanguage.DataBind();

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            CultureInfo cinfo = new CultureInfo("it-IT");

            clsSongsFactory fac = new clsSongsFactory();
            clsSongs Song = new clsSongs();
            if (!String.IsNullOrEmpty(hfname.Value))
            {
                if (IsEnglish(hfname.Value))
                {
                    if (!hfname.Value.ToLower().Contains(".part"))
                    {
                        Song.ARTIST = txtArtist.Text;
                        Song.CompanyId = Convert.ToInt32(ddlCompany.SelectedValue);
                        Song.FILENAME = hfname.Value;

                        Song.GENRE = ddlGenre.SelectedValue == "0" ? "Pop" : ddlGenre.SelectedValue == "1" ? "Rock" : ddlGenre.SelectedValue == "2" ? "Dance" : ddlGenre.SelectedValue == "3" ? "Hip Hop / Rap" : "Pop";// txtGenre.Text;
                        Song.IncludeInFirstPlay = ddlFirstPlayView.SelectedValue == "1" ? false : true;
                        Song.LABEL = ddlLabel.SelectedItem.Text;
                        Song.LabelId = Convert.ToInt32(ddlLabel.SelectedValue);
                        Song.LANGUAGE = ddlLanguage.SelectedValue == "1" ? "ita" : ddlLanguage.SelectedValue == "0" ? "int" : "int";// txtLanguage.Text;
                        string[] d = txtRadioDate.Text.Split('/');
                        DateTime date = new DateTime(Convert.ToInt16(d[2]), Convert.ToInt16(d[1]), Convert.ToInt16(d[0]));
                        Song.RadioDate = date;
                        Song.TITLE = txtTitle.Text;

                        Song.Author = txtAuthor.Text;
                        Song.Publisher = txtPublisher.Text;
                        Song.Duration = txtDuration.Text;
                        Song.ISRC = txtISRC.Text;

                        Song.TVSHOW = txtTVShow.Text;
                        Song.VERSION = txtVersion.Text;
                        Song.IncludeInNewTalent = ddlAbsoluteBeginner.SelectedValue == "1" ? false : true;
                        Song.PromotionId = Convert.ToInt32(ddlPromoter.SelectedValue);
                        Song.AlternativeChart = chkAlternativeCharts.Checked;
                        //string folderPath = ConfigurationManager.AppSettings["folder"];                    

                        int IsExist = fac.InsertExist_Check(Song);
                        if (IsExist == 0)
                        {
                            int IdSong = fac.Insert(Song);

                            if (IdSong == -1)
                            {
                                pnlError.Visible = true;
                                lblError.Text = "Artist + Title + Version already exist.";
                            }
                            else if (IdSong == -2)
                            {
                                pnlError.Visible = true;
                                lblError.Text = "File Name already exist.";
                            }
                            else
                            {
                                Response.Redirect("SongDetail.aspx?id=" + IdSong);
                                Session["Songs"] = null;
                            }
                        }
                        else if (IsExist == -1)
                        {
                            pnlError.Visible = true;
                            lblError.Text = "Artist + Title already exist.";
                        }
                        else if (IsExist == -2)
                        {
                            pnlError.Visible = true;
                            lblError.Text = "File Name already exist.";
                        }
                    }
                    else
                    {
                        pnlError.Visible = true;
                        lblError.Text = "filename must contains MP3.";
                    }
                }
                else
                {
                    pnlError.Visible = true;
                    lblError.Text = "File name contains illegal characters";
                }
            }
            else
            {
                pnlError.Visible = true;
                lblError.Text = "Please select a file first";
            }
        }

        protected void btjcancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddSongs.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtArtist.Text) && string.IsNullOrEmpty(txtTitle.Text))
            {
                pnlError.Visible = true;
                lblError.Text = "Please Enter Artist and Title";
            }
            else if (string.IsNullOrEmpty(txtArtist.Text))
            {
                pnlError.Visible = true;
                lblError.Text = "Please Enter Artist";
            }
            else if (string.IsNullOrEmpty(txtTitle.Text))
            {
                pnlError.Visible = true;
                lblError.Text = "Please Enter Title";
            }
            else
            {
                pnlError.Visible = false;
                clsSongsFactory fac = new clsSongsFactory();
                List<clsSongs> Songs = fac.GetAllByArtistsTitle(txtArtist.Text, txtTitle.Text);
                rpt.DataSource = Songs;
                rpt.DataBind();
                pnlSearch.Visible = true;
            }
            pnlComapny.Visible = false;
            pnlAddLabel.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            clsLabelsFactory fac = new clsLabelsFactory();
            List<clsLabels> lbl = fac.GetAllBy(clsLabels.clsLabelsFields.Title, txtLable.Text);
            if (lbl != null && lbl.Count > 0)
            {
                pnlSuccess.Visible = false;
                pnlError.Visible = true;
                lblError.Text = "Label already exists";
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
            LoadData();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            pnlAddLabel.Visible = false;
        }

        protected void btnLabel_Click(object sender, EventArgs e)
        {
            pnlComapny.Visible = false;
            pnlSearch.Visible = false;
            pnlAddLabel.Visible = true;
        }

        //protected void btnPromoter_Click(object sender, EventArgs e)
        //{
        //    pnlComapny.Visible = false;
        //    pnlSearch.Visible = false;
        //    pnlAddLabel.Visible = true;
        //}

        protected void btnCompany_Click(object sender, EventArgs e)
        {
            pnlComapny.Visible = true;
            pnlSearch.Visible = false;
            pnlAddLabel.Visible = false;
        }

        protected void btnCompsub_Click(object sender, EventArgs e)
        {
            clsCompaniesFactory fac = new clsCompaniesFactory();
            List<clsCompanies> lbl = fac.GetAllBy(clsCompanies.clsCompaniesFields.Company, txtcompany.Text);
            if (lbl != null && lbl.Count > 0)
            {
                pnlSuccess.Visible = false;
                pnlError.Visible = true;
                lblError.Text = "company already exists";
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
            LoadData();
        }

        protected void btncompCan_Click(object sender, EventArgs e)
        {
            pnlComapny.Visible = false;
        }



    }

    public class clsGenre
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public class clsLanguage
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}