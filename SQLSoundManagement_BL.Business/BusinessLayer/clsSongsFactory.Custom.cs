using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SQLSoundManagement_BL.BusinessLayer.DataLayer;

namespace SQLSoundManagement_BL.BusinessLayer
{
    public partial class clsSongsFactory
    {

        public List<clsSongs> GetAllArtists(string prefix)
        {
            return _dataObject.SelectAllArtists(prefix);
        }
        public List<clsSongs> GetAllTitle(string prefix)
        {
            return _dataObject.SelectAllTitles(prefix);
        }
        public List<clsSongs> GetAllGenre(string prefix)
        {
            return _dataObject.SelectAllGenre(prefix);
        }
        public List<clsSongs> GetAllLanguages(string prefix)
        {
            return _dataObject.SelectAllLanguages(prefix);
        }
        public List<clsSongs> GetAllTvShows(string prefix)
        {
            return _dataObject.SelectAllTvShows(prefix);
        }
        public List<clsSongs> GetAllByArtistsTitle(string Artist, string Title)
        {
            return _dataObject.SelectAllByArtistsTitle(Artist, Title);
        }
        public List<clsSongs> GetAllByVersions(int IdSong)
        {
            return _dataObject.SelectAllByVersions(IdSong);
        }
    }
}
