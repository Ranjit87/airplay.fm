using SQLSoundManagement_BL.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SQLMusicManagement
{
    public partial class EditChart : System.Web.UI.Page
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
                    ManageEmergenti.Attributes.Add("class", "current");
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

                    LoadData();

                    Session["Emergenti"] = null;
                    Session["eEmergenti"] = null;
                    if (Request.QueryString != null && Request.QueryString["id"] != null)
                    {
                        hf.Value = Request.QueryString["id"];
                        clsEmergentiFactory fac = new clsEmergentiFactory();
                        clsEmergentiKeys key = new clsEmergentiKeys(Convert.ToInt32(hf.Value));
                        clsEmergenti Emergenti = fac.GetByPrimaryKey(key);

                        ddlSettimana.SelectedItem.Value = Emergenti.Settimana;
                        lbl_1.Text = Emergenti.Posizione;
                        txtArt_1.Text = Emergenti.Artista;
                        txtTit_1.Text = Emergenti.Titolo;
                        txtEtt_1.Text = Emergenti.Anno;
                    }
                    LoadData();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        private void LoadData()
        {
            var jan1 = new DateTime(DateTime.Today.Year, 1, 1);
            var startOfFirstWeek = jan1.AddDays(1 - (int)(jan1.DayOfWeek));
            var weeks =
                Enumerable
                    .Range(0, 54)
                    .Select(i => new
                    {
                        weekStart = startOfFirstWeek.AddDays(i * 7)
                    })
                    .TakeWhile(x => x.weekStart.Year <= jan1.Year)
                    .Select(x => new
                    {
                        x.weekStart,
                        weekFinish = x.weekStart.AddDays(4)
                    })
                    .SkipWhile(x => x.weekFinish < jan1.AddDays(1))
                    .Select((x, i) => new
                    {
                        x.weekStart,
                        x.weekFinish,
                        weekNum = i + 1
                    });

            CultureInfo myCI = new CultureInfo("en-US");
            System.Globalization.Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
            int week = myCal.GetWeekOfYear(DateTime.Now, myCWR, myFirstDOW);

            var WeekList = weeks.ToList();
            ddlSettimana.DataSource = WeekList;
            ddlSettimana.DataTextField = "weekNum";
            ddlSettimana.DataValueField = "weekNum";
            ddlSettimana.SelectedValue = week.ToString();
            ddlSettimana.DataBind();



        }

        [WebMethod]
        public static List<clsArtist> GetArtistList(string artist)
        {
            List<clsArtist> ArtistList = new List<clsArtist>();
            clsSongsFactory fac = new clsSongsFactory();
            var Songs = fac.GetAllArtists(artist).Take(15);
            foreach (var item in Songs)
            {
                clsArtist ObjclsArtist = new clsArtist();
                ObjclsArtist.SongID = item.IdSong;
                ObjclsArtist.ArtistName = item.ARTIST;
                ObjclsArtist.TitleName = item.TITLE;
                ObjclsArtist.lableName = item.LABEL;
                ArtistList.Add(ObjclsArtist);
            }
            return ArtistList;
        }

        [WebMethod]
        public static List<clsArtist> GetTitleList(string artist, string title)
        {
            List<clsArtist> ArtistList = new List<clsArtist>();
            clsSongsFactory fac = new clsSongsFactory();
            var Songs = fac.GetAllByArtistsTitle(artist, title).Take(15);
            foreach (var item in Songs)
            {
                clsArtist ObjclsArtist = new clsArtist();
                ObjclsArtist.SongID = item.IdSong;
                ObjclsArtist.ArtistName = item.ARTIST;
                ObjclsArtist.TitleName = item.TITLE;
                ObjclsArtist.lableName = item.LABEL;
                ArtistList.Add(ObjclsArtist);
            }
            return ArtistList;
        }

        [WebMethod]
        public static List<clsArtist> GetLabelList(string artist, string title, string etichetta)
        {
            List<clsArtist> ArtistList = new List<clsArtist>();
            clsSongsFactory fac = new clsSongsFactory();
            var Songs = fac.GetAllByArtistsTitle(artist, title).Take(15);
            foreach (var item in Songs)
            {
                clsArtist ObjclsArtist = new clsArtist();
                ObjclsArtist.SongID = item.IdSong;
                ObjclsArtist.ArtistName = item.ARTIST;
                ObjclsArtist.TitleName = item.TITLE;
                ObjclsArtist.lableName = item.LABEL;
                ArtistList.Add(ObjclsArtist);
            }
            return ArtistList;
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            List<clsEmergenti> clsEmergentiList = new List<clsEmergenti>();

            clsEmergentiFactory fac = new clsEmergentiFactory();

            string week = ddlSettimana.SelectedItem.Value;

            int ID = Convert.ToInt32(hf.Value);
            string Position1 = lbl_1.Text;
            string txtArt_101 = txtArt_1.Text;
            string txtTit_101 = txtTit_1.Text;
            string txtEtt_101 = txtEtt_1.Text;
            clsEmergentiList.Add(new clsEmergenti { ID = ID, Settimana = week, Posizione = Position1, Artista = txtArt_101, Titolo = txtTit_101, Etichetta = txtEtt_101 });
            foreach (var item in clsEmergentiList)
            {
                clsEmergenti Emergenti = new clsEmergenti();
                Emergenti.ID = item.ID;
                Emergenti.Settimana = item.Settimana;
                Emergenti.Posizione = item.Posizione;
                Emergenti.Artista = item.Artista;
                Emergenti.Titolo = item.Titolo;
                Emergenti.Etichetta = item.Etichetta;
                Emergenti.Anno = item.Etichetta;
                if (!string.IsNullOrEmpty(Emergenti.Artista) && !string.IsNullOrEmpty(Emergenti.Titolo))
                {
                    fac.Update(Emergenti);
                }
            }

            pnlSuccess.Visible = true;
            lblSuccess.Text = "Chart updated successfully";
            pnlError.Visible = false;

            Response.Redirect("Charts.aspx");
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Charts.aspx");
        }





    }
}