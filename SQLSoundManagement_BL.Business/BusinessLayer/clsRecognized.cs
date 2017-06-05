using System;
using System.Collections.Generic;
using System.Text;

namespace SQLSoundManagement_BL.BusinessLayer.BusinessLayer
{
    public class clsRecognized : BusinessObjectBase
    {
        #region InnerClass
        public enum clsRecognizedFields
        {
            ID,
            FileName,
            IdRadio,
            Hour,
            FingerprintingTime,
            FingerprintingDetails

        }
        #endregion

        #region Data Members

        int _iD;
        string _fILENAME;
        int _iDRADIO;
        int _hour;
        DateTime _fingerprintingTime;
        string _fingerprintingDetails;

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

        public string FileName
        {
            get { return _fILENAME; }
            set
            {
                if (_fILENAME != value)
                {
                    _fILENAME = value;
                    PropertyHasChanged("FileName");
                }
            }
        }

        public int IdRadio
        {
            get { return _iDRADIO; }
            set
            {
                if (_iDRADIO != value)
                {
                    _iDRADIO = value;
                    PropertyHasChanged("IdRadio");
                }
            }
        }

        public int Hour
        {
            get { return _hour; }
            set
            {
                if (_hour != value)
                {
                    _hour = value;
                    PropertyHasChanged("Hour");
                }
            }
        }

        public DateTime FingerprintingTime
        {
            get { return _fingerprintingTime; }
            set
            {
                if (_fingerprintingTime != value)
                {
                    _fingerprintingTime = value;
                    PropertyHasChanged("FingerprintingTime");
                }
            }
        }

        public string FingerprintingDetails
        {
            get { return _fingerprintingDetails; }
            set
            {
                if (_fingerprintingDetails != value)
                {
                    _fingerprintingDetails = value;
                    PropertyHasChanged("FingerprintingDetails");
                }
            }
        }

        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("FileName", "FileName", 512));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("IdRadio", "IdRadio"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Hour", "Hour"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("FingerprintingTime", "FingerprintingTime"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("FingerprintingDetails", "FingerprintingDetails", 100));
        }

        #endregion
    }
}
