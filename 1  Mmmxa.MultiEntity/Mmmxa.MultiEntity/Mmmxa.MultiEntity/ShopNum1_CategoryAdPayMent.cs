namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_CategoryAdPayMent")]
    public class ShopNum1_CategoryAdPayMent
    {
        private string _AdvertisementContent;
        private string _AdvertisementID;
        private string _AdvertisementLike;
        private string _AdvertisementPic;
        private DateTime _BuyTime;
        private string _CategoryAdID;
        private string _CategoryCode;
        private string _CategoryName;
        private string _CategoryType;
        private DateTime _EndTime;
        private string _FailCause;
        private int _ID;
        private int _IsAudit;
        private int _IsEffective;
        private int _IsPayMent;
        private string _MemLoginID;
        private string _PayMentName;
        private DateTime? _PayMentTime;
        private string _PayMentType;
        private decimal _ShowPayMentPrice;
        private DateTime _StartTime;
        private string _TradeID;

        [Column(Storage="_AdvertisementContent", DbType="NVarChar(250)")]
        public string AdvertisementContent
        {
            get
            {
                return this._AdvertisementContent;
            }
            set
            {
                if (this._AdvertisementContent != value)
                {
                    this._AdvertisementContent = value;
                }
            }
        }

        [Column(Storage="_AdvertisementID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string AdvertisementID
        {
            get
            {
                return this._AdvertisementID;
            }
            set
            {
                if (this._AdvertisementID != value)
                {
                    this._AdvertisementID = value;
                }
            }
        }

        [Column(Storage="_AdvertisementLike", DbType="NVarChar(100)")]
        public string AdvertisementLike
        {
            get
            {
                return this._AdvertisementLike;
            }
            set
            {
                if (this._AdvertisementLike != value)
                {
                    this._AdvertisementLike = value;
                }
            }
        }

        [Column(Storage="_AdvertisementPic", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
        public string AdvertisementPic
        {
            get
            {
                return this._AdvertisementPic;
            }
            set
            {
                if (this._AdvertisementPic != value)
                {
                    this._AdvertisementPic = value;
                }
            }
        }

        [Column(Storage="_BuyTime", DbType="DateTime NOT NULL")]
        public DateTime BuyTime
        {
            get
            {
                return this._BuyTime;
            }
            set
            {
                if (this._BuyTime != value)
                {
                    this._BuyTime = value;
                }
            }
        }

        [Column(Storage="_CategoryAdID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string CategoryAdID
        {
            get
            {
                return this._CategoryAdID;
            }
            set
            {
                if (this._CategoryAdID != value)
                {
                    this._CategoryAdID = value;
                }
            }
        }

        [Column(Storage="_CategoryCode", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
        public string CategoryCode
        {
            get
            {
                return this._CategoryCode;
            }
            set
            {
                if (this._CategoryCode != value)
                {
                    this._CategoryCode = value;
                }
            }
        }

        [Column(Storage="_CategoryName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string CategoryName
        {
            get
            {
                return this._CategoryName;
            }
            set
            {
                if (this._CategoryName != value)
                {
                    this._CategoryName = value;
                }
            }
        }

        [Column(Storage="_CategoryType", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string CategoryType
        {
            get
            {
                return this._CategoryType;
            }
            set
            {
                if (this._CategoryType != value)
                {
                    this._CategoryType = value;
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
                    this._EndTime = value;
                }
            }
        }

        [Column(Storage="_FailCause", DbType="NVarChar(250)")]
        public string FailCause
        {
            get
            {
                return this._FailCause;
            }
            set
            {
                if (this._FailCause != value)
                {
                    this._FailCause = value;
                }
            }
        }

        [Column(Storage="_ID", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if (this._ID != value)
                {
                    this._ID = value;
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
                    this._IsAudit = value;
                }
            }
        }

        [Column(Storage="_IsEffective", DbType="Int NOT NULL")]
        public int IsEffective
        {
            get
            {
                return this._IsEffective;
            }
            set
            {
                if (this._IsEffective != value)
                {
                    this._IsEffective = value;
                }
            }
        }

        [Column(Storage="_IsPayMent", DbType="Int NOT NULL")]
        public int IsPayMent
        {
            get
            {
                return this._IsPayMent;
            }
            set
            {
                if (this._IsPayMent != value)
                {
                    this._IsPayMent = value;
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

        [Column(Storage="_PayMentName", DbType="NVarChar(50)")]
        public string PayMentName
        {
            get
            {
                return this._PayMentName;
            }
            set
            {
                if (this._PayMentName != value)
                {
                    this._PayMentName = value;
                }
            }
        }

        [Column(Storage="_PayMentTime", DbType="DateTime")]
        public DateTime? PayMentTime
        {
            get
            {
                return this._PayMentTime;
            }
            set
            {
                if (this._PayMentTime != value)
                {
                    this._PayMentTime = value;
                }
            }
        }

        [Column(Storage="_PayMentType", DbType="NVarChar(50)")]
        public string PayMentType
        {
            get
            {
                return this._PayMentType;
            }
            set
            {
                if (this._PayMentType != value)
                {
                    this._PayMentType = value;
                }
            }
        }

        [Column(Storage="_ShowPayMentPrice", DbType="Decimal(18,2) NOT NULL")]
        public decimal ShowPayMentPrice
        {
            get
            {
                return this._ShowPayMentPrice;
            }
            set
            {
                if (this._ShowPayMentPrice != value)
                {
                    this._ShowPayMentPrice = value;
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
                    this._StartTime = value;
                }
            }
        }

        [Column(Storage="_TradeID", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
        public string TradeID
        {
            get
            {
                return this._TradeID;
            }
            set
            {
                if (this._TradeID != value)
                {
                    this._TradeID = value;
                }
            }
        }
    }
}

