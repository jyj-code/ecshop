namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_ZtcGoods")]
    public class ShopNum1_ZtcGoods : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private DateTime? _CreateTime;
        private string _CreateUser;
        private int _ID;
        private int? _IsDeleted;
        private string _MemberID;
        private DateTime? _ModifyTime;
        private string _ModifyUser;
        private Guid? _ProductGuid;
        private decimal? _ProductPrice;
        private int? _SellCount;
        private decimal? _SellPrice;
        private string _ShopName;
        private DateTime? _StartTime;
        private byte? _State;
        private string _SubstationID;
        private decimal? _Ztc_Money;
        private string _ZtcImg;
        private string _ZtcName;
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
                    this.SendPropertyChanging();
                    this._CreateTime = value;
                    this.SendPropertyChanged("CreateTime");
                }
            }
        }

        [Column(Storage="_CreateUser", DbType="NVarChar(50)")]
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

        [Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
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
                    this.SendPropertyChanging();
                    this._ID = value;
                    this.SendPropertyChanged("ID");
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
                    this.SendPropertyChanging();
                    this._IsDeleted = value;
                    this.SendPropertyChanged("IsDeleted");
                }
            }
        }

        [Column(Storage="_MemberID", DbType="NVarChar(50)")]
        public string MemberID
        {
            get
            {
                return this._MemberID;
            }
            set
            {
                if (this._MemberID != value)
                {
                    this.SendPropertyChanging();
                    this._MemberID = value;
                    this.SendPropertyChanged("MemberID");
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

        [Column(Storage="_ProductGuid", DbType="UniqueIdentifier")]
        public Guid? ProductGuid
        {
            get
            {
                return this._ProductGuid;
            }
            set
            {
                if (this._ProductGuid != value)
                {
                    this.SendPropertyChanging();
                    this._ProductGuid = value;
                    this.SendPropertyChanged("ProductGuid");
                }
            }
        }

        [Column(Storage="_ProductPrice", DbType="Decimal(18,2)")]
        public decimal? ProductPrice
        {
            get
            {
                return this._ProductPrice;
            }
            set
            {
                decimal? nullable = this._ProductPrice;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._ProductPrice = value;
                    this.SendPropertyChanged("ProductPrice");
                }
            }
        }

        [Column(Storage="_SellCount", DbType="Int")]
        public int? SellCount
        {
            get
            {
                return this._SellCount;
            }
            set
            {
                if (this._SellCount != value)
                {
                    this.SendPropertyChanging();
                    this._SellCount = value;
                    this.SendPropertyChanged("SellCount");
                }
            }
        }

        [Column(Storage="_SellPrice", DbType="Decimal(18,2)")]
        public decimal? SellPrice
        {
            get
            {
                return this._SellPrice;
            }
            set
            {
                decimal? nullable = this._SellPrice;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._SellPrice = value;
                    this.SendPropertyChanged("SellPrice");
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
                    this.SendPropertyChanging();
                    this._ShopName = value;
                    this.SendPropertyChanged("ShopName");
                }
            }
        }

        [Column(Storage="_StartTime", DbType="DateTime")]
        public DateTime? StartTime
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

        [Column(Storage="_State", DbType="TinyInt")]
        public byte? State
        {
            get
            {
                return this._State;
            }
            set
            {
                if (this._State != value)
                {
                    this.SendPropertyChanging();
                    this._State = value;
                    this.SendPropertyChanged("State");
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

        [Column(Storage="_Ztc_Money", DbType="Decimal(18,2)")]
        public decimal? Ztc_Money
        {
            get
            {
                return this._Ztc_Money;
            }
            set
            {
                decimal? nullable = this._Ztc_Money;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._Ztc_Money = value;
                    this.SendPropertyChanged("Ztc_Money");
                }
            }
        }

        [Column(Storage="_ZtcImg", DbType="NVarChar(250)")]
        public string ZtcImg
        {
            get
            {
                return this._ZtcImg;
            }
            set
            {
                if (this._ZtcImg != value)
                {
                    this.SendPropertyChanging();
                    this._ZtcImg = value;
                    this.SendPropertyChanged("ZtcImg");
                }
            }
        }

        [Column(Storage="_ZtcName", DbType="NVarChar(100)")]
        public string ZtcName
        {
            get
            {
                return this._ZtcName;
            }
            set
            {
                if (this._ZtcName != value)
                {
                    this.SendPropertyChanging();
                    this._ZtcName = value;
                    this.SendPropertyChanged("ZtcName");
                }
            }
        }
    }
}

