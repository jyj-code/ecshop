namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1__Limt_Package")]
    public class ShopNum1_Limt_Package : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private int? _BuyNum;
        private DateTime? _EndTime;
        private int _Id;
        private int? _LeaveNum;
        private int? _LimitProductNum;
        private int? _LimtActivityNum;
        private string _MemloginId;
        private string _Name;
        private decimal? _PayMoney;
        private int? _PublishedNum;
        private string _ShopName;
        private DateTime? _StartTime;
        private int? _State;
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

        [Column(Storage="_BuyNum", DbType="Int")]
        public int? BuyNum
        {
            get
            {
                return this._BuyNum;
            }
            set
            {
                if (this._BuyNum != value)
                {
                    this.SendPropertyChanging();
                    this._BuyNum = value;
                    this.SendPropertyChanged("BuyNum");
                }
            }
        }

        [Column(Storage="_EndTime", DbType="DateTime")]
        public DateTime? EndTime
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

        [Column(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if (this._Id != value)
                {
                    this.SendPropertyChanging();
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                }
            }
        }

        [Column(Storage="_LeaveNum", DbType="Int")]
        public int? LeaveNum
        {
            get
            {
                return this._LeaveNum;
            }
            set
            {
                if (this._LeaveNum != value)
                {
                    this.SendPropertyChanging();
                    this._LeaveNum = value;
                    this.SendPropertyChanged("LeaveNum");
                }
            }
        }

        [Column(Storage="_LimitProductNum", DbType="Int")]
        public int? LimitProductNum
        {
            get
            {
                return this._LimitProductNum;
            }
            set
            {
                if (this._LimitProductNum != value)
                {
                    this.SendPropertyChanging();
                    this._LimitProductNum = value;
                    this.SendPropertyChanged("LimitProductNum");
                }
            }
        }

        [Column(Storage="_LimtActivityNum", DbType="Int")]
        public int? LimtActivityNum
        {
            get
            {
                return this._LimtActivityNum;
            }
            set
            {
                if (this._LimtActivityNum != value)
                {
                    this.SendPropertyChanging();
                    this._LimtActivityNum = value;
                    this.SendPropertyChanged("LimtActivityNum");
                }
            }
        }

        [Column(Storage="_MemloginId", DbType="VarChar(50)")]
        public string MemloginId
        {
            get
            {
                return this._MemloginId;
            }
            set
            {
                if (this._MemloginId != value)
                {
                    this.SendPropertyChanging();
                    this._MemloginId = value;
                    this.SendPropertyChanged("MemloginId");
                }
            }
        }

        [Column(Storage="_Name", DbType="VarChar(100)")]
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

        [Column(Storage="_PayMoney", DbType="Decimal(18,2)")]
        public decimal? PayMoney
        {
            get
            {
                return this._PayMoney;
            }
            set
            {
                decimal? nullable = this._PayMoney;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._PayMoney = value;
                    this.SendPropertyChanged("PayMoney");
                }
            }
        }

        [Column(Storage="_PublishedNum", DbType="Int")]
        public int? PublishedNum
        {
            get
            {
                return this._PublishedNum;
            }
            set
            {
                if (this._PublishedNum != value)
                {
                    this.SendPropertyChanging();
                    this._PublishedNum = value;
                    this.SendPropertyChanged("PublishedNum");
                }
            }
        }

        [Column(Storage="_ShopName", DbType="VarChar(100)")]
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

        [Column(Storage="_State", DbType="Int")]
        public int? State
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
    }
}

