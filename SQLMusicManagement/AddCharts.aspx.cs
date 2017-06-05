using SQLSoundManagement_BL.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SQLMusicManagement
{
    public partial class AddCharts : System.Web.UI.Page
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

                    Session["Emergenti"] = null;
                    Session["eEmergenti"] = null;
                    if (Request.QueryString != null && Request.QueryString["id"] != null)
                    {
                        hf.Value = Request.QueryString["id"];
                        //clsCompaniesFactory fac = new clsCompaniesFactory();
                        //clsCompaniesKeys key = new clsCompaniesKeys(Convert.ToInt32(hf.Value));
                        //clsCompanies Company = fac.GetByPrimaryKey(key);

                        //txtcompany.Text = Company.Company;
                        //txtFullName.Text = Company.FullName;
                        //ddlFirst.SelectedValue = Company.Data == true ? "0" : "1";
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

            string Position1 = lbl_1.Text;
            string txtArt_101 = txtArt_1.Text;
            string txtTit_101 = txtTit_1.Text;
            string txtEtt_101 = txtEtt_1.Text;
            clsEmergentiList.Add(new clsEmergenti { Settimana = week, Posizione = Position1, Artista = txtArt_101, Titolo = txtTit_101, Etichetta = txtEtt_101 });

            string Position2 = lbl_2.Text;
            string txtArt_102 = txtArt_2.Text;
            string txtTit_102 = txtTit_2.Text;
            string txtEtt_102 = txtEtt_2.Text;
            clsEmergentiList.Add(new clsEmergenti { Settimana = week, Posizione = Position2, Artista = txtArt_102, Titolo = txtTit_102, Etichetta = txtEtt_102 });

            string Position3 = lbl_3.Text;
            string txtArt_103 = txtArt_3.Text;
            string txtTit_103 = txtTit_3.Text;
            string txtEtt_103 = txtEtt_3.Text;
            clsEmergentiList.Add(new clsEmergenti { Settimana = week, Posizione = Position3, Artista = txtArt_103, Titolo = txtTit_103, Etichetta = txtEtt_103 });

            string Position4 = lbl_4.Text;
            string txtArt_104 = txtArt_4.Text;
            string txtTit_104 = txtTit_4.Text;
            string txtEtt_104 = txtEtt_4.Text;
            clsEmergentiList.Add(new clsEmergenti { Settimana = week, Posizione = Position4, Artista = txtArt_104, Titolo = txtTit_104, Etichetta = txtEtt_104 });

            string Position5 = lbl_5.Text;
            string txtArt_105 = txtArt_5.Text;
            string txtTit_105 = txtTit_5.Text;
            string txtEtt_105 = txtEtt_5.Text;
            clsEmergentiList.Add(new clsEmergenti { Settimana = week, Posizione = Position5, Artista = txtArt_105, Titolo = txtTit_105, Etichetta = txtEtt_105 });

            string Position6 = lbl_6.Text;
            string txtArt_106 = txtArt_6.Text;
            string txtTit_106 = txtTit_6.Text;
            string txtEtt_106 = txtEtt_6.Text;
            clsEmergentiList.Add(new clsEmergenti { Settimana = week, Posizione = Position6, Artista = txtArt_106, Titolo = txtTit_106, Etichetta = txtEtt_106 });

            string Position7 = lbl_7.Text;
            string txtArt_107 = txtArt_7.Text;
            string txtTit_107 = txtTit_7.Text;
            string txtEtt_107 = txtEtt_7.Text;
            clsEmergentiList.Add(new clsEmergenti { Settimana = week, Posizione = Position7, Artista = txtArt_107, Titolo = txtTit_107, Etichetta = txtEtt_107 });

            string Position8 = lbl_8.Text;
            string txtArt_108 = txtArt_8.Text;
            string txtTit_108 = txtTit_8.Text;
            string txtEtt_108 = txtEtt_8.Text;
            clsEmergentiList.Add(new clsEmergenti { Settimana = week, Posizione = Position8, Artista = txtArt_108, Titolo = txtTit_108, Etichetta = txtEtt_108 });

            string Position9 = lbl_9.Text;
            string txtArt_109 = txtArt_9.Text;
            string txtTit_109 = txtTit_9.Text;
            string txtEtt_109 = txtEtt_9.Text;
            clsEmergentiList.Add(new clsEmergenti { Settimana = week, Posizione = Position9, Artista = txtArt_109, Titolo = txtTit_109, Etichetta = txtEtt_109 });

            string Position10 = lbl_10.Text;
            string txtArt_110 = txtArt_10.Text;
            string txtTit_110 = txtTit_10.Text;
            string txtEtt_110 = txtEtt_10.Text;
            clsEmergentiList.Add(new clsEmergenti { Settimana = week, Posizione = Position10, Artista = txtArt_110, Titolo = txtTit_110, Etichetta = txtEtt_110 });

            string Position11 = lbl_11.Text;
            string txtArt_1011 = txtArt_11.Text;
            string txtTit_1011 = txtTit_11.Text;
            string txtEtt_1011 = txtEtt_11.Text;
            clsEmergentiList.Add(new clsEmergenti { Settimana = week, Posizione = Position11, Artista = txtArt_1011, Titolo = txtTit_1011, Etichetta = txtEtt_1011 });

            string Position12 = lbl_12.Text;
            string txtArt_1012 = txtArt_12.Text;
            string txtTit_1012 = txtTit_12.Text;
            string txtEtt_1012 = txtEtt_12.Text;
            clsEmergentiList.Add(new clsEmergenti { Settimana = week, Posizione = Position12, Artista = txtArt_1012, Titolo = txtTit_1012, Etichetta = txtEtt_1012 });

            string Position13 = lbl_13.Text;
            string txtArt_1013 = txtArt_13.Text;
            string txtTit_1013 = txtTit_13.Text;
            string txtEtt_1013 = txtEtt_13.Text;
            clsEmergentiList.Add(new clsEmergenti { Settimana = week, Posizione = Position13, Artista = txtArt_1013, Titolo = txtTit_1013, Etichetta = txtEtt_1013 });

            string Position14 = lbl_14.Text;
            string txtArt_1014 = txtArt_14.Text;
            string txtTit_1014 = txtTit_14.Text;
            string txtEtt_1014 = txtEtt_14.Text;
            clsEmergentiList.Add(new clsEmergenti { Settimana = week, Posizione = Position14, Artista = txtArt_1014, Titolo = txtTit_1014, Etichetta = txtEtt_1014 });

            string Position15 = lbl_15.Text;
            string txtArt_1015 = txtArt_15.Text;
            string txtTit_1015 = txtTit_15.Text;
            string txtEtt_1015 = txtEtt_15.Text;
            clsEmergentiList.Add(new clsEmergenti { Settimana = week, Posizione = Position15, Artista = txtArt_1015, Titolo = txtTit_1015, Etichetta = txtEtt_1015 });

            string Position16 = lbl_16.Text;
            string txtArt_1016 = txtArt_16.Text;
            string txtTit_1016 = txtTit_16.Text;
            string txtEtt_1016 = txtEtt_16.Text;
            clsEmergentiList.Add(new clsEmergenti { Settimana = week, Posizione = Position16, Artista = txtArt_1016, Titolo = txtTit_1016, Etichetta = txtEtt_1016 });

            string Position17 = lbl_17.Text;
            string txtArt_1017 = txtArt_17.Text;
            string txtTit_1017 = txtTit_17.Text;
            string txtEtt_1017 = txtEtt_17.Text;
            clsEmergentiList.Add(new clsEmergenti { Settimana = week, Posizione = Position17, Artista = txtArt_1017, Titolo = txtTit_1017, Etichetta = txtEtt_1017 });

            string Position18 = lbl_18.Text;
            string txtArt_1018 = txtArt_18.Text;
            string txtTit_1018 = txtTit_18.Text;
            string txtEtt_1018 = txtEtt_18.Text;
            clsEmergentiList.Add(new clsEmergenti { Settimana = week, Posizione = Position18, Artista = txtArt_1018, Titolo = txtTit_1018, Etichetta = txtEtt_1018 });

            string Position19 = lbl_19.Text;
            string txtArt_1019 = txtArt_19.Text;
            string txtTit_1019 = txtTit_19.Text;
            string txtEtt_1019 = txtEtt_19.Text;
            clsEmergentiList.Add(new clsEmergenti { Settimana = week, Posizione = Position19, Artista = txtArt_1019, Titolo = txtTit_1019, Etichetta = txtEtt_1019 });

            string Position20 = lbl_20.Text;
            string txtArt_1020 = txtArt_20.Text;
            string txtTit_1020 = txtTit_20.Text;
            string txtEtt_1020 = txtEtt_20.Text;
            clsEmergentiList.Add(new clsEmergenti { Settimana = week, Posizione = Position20, Artista = txtArt_1020, Titolo = txtTit_1020, Etichetta = txtEtt_1020 });

            foreach (var item in clsEmergentiList)
            {
                clsEmergenti Emergenti = new clsEmergenti();
                Emergenti.Settimana = item.Settimana;
                Emergenti.Posizione = item.Posizione;
                Emergenti.Artista = item.Artista;
                Emergenti.Titolo = item.Titolo;
                Emergenti.Etichetta = item.Etichetta;
                Emergenti.Anno = item.Etichetta;
                if (!string.IsNullOrEmpty(Emergenti.Artista) && !string.IsNullOrEmpty(Emergenti.Titolo))
                {
                    fac.Insert(Emergenti);
                }
            }

            pnlSuccess.Visible = true;
            lblSuccess.Text = "Chart added successfully";
            pnlError.Visible = false;

            Response.Redirect("Charts.aspx");
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCharts.aspx");
        }
    }

    public class clsArtist
    {
        public int SongID { get; set; }
        public string ArtistName { get; set; }
        public string TitleName { get; set; }
        public string lableName { get; set; }
    }
}