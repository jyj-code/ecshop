namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_MemberRank")]
    public class ShopNum1_MemberRank : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private DateTime _CreateTime;
        private string _CreateUser;
        private decimal? _Discount;
        private System.Guid _Guid;
        private int _IsDefault;
        private int _IsDeleted;
        private int _maxScore;
        private string _Memo;
        private int _minScore;
        private DateTime _ModifyTime;
        private string _ModifyUser;
        private string _Name;
        private string _Pic;
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

        [Column(Storage="_Discount", DbType="Decimal(18,2)")]
        public decimal? Discount
        {
            get
            {
                return this._Discount;
            }
            set
            {
                decimal? nullable = this._Discount;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._Discount = value;
                    this.SendPropertyChanged("Discount");
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

        [Column(Storage="_maxScore", DbType="Int NOT NULL")]
        public int maxScore
        {
            get
            {
                return this._maxScore;
            }
            set
            {
                if (this._maxScore != value)
                {
                    this.SendPropertyChanging();
                    this._maxScore = value;
                    this.SendPropertyChanged("maxScore");
                }
            }
        }

        [Column(Storage="_Memo", DbType="NVarChar(4000)")]
        public string Memo
        {
            get
            {
                return this._Memo;
            }
            set
            {
                if (this._Memo != value)
                {
                    this.SendPropertyChanging();
                    this._Memo = value;
                    this.SendPropertyChanged("Memo");
                }
            }
        }

        [Column(Storage="_minScore", DbType="Int NOT NULL")]
        public int minScore
        {
            get
            {
                return this._minScore;
            }
            set
            {
                if (this._minScore != value)
                {
                    this.SendPropertyChanging();
                    this._minScore = value;
                    this.SendPropertyChanged("minScore");
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
                    this.SendPropertyChanging();
                    this._ModifyTime = value;
                    this.SendPropertyChanged("ModifyTime");
                }
            }
        }

        [Column(Storage="_ModifyUser", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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

        [Column(Storage="_Pic", DbType="NVarChar(250)")]
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
    }
}

