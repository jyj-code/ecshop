namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.PageAdID")]
    public class PageAdID
    {
        private string _Content;
        private string _DivID;
        private string _FileName;
        private string _Guid;
        private string _Height;
        private string _ImgSrc;
        private string _PageName;
        private string _Width;

        [Column(Storage="_Content", DbType="varchar(2000)", CanBeNull=false)]
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

        [Column(Storage="_ImgSrc", DbType="varchar(200)", CanBeNull=false)]
        public string ImgSrc
        {
            get
            {
                return this._ImgSrc;
            }
            set
            {
                if (this._ImgSrc != value)
                {
                    this._ImgSrc = value;
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

