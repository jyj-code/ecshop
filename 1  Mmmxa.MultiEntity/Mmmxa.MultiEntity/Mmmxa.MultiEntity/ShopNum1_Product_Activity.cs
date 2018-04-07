namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_Product_Activity")]
    public class ShopNum1_Product_Activity : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private int? _BuyNum;
        private decimal? _Discount;
        private DateTime? _EndTime;
        private DateTime? _FinalTime;
        private int _Id;
        private int? _LimitProduct;
        private string _MemloginId;
        private string _Name;
        private int? _OrderId;
        private string _Pic;
        private string _ShopName;
        private DateTime? _StartTime;
        private int? _State;
        private string _SubstationID;
        private int? _Type;
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

        [Column(Storage="_FinalTime", DbType="DateTime")]
        public DateTime? FinalTime
        {
            get
            {
                return this._FinalTime;
            }
            set
            {
                if (this._FinalTime != value)
                {
                    this.SendPropertyChanging();
                    this._FinalTime = value;
                    this.SendPropertyChanged("FinalTime");
                }
            }
        }

        [Column(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
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

        [Column(Storage="_LimitProduct", DbType="Int")]
        public int? LimitProduct
        {
            get
            {
                return this._LimitProduct;
            }
            set
            {
                if (this._LimitProduct != value)
                {
                    this.SendPropertyChanging();
                    this._LimitProduct = value;
                    this.SendPropertyChanged("LimitProduct");
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

        [Column(Storage="_OrderId", DbType="Int")]
        public int? OrderId
        {
            get
            {
                return this._OrderId;
            }
            set
            {
                if (this._OrderId != value)
                {
                    this.SendPropertyChanging();
                    this._OrderId = value;
                    this.SendPropertyChanged("OrderId");
                }
            }
        }

        [Column(Storage="_Pic", DbType="VarChar(80)")]
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

        [Column(Storage="_Type", DbType="Int")]
        public int? Type
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
    }
}

