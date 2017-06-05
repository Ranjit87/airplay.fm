using System;
using System.Collections.Generic;
using System.Text;
namespace SQLSoundManagement_BL.BusinessLayer
{
    public class clsEmergenti : BusinessObjectBase
    {
        #region InnerClass
        public enum clsEmergentiFields
        {
            ID,
            Settimana,
            Posizione,
            Artista,
            Titolo,
            Etichetta,
            Anno
        }
        #endregion

        #region Data Members

        int _id;
        string _settimana;
        string _posizione;
        string _artista;
        string _titolo;
        string _etichetta;
        string _anno;

        #endregion

        #region Properties

        public int ID
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    PropertyHasChanged("ID");
                }
            }
        }

        public string Settimana
        {
            get { return _settimana; }
            set
            {
                if (_settimana != value)
                {
                    _settimana = value;
                    PropertyHasChanged("Settimana");
                }
            }
        }

        public string Posizione
        {
            get { return _posizione; }
            set
            {
                if (_posizione != value)
                {
                    _posizione = value;
                    PropertyHasChanged("Posizione");
                }
            }
        }

        public string Artista
        {
            get { return _artista; }
            set
            {
                if (_artista != value)
                {
                    _artista = value;
                    PropertyHasChanged("Artista");
                }
            }
        }

        public string Titolo
        {
            get { return _titolo; }
            set
            {
                if (_titolo != value)
                {
                    _titolo = value;
                    PropertyHasChanged("Titolo");
                }
            }
        }

        public string Etichetta
        {
            get { return _etichetta; }
            set
            {
                if (_etichetta != value)
                {
                    _etichetta = value;
                    PropertyHasChanged("Etichetta");
                }
            }
        }

        public string Anno
        {
            get { return _anno; }
            set
            {
                if (_anno != value)
                {
                    _anno = value;
                    PropertyHasChanged("Anno");
                }
            }
        }


        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Settimana", "Settimana"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Posizione", "Posizione"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Artista", "Artista"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Artista", "Artista", 400));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Titolo", "Titolo"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Titolo", "Titolo", 400));
            //ValidationRules.AddRules(new Validation.ValidateRuleNotNull("Etichetta", "Etichetta"));
        }

        #endregion
    }
}
