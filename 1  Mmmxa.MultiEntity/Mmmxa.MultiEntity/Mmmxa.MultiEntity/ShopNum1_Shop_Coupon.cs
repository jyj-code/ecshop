namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_Shop_Coupon")]
    public class ShopNum1_Shop_Coupon : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _AdressCode;
        private string _AdressName;
        private int? _BrowserCount;
        private string _Content;
        private string _CouponName;
        private DateTime _CreateTime;
        private string _CreateUser;
        private int? _DownloadCount;
        private DateTime _EndTime;
        private System.Guid _Guid;
        private string _ImgPath;
        private int _IsAudit;
        private int _IsDeleted;
        private int? _IsEffective;
        private int _IsHot;
        private int _IsNew;
        private int _IsRecommend;
        private int _IsShow;
        private string _MemLoginID;
        private DateTime? _ModifyTime;
        private string _ModifyUser;
        private string _SaleTitle;
        private string _ShopName;
        private DateTime _StartTime;
        private string _SubstationID;
        private int _Type;
        private int? _UseCount;
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);

        public event PropertyChangedEventHandler PropertyChanged;

        public event PropertyChangingEventHandler PropertyChanging;

        protected virtual void SendPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void SendPropertyChanging()
        {
            if (this.PropertyChanging != null)
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        [Column(Storage="_AdressCode", DbType="NVarChar(50)")]
        public string AdressCode
        {
            get
            {
                return this._AdressCode;
            }
            set
            {
                if (this._AdressCode != value)
                {
                    this.SendPropertyChanging();
                    this._AdressCode = value;
                    this.SendPropertyChanged("AdressCode");
                }
            }
        }

        [Column(Storage="_AdressName", DbType="NVarChar(100)")]
        public string AdressName
        {
            get
            {
                return this._AdressName;
            }
            set
            {
                if (this._AdressName != value)
                {
                    this.SendPropertyChanging();
                    this._AdressName = value;
                    this.SendPropertyChanged("AdressName");
                }
            }
        }

        [Column(Storage="_BrowserCount", DbType="Int")]
        public int? BrowserCount
        {
            get
            {
                return this._BrowserCount;
            }
            set
            {
                if (this._BrowserCount != value)
                {
                    this.SendPropertyChanging();
                    this._BrowserCount = value;
                    this.SendPropertyChanged("BrowserCount");
                }
            }
        }

        [Column(Storage="_Content", DbType="NVarChar(MAX)")]
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
                    this.SendPropertyChanging();
                    this._Content = value;
                    this.SendPropertyChanged("Content");
                }
            }
        }

        [Column(Storage="_CouponName", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
        public string CouponName
        {
            get
            {
                return this._CouponName;
            }
            set
            {
                if (this._CouponName != value)
                {
                    this.SendPropertyChanging();
                    this._CouponName = value;
                    this.SendPropertyChanged("CouponName");
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
                    this.SendPropertyChanging();
                    this._CreateTime = value;
                    this.SendPropertyChanged("CreateTime");
                }
            }
        }

        [Column(Storage="_CreateUser", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string CreateUser
        {
            get
            {
                return this._CreateUser;
            }
            set
            {
                if (this._CreateUser != value)
                {
                    this.SendPropertyChanging();
                    this._CreateUser = value;
                    this.SendPropertyChanged("CreateUser");
                }
            }
        }

        [Column(Storage="_DownloadCount", DbType="Int")]
        public int? DownloadCount
        {
            get
            {
                return this._DownloadCount;
            }
            set
            {
                if (this._DownloadCount != value)
                {
                    this.SendPropertyChanging();
                    this._DownloadCount = value;
                    this.SendPropertyChanged("DownloadCount");
                }
            }
        }

        [Column(Storage="_EndTime", DbType="DateTime NOT NULL")]
        public DateTime EndTime
        {
            get
            {
                return this._EndTime;
            }
            set
            {
                if (this._EndTime != value)
                {
                    this.SendPropertyChanging();
                    this._EndTime = value;
                    this.SendPropertyChanged("EndTime");
                }
            }
        }

        [Column(Storage="_Guid", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
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
                    this.SendPropertyChanging();
                    this._Guid = value;
                    this.SendPropertyChanged("Guid");
                }
            }
        }

        [Column(Storage="_ImgPath", DbType="NVarChar(500)")]
        public string ImgPath
        {
            get
            {
                return this._ImgPath;
            }
            set
            {
                if (this._ImgPath != value)
                {
                    this.SendPropertyChanging();
                    this._ImgPath = value;
                    this.SendPropertyChanged("ImgPath");
                }
            }
        }

        [Column(Storage="_IsAudit", DbType="Int NOT NULL")]
        public int IsAudit
        {
            get
            {
                return this._IsAudit;
            }
            set
            {
                if (this._IsAudit != value)
                {
                    this.SendPropertyChanging();
                    this._IsAudit = value;
                    this.SendPropertyChanged("IsAudit");
                }
            }
        }

        [Column(Storage="_IsDeleted", DbType="Int NOT NULL")]
        public int IsDeleted
        {
            get
            {
                return this._IsDeleted;
            }
            set
            {
                if (this._IsDeleted != value)
                {
                    this.SendPropertyChanging();
                    this._IsDeleted = value;
                    this.SendPropertyChanged("IsDeleted");
                }
            }
        }

        [Column(Storage="_IsEffective", DbType="Int")]
        public int? IsEffective
        {
            get
            {
                return this._IsEffective;
            }
            set
            {
                if (this._IsEffective != value)
                {
                    this.SendPropertyChanging();
                    this._IsEffective = value;
                    this.SendPropertyChanged("IsEffective");
                }
            }
        }

        [Column(Storage="_IsHot", DbType="Int NOT NULL")]
        public int IsHot
        {
            get
            {
                return this._IsHot;
            }
            set
            {
                if (this._IsHot != value)
                {
                    this.SendPropertyChanging();
                    this._IsHot = value;
                    this.SendPropertyChanged("IsHot");
                }
            }
        }

        [Column(Storage="_IsNew", DbType="Int NOT NULL")]
        public int IsNew
        {
            get
            {
                return this._IsNew;
            }
            set
            {
                if (this._IsNew != value)
                {
                    this.SendPropertyChanging();
                    this._IsNew = value;
                    this.SendPropertyChanged("IsNew");
                }
            }
        }

        [Column(Storage="_IsRecommend", DbType="Int NOT NULL")]
        public int IsRecommend
        {
            get
            {
                return this._IsRecommend;
            }
            set
            {
                if (this._IsRecommend != value)
                {
                    this.SendPropertyChanging();
                    this._IsRecommend = value;
                    this.SendPropertyChanged("IsRecommend");
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
                    this.SendPropertyChanging();
                    this._IsShow = value;
                    this.SendPropertyChanged("IsShow");
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
                    this.SendPropertyChanging();
                    this._MemLoginID = value;
                    this.SendPropertyChanged("MemLoginID");
                }
            }
        }

        [Column(Storage="_ModifyTime", DbType="DateTime")]
        public DateTime? ModifyTime
        {
            get
            {
                return this._ModifyTime;
            }
            set
            {
                if (this._ModifyTime != value)
                {
                    this.SendPropertyChanging();
                    this._ModifyTime = value;
                    this.SendPropertyChanged("ModifyTime");
                }
            }
        }

        [Column(Storage="_ModifyUser", DbType="NVarChar(50)")]
        public string ModifyUser
        {
            get
            {
                return this._ModifyUser;
            }
            set
            {
                if (this._ModifyUser != value)
                {
                    this.SendPropertyChanging();
                    this._ModifyUser = value;
                    this.SendPropertyChanged("ModifyUser");
                }
            }
        }

        [Column(Storage="_SaleTitle", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
        public string SaleTitle
        {
            get
            {
                return this._SaleTitle;
            }
            set
            {
                if (this._SaleTitle != value)
                {
                    this.SendPropertyChanging();
                    this._SaleTitle = value;
                    this.SendPropertyChanged("SaleTitle");
                }
            }
        }

        [Column(Storage="_ShopName", DbType="NVarChar(50)")]
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
                    this.SendPropertyChanging();
                    this._ShopName = value;
                    this.SendPropertyChanged("ShopName");
                }
            }
        }

        [Column(Storage="_StartTime", DbType="DateTime NOT NULL")]
        public DateTime StartTime
        {
            get
            {
                return this._StartTime;
            }
            set
            {
                if (this._StartTime != value)
                {
                    this.SendPropertyChanging();
                    this._StartTime = value;
                    this.SendPropertyChanged("StartTime");
                }
            }
        }

        [Column(Storage="_SubstationID", DbType="NVarChar(100)")]
        public string SubstationID
        {
            get
            {
                return this._SubstationID;
            }
            set
            {
                if (this._SubstationID != value)
                {
                    this.SendPropertyChanging();
                    this._SubstationID = value;
                    this.SendPropertyChanged("SubstationID");
                }
            }
        }

        [Column(Storage="_Type", DbType="Int NOT NULL")]
        public int Type
        {
            get
            {
                return this._Type;
            }
            set
            {
                if (this._Type != value)
                {
                    this.SendPropertyChanging();
                    this._Type = value;
                    this.SendPropertyChanged("Type");
                }
            }
        }

        [Column(Storage="_UseCount", DbType="Int")]
        public int? UseCount
        {
            get
            {
                return this._UseCount;
            }
            set
            {
                if (this._UseCount != value)
                {
                    this.SendPropertyChanging();
                    this._UseCount = value;
                    this.SendPropertyChanged("UseCount");
                }
            }
        }
    }
}

