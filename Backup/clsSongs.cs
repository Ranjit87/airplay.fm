using System;
using System.Collections.Generic;
using System.Text;
namespace SQLSoundManagement_BL.BusinessLayer
{
	public class clsSongs: BusinessObjectBase
	{

		#region InnerClass
		public enum clsSongsFields
		{
			IdSong,
			GENRE,
			LANGUAGE,
			TVSHOW,
			ARTIST,
			TITLE,
			VERSION,
			LABEL,
			FILENAME,
			Spotify,
			CompanyId,
			LabelId,
			RadioDate,
			IncludeInFirstPlay,
			IncludeInNewTalent,
			PromotionId,
			SingRing,
			FirstPlayDate,
			ParentSongId,
			Lyric
		}
		#endregion

		#region Data Members

			int _idSong;
			string _gENRE;
			string _lANGUAGE;
			string _tVSHOW;
			string _aRTIST;
			string _tITLE;
			string _vERSION;
			string _lABEL;
			string _fILENAME;
			string _spotify;
			int? _companyId;
			int? _labelId;
			DateTime? _radioDate;
			bool _includeInFirstPlay;
			bool _includeInNewTalent;
			int? _promotionId;
			long? _singRing;
			DateTime? _firstPlayDate;
			int? _parentSongId;
			string _lyric;

		#endregion

		#region Properties

		public int  IdSong
		{
			 get { return _idSong; }
			 set
			 {
				 if (_idSong != value)
				 {
					_idSong = value;
					 PropertyHasChanged("IdSong");
				 }
			 }
		}

		public string  GENRE
		{
			 get { return _gENRE; }
			 set
			 {
				 if (_gENRE != value)
				 {
					_gENRE = value;
					 PropertyHasChanged("GENRE");
				 }
			 }
		}

		public string  LANGUAGE
		{
			 get { return _lANGUAGE; }
			 set
			 {
				 if (_lANGUAGE != value)
				 {
					_lANGUAGE = value;
					 PropertyHasChanged("LANGUAGE");
				 }
			 }
		}

		public string  TVSHOW
		{
			 get { return _tVSHOW; }
			 set
			 {
				 if (_tVSHOW != value)
				 {
					_tVSHOW = value;
					 PropertyHasChanged("TVSHOW");
				 }
			 }
		}

		public string  ARTIST
		{
			 get { return _aRTIST; }
			 set
			 {
				 if (_aRTIST != value)
				 {
					_aRTIST = value;
					 PropertyHasChanged("ARTIST");
				 }
			 }
		}

		public string  TITLE
		{
			 get { return _tITLE; }
			 set
			 {
				 if (_tITLE != value)
				 {
					_tITLE = value;
					 PropertyHasChanged("TITLE");
				 }
			 }
		}

		public string  VERSION
		{
			 get { return _vERSION; }
			 set
			 {
				 if (_vERSION != value)
				 {
					_vERSION = value;
					 PropertyHasChanged("VERSION");
				 }
			 }
		}

		public string  LABEL
		{
			 get { return _lABEL; }
			 set
			 {
				 if (_lABEL != value)
				 {
					_lABEL = value;
					 PropertyHasChanged("LABEL");
				 }
			 }
		}

		public string  FILENAME
		{
			 get { return _fILENAME; }
			 set
			 {
				 if (_fILENAME != value)
				 {
					_fILENAME = value;
					 PropertyHasChanged("FILENAME");
				 }
			 }
		}

		public string  Spotify
		{
			 get { return _spotify; }
			 set
			 {
				 if (_spotify != value)
				 {
					_spotify = value;
					 PropertyHasChanged("Spotify");
				 }
			 }
		}

		public int?  CompanyId
		{
			 get { return _companyId; }
			 set
			 {
				 if (_companyId != value)
				 {
					_companyId = value;
					 PropertyHasChanged("CompanyId");
				 }
			 }
		}

		public int?  LabelId
		{
			 get { return _labelId; }
			 set
			 {
				 if (_labelId != value)
				 {
					_labelId = value;
					 PropertyHasChanged("LabelId");
				 }
			 }
		}

		public DateTime?  RadioDate
		{
			 get { return _radioDate; }
			 set
			 {
				 if (_radioDate != value)
				 {
					_radioDate = value;
					 PropertyHasChanged("RadioDate");
				 }
			 }
		}

		public bool  IncludeInFirstPlay
		{
			 get { return _includeInFirstPlay; }
			 set
			 {
				 if (_includeInFirstPlay != value)
				 {
					_includeInFirstPlay = value;
					 PropertyHasChanged("IncludeInFirstPlay");
				 }
			 }
		}

		public bool  IncludeInNewTalent
		{
			 get { return _includeInNewTalent; }
			 set
			 {
				 if (_includeInNewTalent != value)
				 {
					_includeInNewTalent = value;
					 PropertyHasChanged("IncludeInNewTalent");
				 }
			 }
		}

		public int?  PromotionId
		{
			 get { return _promotionId; }
			 set
			 {
				 if (_promotionId != value)
				 {
					_promotionId = value;
					 PropertyHasChanged("PromotionId");
				 }
			 }
		}

		public long?  SingRing
		{
			 get { return _singRing; }
			 set
			 {
				 if (_singRing != value)
				 {
					_singRing = value;
					 PropertyHasChanged("SingRing");
				 }
			 }
		}

		public DateTime?  FirstPlayDate
		{
			 get { return _firstPlayDate; }
			 set
			 {
				 if (_firstPlayDate != value)
				 {
					_firstPlayDate = value;
					 PropertyHasChanged("FirstPlayDate");
				 }
			 }
		}

		public int?  ParentSongId
		{
			 get { return _parentSongId; }
			 set
			 {
				 if (_parentSongId != value)
				 {
					_parentSongId = value;
					 PropertyHasChanged("ParentSongId");
				 }
			 }
		}

		public string  Lyric
		{
			 get { return _lyric; }
			 set
			 {
				 if (_lyric != value)
				 {
					_lyric = value;
					 PropertyHasChanged("Lyric");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("IdSong", "IdSong"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("GENRE", "GENRE",400));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("LANGUAGE", "LANGUAGE",400));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TVSHOW", "TVSHOW",400));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("ARTIST", "ARTIST",400));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TITLE", "TITLE",400));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("VERSION", "VERSION",400));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("LABEL", "LABEL",400));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("FILENAME", "FILENAME",400));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Spotify", "Spotify",100));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("IncludeInFirstPlay", "IncludeInFirstPlay"));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("IncludeInNewTalent", "IncludeInNewTalent"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("Lyric", "Lyric",2147483647));
		}

		#endregion

	}
}
