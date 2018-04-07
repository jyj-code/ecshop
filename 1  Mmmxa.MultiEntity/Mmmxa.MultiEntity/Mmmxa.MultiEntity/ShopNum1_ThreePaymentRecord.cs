namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_ThreePaymentRecord")]
    public class ShopNum1_ThreePaymentRecord : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private DateTime? _CreateTime;
        private Guid _GUID;
        private DateTime? _HasPayTime;
        private string _OrderNumber;
        private decimal _PayMoney;
        private string _PayTypeCode;
        private string _PayTypeGuid;
        private string _PayTypeName;
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

        [Column(Storage="_GUID", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
        public Guid GUID
        {
            get
            {
                return this._GUID;
            }
            set
            {
                if (this._GUID != value)
                {
                    this.SendPropertyChanging();
                    this._GUID = value;
                    this.SendPropertyChanged("GUID");
                }
            }
        }

        [Column(Storage="_HasPayTime", DbType="DateTime")]
        public DateTime? HasPayTime
        {
            get
            {
                return this._HasPayTime;
            }
            set
            {
                if (this._HasPayTime != value)
                {
                    this.SendPropertyChanging();
                    this._HasPayTime = value;
                    this.SendPropertyChanged("HasPayTime");
                }
            }
        }

        [Column(Storage="_OrderNumber", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
        public string OrderNumber
        {
            get
            {
                return this._OrderNumber;
            }
            set
            {
                if (this._OrderNumber != value)
                {
                    this.SendPropertyChanging();
                    this._OrderNumber = value;
                    this.SendPropertyChanged("OrderNumber");
                }
            }
        }

        [Column(Storage="_PayMoney", DbType="Decimal(18,2) NOT NULL")]
        public decimal PayMoney
        {
            get
            {
                return this._PayMoney;
            }
            set
            {
                if (this._PayMoney != value)
                {
                    this.SendPropertyChanging();
                    this._PayMoney = value;
                    this.SendPropertyChanged("PayMoney");
                }
            }
        }

        [Column(Storage="_PayTypeCode", DbType="NVarChar(50)")]
        public string PayTypeCode
        {
            get
            {
                return this._PayTypeCode;
            }
            set
            {
                if (this._PayTypeCode != value)
                {
                    this.SendPropertyChanging();
                    this._PayTypeCode = value;
                    this.SendPropertyChanged("PayTypeCode");
                }
            }
        }

        [Column(Storage="_PayTypeGuid", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
        public string PayTypeGuid
        {
            get
            {
                return this._PayTypeGuid;
            }
            set
            {
                if (this._PayTypeGuid != value)
                {
                    this.SendPropertyChanging();
                    this._PayTypeGuid = value;
                    this.SendPropertyChanged("PayTypeGuid");
                }
            }
        }

        [Column(Storage="_PayTypeName", DbType="NVarChar(100)")]
        public string PayTypeName
        {
            get
            {
                return this._PayTypeName;
            }
            set
            {
                if (this._PayTypeName != value)
                {
                    this.SendPropertyChanging();
                    this._PayTypeName = value;
                    this.SendPropertyChanged("PayTypeName");
                }
            }
        }
    }
}

