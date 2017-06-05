using System;
using System.Collections.Generic;
using System.Text;

namespace SQLSoundManagement_BL.BusinessLayer
{
    public class clsPromotion : BusinessObjectBase
    {
        #region InnerClass
        public enum clsPromotionFields
        {
            Id,
            Title,
            IdSong,
            TotalSongs
        }
        #endregion

        #region Data Members

        int _Id;
        string _Title;
        int _IdSong;
        int _TotalSongs;

        #endregion

        #region Properties

        public int Id
        {
            get { return _Id; }
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                    PropertyHasChanged("Id");
                }
            }
        }

        public string Title
        {
            get { return _Title; }
            set
            {
                if (_Title != value)
                {
                    _Title = value;
                    PropertyHasChanged("Title");
                }
            }
        }

        public int IdSong
        {
            get { return _IdSong; }
            set
            {
                if (_IdSong != value)
                {
                    _IdSong = value;
                    PropertyHasChanged("IdSong");
                }
            }
        }

        public int TotalSongs
        {
            get { return _TotalSongs; }
            set
            {
                if (_TotalSongs != value)
                {
                    _TotalSongs = value;
                    PropertyHasChanged("TotalSongs");
                }
            }
        }


        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Id", "Id"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Title", "Title", 1024));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("IdSong", "IdSong"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("TotalSongs", "TotalSongs"));
        }

        #endregion

    }
}
