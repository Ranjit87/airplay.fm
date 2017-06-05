using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SQLSoundManagement_BL.BusinessLayer;

namespace SQLMusicManagement
{
    /// <summary>
    /// Summary description for DBService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class DBService : System.Web.Services.WebService
    {

        [WebMethod]
        public string[] GetArtist(string prefixText, int count)
        {
            List<string> ajaxDataCollection = new List<string>();

            clsSongsFactory fac = new clsSongsFactory();
            List<clsSongs> songs = fac.GetAllArtists(prefixText);
            foreach (clsSongs s in songs)
            {
                ajaxDataCollection.Add(s.ARTIST);
            }

            return ajaxDataCollection.ToArray();
        }

        [WebMethod]
        public string[] GetTitle(string prefixText, int count)
        {
            List<string> ajaxDataCollection = new List<string>();

            clsSongsFactory fac = new clsSongsFactory();
            List<clsSongs> songs = fac.GetAllTitle(prefixText);
            foreach (clsSongs s in songs)
            {
                ajaxDataCollection.Add(s.TITLE);
            }

            return ajaxDataCollection.ToArray();
        }
        [WebMethod]
        public string[] GetGenre(string prefixText, int count)
        {
            List<string> ajaxDataCollection = new List<string>();

            clsSongsFactory fac = new clsSongsFactory();
            List<clsSongs> songs = fac.GetAllArtists(prefixText);
            foreach (clsSongs s in songs)
            {
                ajaxDataCollection.Add(s.GENRE);
            }

            if (ajaxDataCollection.Count > 0)
            {
                ajaxDataCollection = ajaxDataCollection.Distinct().ToList();
            }

            return ajaxDataCollection.ToArray();
        }

        [WebMethod]
        public string[] GetLanguage(string prefixText, int count)
        {
            List<string> ajaxDataCollection = new List<string>();

            clsSongsFactory fac = new clsSongsFactory();
            List<clsSongs> songs = fac.GetAllTitle(prefixText);
            foreach (clsSongs s in songs)
            {
                ajaxDataCollection.Add(s.LANGUAGE);
            }

            if (ajaxDataCollection.Count > 0)
            {
                ajaxDataCollection = ajaxDataCollection.Distinct().ToList();
            }

            return ajaxDataCollection.ToArray();
        }
        [WebMethod]
        public string[] GetTvShows(string prefixText, int count)
        {
            List<string> ajaxDataCollection = new List<string>();

            clsSongsFactory fac = new clsSongsFactory();
            List<clsSongs> songs = fac.GetAllTvShows(prefixText);
            foreach (clsSongs s in songs)
            {
                ajaxDataCollection.Add(s.TVSHOW);
            }

            return ajaxDataCollection.ToArray();
        }
    }
}
