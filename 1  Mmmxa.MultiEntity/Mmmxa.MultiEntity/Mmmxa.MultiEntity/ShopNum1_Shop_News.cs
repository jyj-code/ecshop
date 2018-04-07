namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_Shop_News")]
    public class ShopNum1_Shop_News
    {
        private int _ClickCount;
        private string _Content;
        private DateTime _CreateTime;
        private string _Description;
        private System.Guid _Guid;
        private int? _IsAudit;
        private int? _IsDeleted;
        private int _IsShow;
        private string _Keywords;
        private string _MemLoginID;
        private string _NewsCategoryGuid;
        private int _OrderID;
        private string _SEOTitle;
        private string _Title;

        [Column(Storage="_ClickCount", DbType="Int NOT NULL")]
        public int ClickCount
        {
            get
            {
                return this._ClickCount;
            }
            set
            {
                if (this._ClickCount != value)
                {
                    this._ClickCount = value;
                }
            }
        }

        [Column(Storage="_Content", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
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

        [Column(Storage="_CreateTime", DbType="DateTime NOT NULL")]
        public DateTime CreateTime
        {
            get
            {
                return this._CreateTime;
            }
            set
            {
                if (this._CreateTime != value)
                {
                    this._CreateTime = value;
                }
            }
        }

        [Column(Storage="_Description", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                if (this._Description != value)
                {
                    this._Description = value;
                }
            }
        }

        [Column(Storage="_Guid", DbType="UniqueIdentifier NOT NULL")]
        public System.Guid Guid
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

        [Column(Storage="_IsAudit", DbType="Int")]
        public int? IsAudit
        {
            get
            {
                return this._IsAudit;
            }
            set
            {
                if (this._IsAudit != value)
                {
                    this._IsAudit = value;
                }
            }
        }

        [Column(Storage="_IsDeleted", DbType="Int")]
        public int? IsDeleted
        {
            get
            {
                return this._IsDeleted;
            }
            set
            {
                if (this._IsDeleted != value)
                {
                    this._IsDeleted = value;
                }
            }
        }

        [Column(Storage="_IsShow", DbType="Int NOT NULL")]
        public int IsShow
        {
            get
            {
                return this._IsShow;
            }
            set
            {
                if (this._IsShow != value)
                {
                    this._IsShow = value;
                }
            }
        }

        [Column(Storage="_Keywords", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
        public string Keywords
        {
            get
            {
                return this._Keywords;
            }
            set
            {
                if (this._Keywords != value)
                {
                    this._Keywords = value;
                }
            }
        }

        [Column(Storage="_MemLoginID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string MemLoginID
        {
            get
            {
                return this._MemLoginID;
            }
            set
            {
                if (this._MemLoginID != value)
                {
                    this._MemLoginID = value;
                }
            }
        }

        [Column(Storage="_NewsCategoryGuid", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string NewsCategoryGuid
        {
            get
            {
                return this._NewsCategoryGuid;
            }
            set
            {
                if (this._NewsCategoryGuid != value)
                {
                    this._NewsCategoryGuid = value;
                }
            }
        }

        [Column(Storage="_OrderID", DbType="Int NOT NULL")]
        public int OrderID
        {
            get
            {
                return this._OrderID;
            }
            set
            {
                if (this._OrderID != value)
                {
                    this._OrderID = value;
                }
            }
        }

        [Column(Storage="_SEOTitle", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
        public string SEOTitle
        {
            get
            {
                return this._SEOTitle;
            }
            set
            {
                if (this._SEOTitle != value)
                {
                    this._SEOTitle = value;
                }
            }
        }

        [Column(Storage="_Title", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                if (this._Title != value)
                {
                    this._Title = value;
                }
            }
        }
    }
}

