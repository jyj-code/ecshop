namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.PageInfo")]
    public class PageInfo
    {
        private string _divid;
        private string _FileName;
        private string _Guid;
        private string _PageName;
        private string _PageNote;

        [Column(Storage="_divid", CanBeNull=false)]
        public string divid
        {
            get
            {
                return this._divid;
            }
            set
            {
                if (this._divid != value)
                {
                    this._divid = value;
                }
            }
        }

        [Column(Storage="_FileName", DbType="NVarChar(50)")]
        public string FileName
        {
            get
            {
                return this._FileName;
            }
            set
            {
                if (this._FileName != value)
                {
                    this._FileName = value;
                }
            }
        }

        [Column(Storage="_Guid", DbType="NVarChar(50)")]
        public string Guid
        {
            get
            {
                return this._Guid;
            }
            set
            {
                if (this._Guid != value)
                {
                    this._Guid = value;
                }
            }
        }

        [Column(Storage="_PageName", DbType="NVarChar(50)")]
        public string PageName
        {
            get
            {
                return this._PageName;
            }
            set
            {
                if (this._PageName != value)
                {
                    this._PageName = value;
                }
            }
        }

        [Column(Storage="_PageNote", DbType="NVarChar(250)")]
        public string PageNote
        {
            get
            {
                return this._PageNote;
            }
            set
            {
                if (this._PageNote != value)
                {
                    this._PageNote = value;
                }
            }
        }
    }
}

