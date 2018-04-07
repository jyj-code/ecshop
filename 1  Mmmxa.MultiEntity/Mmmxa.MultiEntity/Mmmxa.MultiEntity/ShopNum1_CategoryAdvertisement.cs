namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_CategoryAdvertisement")]
    public class ShopNum1_CategoryAdvertisement
    {
        private string _AdDefaultLike;
        private string _AdIntroduce;
        private string _Adlocation;
        private string _AdvertisementDPic;
        private int? _Advertisementflow;
        private string _AdvertisementLike;
        private string _AdvertisementName;
        private string _AdvertisementNPic;
        private decimal _AdvertisementPrice;
        private int _CategoryAdID;
        private string _CategoryCode;
        private string _CategoryName;
        private string _CategoryType;
        private DateTime? _CreateTime;
        private int? _Height;
        private int _ID;
        private int _IsBuy;
        private int _IsEnabled;
        private int _IsShow;
        private int? _Width;

        [Column(Storage="_AdDefaultLike", DbType="NVarChar(250)")]
        public string AdDefaultLike
        {
            get
            {
                return this._AdDefaultLike;
            }
            set
            {
                if (this._AdDefaultLike != value)
                {
                    this._AdDefaultLike = value;
                }
            }
        }

        [Column(Storage="_AdIntroduce", DbType="NVarChar(250)")]
        public string AdIntroduce
        {
            get
            {
                return this._AdIntroduce;
            }
            set
            {
                if (this._AdIntroduce != value)
                {
                    this._AdIntroduce = value;
                }
            }
        }

        [Column(Storage="_Adlocation", DbType="NVarChar(250)")]
        public string Adlocation
        {
            get
            {
                return this._Adlocation;
            }
            set
            {
                if (this._Adlocation != value)
                {
                    this._Adlocation = value;
                }
            }
        }

        [Column(Storage="_AdvertisementDPic", DbType="NVarChar(250)")]
        public string AdvertisementDPic
        {
            get
            {
                return this._AdvertisementDPic;
            }
            set
            {
                if (this._AdvertisementDPic != value)
                {
                    this._AdvertisementDPic = value;
                }
            }
        }

        [Column(Storage="_Advertisementflow", DbType="Int")]
        public int? Advertisementflow
        {
            get
            {
                return this._Advertisementflow;
            }
            set
            {
                if (this._Advertisementflow != value)
                {
                    this._Advertisementflow = value;
                }
            }
        }

        [Column(Storage="_AdvertisementLike", DbType="NVarChar(250)")]
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

        [Column(Storage="_AdvertisementName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string AdvertisementName
        {
            get
            {
                return this._AdvertisementName;
            }
            set
            {
                if (this._AdvertisementName != value)
                {
                    this._AdvertisementName = value;
                }
            }
        }

        [Column(Storage="_AdvertisementNPic", DbType="NVarChar(250)")]
        public string AdvertisementNPic
        {
            get
            {
                return this._AdvertisementNPic;
            }
            set
            {
                if (this._AdvertisementNPic != value)
                {
                    this._AdvertisementNPic = value;
                }
            }
        }

        [Column(Storage="_AdvertisementPrice", DbType="Decimal(18,2) NOT NULL")]
        public decimal AdvertisementPrice
        {
            get
            {
                return this._AdvertisementPrice;
            }
            set
            {
                if (this._AdvertisementPrice != value)
                {
                    this._AdvertisementPrice = value;
                }
            }
        }

        [Column(Storage="_CategoryAdID", DbType="Int NOT NULL")]
        public int CategoryAdID
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

        [Column(Storage="_CreateTime", DbType="DateTime")]
        public DateTime? CreateTime
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

        [Column(Storage="_Height", DbType="Int")]
        public int? Height
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

        [Column(Storage="_IsBuy", DbType="Int NOT NULL")]
        public int IsBuy
        {
            get
            {
                return this._IsBuy;
            }
            set
            {
                if (this._IsBuy != value)
                {
                    this._IsBuy = value;
                }
            }
        }

        [Column(Storage="_IsEnabled", DbType="Int NOT NULL")]
        public int IsEnabled
        {
            get
            {
                return this._IsEnabled;
            }
            set
            {
                if (this._IsEnabled != value)
                {
                    this._IsEnabled = value;
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

        [Column(Storage="_Width", DbType="Int")]
        public int? Width
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

