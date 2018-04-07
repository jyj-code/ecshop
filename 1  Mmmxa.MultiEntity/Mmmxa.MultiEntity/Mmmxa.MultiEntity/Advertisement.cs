namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.Advertisement")]
    public class Advertisement
    {
        private string _Content;
        private string _DivID;
        private string _Explain;
        private string _FileName;
        private string _Guid;
        private string _Height;
        private string _Href;
        private string _PageName;
        private string _Type;
        private string _Width;

        [Column(Storage="_Content", DbType="NVarChar(250)")]
        public string Content
        {
            get
            {
                return this._Content;
            }
            set
            {
                if (this._Content != value)
                {
                    this._Content = value;
                }
            }
        }

        [Column(Storage="_DivID", DbType="NVarChar(150)")]
        public string DivID
        {
            get
            {
                return this._DivID;
            }
            set
            {
                if (this._DivID != value)
                {
                    this._DivID = value;
                }
            }
        }

        [Column(Storage="_Explain", DbType="NVarChar(50)")]
        public string Explain
        {
            get
            {
                return this._Explain;
            }
            set
            {
                if (this._Explain != value)
                {
                    this._Explain = value;
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

        [Column(Storage="_Height", DbType="NVarChar(50)")]
        public string Height
        {
            get
            {
                return this._Height;
            }
            set
            {
                if (this._Height != value)
                {
                    this._Height = value;
                }
            }
        }

        [Column(Storage="_Href", DbType="NVarChar(250)")]
        public string Href
        {
            get
            {
                return this._Href;
            }
            set
            {
                if (this._Href != value)
                {
                    this._Href = value;
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

        [Column(Storage="_Type", DbType="NVarChar(50)")]
        public string Type
        {
            get
            {
                return this._Type;
            }
            set
            {
                if (this._Type != value)
                {
                    this._Type = value;
                }
            }
        }

        [Column(Storage="_Width", DbType="NVarChar(50)")]
        public string Width
        {
            get
            {
                return this._Width;
            }
            set
            {
                if (this._Width != value)
                {
                    this._Width = value;
                }
            }
        }
    }
}

