using System;
using System.Collections.Generic;
using System.Text;
namespace SQLSoundManagement_BL.BusinessLayer
{
    public class clsShazam : BusinessObjectBase
    {

        #region InnerClass
        public enum clsShazamFields
        {
            ID,
            Week,
            Year,
            Position,
            Artist,
            Title

        }
        #endregion

        #region Data Members

        int _iD;
        int _wEEk;
        int _yEAR;
        string _pOSITION;
        string _aRTIST;
        string _tITLE;

        #endregion

        #region Properties

        public int ID
        {
            get { return _iD; }
            set
            {
                if (_iD != value)
                {
                    _iD = value;
                    PropertyHasChanged("ID");
                }
            }
        }

        public int Week
        {
            get { return _wEEk; }
            set
            {
                if (_wEEk != value)
                {
                    _wEEk = value;
                    PropertyHasChanged("Week");
                }
            }
        }

        public int Year
        {
            get { return _yEAR; }
            set
            {
                if (_yEAR != value)
                {
                    _yEAR = value;
                    PropertyHasChanged("Year");
                }
            }
        }

        public string Position
        {
            get { return _pOSITION; }
            set
            {
                if (_pOSITION != value)
                {
                    _pOSITION = value;
                    PropertyHasChanged("Position");
                }
            }
        }

        public string Artist
        {
            get { return _aRTIST; }
            set
            {
                if (_aRTIST != value)
                {
                    _aRTIST = value;
                    PropertyHasChanged("Artist");
                }
            }
        }

        public string Title
        {
            get { return _tITLE; }
            set
            {
                if (_tITLE != value)
                {
                    _tITLE = value;
                    PropertyHasChanged("Title");
                }
            }
        }

        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Week", "Week"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Year", "Year"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Position", "Position", 256));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Artist", "Artist", 512));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Title", "Title", 512));
        }

        #endregion

    }
}
