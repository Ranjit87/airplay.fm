using System;
using System.Collections.Generic;
using System.Text;
namespace SQLSoundManagement_BL.BusinessLayer
{
    public class clsAudienceFigure : BusinessObjectBase
    {
        #region InnerClass
        public enum clsAudienceFigureFields
        {
            RadioId,
            Interval,
            Audience,
            RadioName,
            Semester,
            TotalAudience
        }
        #endregion

        #region Data Members

        int _rADIOID;
        int _iNTERVAL;
        decimal _aUDIENCE;
        string _rADIONAME;
        string _sEMESTER;
        string _tOTALAUDIENCE;

        #endregion

        #region Properties

        public int RadioId
        {
            get { return _rADIOID; }
            set
            {
                if (_rADIOID != value)
                {
                    _rADIOID = value;
                    PropertyHasChanged("RadioId");
                }
            }
        }

        public int Interval
        {
            get { return _iNTERVAL; }
            set
            {
                if (_iNTERVAL != value)
                {
                    _iNTERVAL = value;
                    PropertyHasChanged("Interval");
                }
            }
        }

        public decimal Audience
        {
            get { return _aUDIENCE; }
            set
            {
                if (_aUDIENCE != value)
                {
                    _aUDIENCE = value;
                    PropertyHasChanged("Audience");
                }
            }
        }

        public string RadioName
        {
            get { return _rADIONAME; }
            set
            {
                if (_rADIONAME != value)
                {
                    _rADIONAME = value;
                    PropertyHasChanged("RadioName");
                }
            }
        }

        public string Semester
        {
            get { return _sEMESTER; }
            set
            {
                if (_sEMESTER != value)
                {
                    _sEMESTER = value;
                    PropertyHasChanged("Semester");
                }
            }
        }

        public string TotalAudience
        {
            get { return _tOTALAUDIENCE; }
            set
            {
                if (_tOTALAUDIENCE != value)
                {
                    _tOTALAUDIENCE = value;
                    PropertyHasChanged("TotalAudience");
                }
            }
        }

        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("RadioId", "RadioId"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Interval", "Interval"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Audience", "Audience"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("RadioName", "RadioName", 400));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Semester", "Semester", 400));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TotalAudience", "TotalAudience", 400));
        }

        #endregion

    }
}
