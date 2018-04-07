namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_ShopRank")]
    public class ShopNum1_ShopRank : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private DateTime? _CreateTime;
        private string _CreateUser;
        private System.Guid _Guid;
        private int _IsDefault;
        private int _IsDeleted;
        private int? _IsOverrideDomain;
        private int _IsSetSEO;
        private int? _MaxArticleCout;
        private int? _MaxFileCount;
        private int? _MaxPanicBuyCount;
        private int? _MaxProductCount;
        private int? _MaxSpellBuyCount;
        private int? _MaxVedioCount;
        private DateTime? _ModifyTime;
        private string _ModifyUser;
        private string _Name;
        private string _Pic;
        private decimal? _price;
        private int? _RankValue;
        private string _shopTemplate;
        private DateTime? _StartTime;
        private string _validityDate;
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

        [Column(Storage="_IsDefault", DbType="Int NOT NULL")]
        public int IsDefault
        {
            get
            {
                return this._IsDefault;
            }
            set
            {
                if (this._IsDefault != value)
                {
                    this.SendPropertyChanging();
                    this._IsDefault = value;
                    this.SendPropertyChanged("IsDefault");
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

        [Column(Storage="_IsOverrideDomain", DbType="Int")]
        public int? IsOverrideDomain
        {
            get
            {
                return this._IsOverrideDomain;
            }
            set
            {
                if (this._IsOverrideDomain != value)
                {
                    this.SendPropertyChanging();
                    this._IsOverrideDomain = value;
                    this.SendPropertyChanged("IsOverrideDomain");
                }
            }
        }

        [Column(Storage="_IsSetSEO", DbType="Int NOT NULL")]
        public int IsSetSEO
        {
            get
            {
                return this._IsSetSEO;
            }
            set
            {
                if (this._IsSetSEO != value)
                {
                    this.SendPropertyChanging();
                    this._IsSetSEO = value;
                    this.SendPropertyChanged("IsSetSEO");
                }
            }
        }

        [Column(Storage="_MaxArticleCout", DbType="Int")]
        public int? MaxArticleCout
        {
            get
            {
                return this._MaxArticleCout;
            }
            set
            {
                if (this._MaxArticleCout != value)
                {
                    this.SendPropertyChanging();
                    this._MaxArticleCout = value;
                    this.SendPropertyChanged("MaxArticleCout");
                }
            }
        }

        [Column(Storage="_MaxFileCount", DbType="Int")]
        public int? MaxFileCount
        {
            get
            {
                return this._MaxFileCount;
            }
            set
            {
                if (this._MaxFileCount != value)
                {
                    this.SendPropertyChanging();
                    this._MaxFileCount = value;
                    this.SendPropertyChanged("MaxFileCount");
                }
            }
        }

        [Column(Storage="_MaxPanicBuyCount", DbType="Int")]
        public int? MaxPanicBuyCount
        {
            get
            {
                return this._MaxPanicBuyCount;
            }
            set
            {
                if (this._MaxPanicBuyCount != value)
                {
                    this.SendPropertyChanging();
                    this._MaxPanicBuyCount = value;
                    this.SendPropertyChanged("MaxPanicBuyCount");
                }
            }
        }

        [Column(Storage="_MaxProductCount", DbType="Int")]
        public int? MaxProductCount
        {
            get
            {
                return this._MaxProductCount;
            }
            set
            {
                if (this._MaxProductCount != value)
                {
                    this.SendPropertyChanging();
                    this._MaxProductCount = value;
                    this.SendPropertyChanged("MaxProductCount");
                }
            }
        }

        [Column(Storage="_MaxSpellBuyCount", DbType="Int")]
        public int? MaxSpellBuyCount
        {
            get
            {
                return this._MaxSpellBuyCount;
            }
            set
            {
                if (this._MaxSpellBuyCount != value)
                {
                    this.SendPropertyChanging();
                    this._MaxSpellBuyCount = value;
                    this.SendPropertyChanged("MaxSpellBuyCount");
                }
            }
        }

        [Column(Storage="_MaxVedioCount", DbType="Int")]
        public int? MaxVedioCount
        {
            get
            {
                return this._MaxVedioCount;
            }
            set
            {
                if (this._MaxVedioCount != value)
                {
                    this.SendPropertyChanging();
                    this._MaxVedioCount = value;
                    this.SendPropertyChanged("MaxVedioCount");
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

        [Column(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if (this._Name != value)
                {
                    this.SendPropertyChanging();
                    this._Name = value;
                    this.SendPropertyChanged("Name");
                }
            }
        }

        [Column(Storage="_Pic", DbType="NVarChar(100)")]
        public string Pic
        {
            get
            {
                return this._Pic;
            }
            set
            {
                if (this._Pic != value)
                {
                    this.SendPropertyChanging();
                    this._Pic = value;
                    this.SendPropertyChanged("Pic");
                }
            }
        }

        [Column(Storage="_price", DbType="Decimal(18,2)")]
        public decimal? price
        {
            get
            {
                return this._price;
            }
            set
            {
                decimal? nullable = this._price;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._price = value;
                    this.SendPropertyChanged("price");
                }
            }
        }

        [Column(Storage="_RankValue", DbType="Int")]
        public int? RankValue
        {
            get
            {
                return this._RankValue;
            }
            set
            {
                if (this._RankValue != value)
                {
                    this.SendPropertyChanging();
                    this._RankValue = value;
                    this.SendPropertyChanged("RankValue");
                }
            }
        }

        [Column(Storage="_shopTemplate", DbType="NVarChar(MAX)")]
        public string shopTemplate
        {
            get
            {
                return this._shopTemplate;
            }
            set
            {
                if (this._shopTemplate != value)
                {
                    this.SendPropertyChanging();
                    this._shopTemplate = value;
                    this.SendPropertyChanged("shopTemplate");
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

        [Column(Storage="_validityDate", DbType="NVarChar(50)")]
        public string validityDate
        {
            get
            {
                return this._validityDate;
            }
            set
            {
                if (this._validityDate != value)
                {
                    this.SendPropertyChanging();
                    this._validityDate = value;
                    this.SendPropertyChanged("validityDate");
                }
            }
        }
    }
}

