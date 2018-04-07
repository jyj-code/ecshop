namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_Shop_Link")]
    public class ShopNum1_Shop_Link
    {
        private DateTime _CreateTime;
        private System.Guid _Guid;
        private int _IsShow;
        private string _MemLoginID;
        private DateTime _ModifyTime;
        private string _Note;
        private string _ShopMemLoginID;
        private string _ShopName;
        private string _ShopUrl;

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

        [Column(Storage="_ModifyTime", DbType="DateTime NOT NULL")]
        public DateTime ModifyTime
        {
            get
            {
                return this._ModifyTime;
            }
            set
            {
                if (this._ModifyTime != value)
                {
                    this._ModifyTime = value;
                }
            }
        }

        [Column(Storage="_Note", DbType="NVarChar(MAX)")]
        public string Note
        {
            get
            {
                return this._Note;
            }
            set
            {
                if (this._Note != value)
                {
                    this._Note = value;
                }
            }
        }

        [Column(Storage="_ShopMemLoginID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ShopMemLoginID
        {
            get
            {
                return this._ShopMemLoginID;
            }
            set
            {
                if (this._ShopMemLoginID != value)
                {
                    this._ShopMemLoginID = value;
                }
            }
        }

        [Column(Storage="_ShopName", DbType="NVarChar(100)")]
        public string ShopName
        {
            get
            {
                return this._ShopName;
            }
            set
            {
                if (this._ShopName != value)
                {
                    this._ShopName = value;
                }
            }
        }

        [Column(Storage="_ShopUrl", DbType="NVarChar(50)")]
        public string ShopUrl
        {
            get
            {
                return this._ShopUrl;
            }
            set
            {
                if (this._ShopUrl != value)
                {
                    this._ShopUrl = value;
                }
            }
        }
    }
}

