namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_OrderProduct")]
    public class ShopNum1_OrderProduct : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _Attributes;
        private decimal? _BuyerGetProfit;
        private int _BuyNumber;
        private decimal _BuyPrice;
        private int? _ConsumptionScore;
        private DateTime? _CreateTime;
        private string _DetailedSpecifications;
        private string _ExtensionAttriutes;
        private decimal _GroupPrice;
        private System.Guid _Guid;
        private int _IsJoinActivity;
        private int _IsReal;
        private int _IsShipment;
        private decimal _MarketPrice;
        private string _MemLoginID;
        private string _Name;
        private string _OrderInfoGuid;
        private int? _OrderType;
        private string _ProductGuid;
        private string _ProductImg;
        private string _ProductName;
        private int? _RankScore;
        private string _RepertoryNumber;
        private string _setStock;
        private string _ShopID;
        private decimal _ShopPrice;
        private string _SpecificationName;
        private string _SpecificationValue;
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

        [Column(Storage="_Attributes", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
        public string Attributes
        {
            get
            {
                return this._Attributes;
            }
            set
            {
                if (this._Attributes != value)
                {
                    this.SendPropertyChanging();
                    this._Attributes = value;
                    this.SendPropertyChanged("Attributes");
                }
            }
        }

        [Column(Storage="_BuyerGetProfit", DbType="Decimal(18,2)")]
        public decimal? BuyerGetProfit
        {
            get
            {
                return this._BuyerGetProfit;
            }
            set
            {
                decimal? nullable = this._BuyerGetProfit;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._BuyerGetProfit = value;
                    this.SendPropertyChanged("BuyerGetProfit");
                }
            }
        }

        [Column(Storage="_BuyNumber", DbType="Int NOT NULL")]
        public int BuyNumber
        {
            get
            {
                return this._BuyNumber;
            }
            set
            {
                if (this._BuyNumber != value)
                {
                    this.SendPropertyChanging();
                    this._BuyNumber = value;
                    this.SendPropertyChanged("BuyNumber");
                }
            }
        }

        [Column(Storage="_BuyPrice", DbType="Decimal(18,2) NOT NULL")]
        public decimal BuyPrice
        {
            get
            {
                return this._BuyPrice;
            }
            set
            {
                if (this._BuyPrice != value)
                {
                    this.SendPropertyChanging();
                    this._BuyPrice = value;
                    this.SendPropertyChanged("BuyPrice");
                }
            }
        }

        [Column(Storage="_ConsumptionScore", DbType="Int")]
        public int? ConsumptionScore
        {
            get
            {
                return this._ConsumptionScore;
            }
            set
            {
                if (this._ConsumptionScore != value)
                {
                    this.SendPropertyChanging();
                    this._ConsumptionScore = value;
                    this.SendPropertyChanged("ConsumptionScore");
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
                    this.SendPropertyChanging();
                    this._CreateTime = value;
                    this.SendPropertyChanged("CreateTime");
                }
            }
        }

        [Column(Storage="_DetailedSpecifications", DbType="NVarChar(4000)")]
        public string DetailedSpecifications
        {
            get
            {
                return this._DetailedSpecifications;
            }
            set
            {
                if (this._DetailedSpecifications != value)
                {
                    this.SendPropertyChanging();
                    this._DetailedSpecifications = value;
                    this.SendPropertyChanged("DetailedSpecifications");
                }
            }
        }

        [Column(Storage="_ExtensionAttriutes", DbType="NVarChar(250)")]
        public string ExtensionAttriutes
        {
            get
            {
                return this._ExtensionAttriutes;
            }
            set
            {
                if (this._ExtensionAttriutes != value)
                {
                    this.SendPropertyChanging();
                    this._ExtensionAttriutes = value;
                    this.SendPropertyChanged("ExtensionAttriutes");
                }
            }
        }

        [Column(Storage="_GroupPrice", DbType="Decimal(18,2) NOT NULL")]
        public decimal GroupPrice
        {
            get
            {
                return this._GroupPrice;
            }
            set
            {
                if (this._GroupPrice != value)
                {
                    this.SendPropertyChanging();
                    this._GroupPrice = value;
                    this.SendPropertyChanged("GroupPrice");
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

        [Column(Storage="_IsJoinActivity", DbType="Int NOT NULL")]
        public int IsJoinActivity
        {
            get
            {
                return this._IsJoinActivity;
            }
            set
            {
                if (this._IsJoinActivity != value)
                {
                    this.SendPropertyChanging();
                    this._IsJoinActivity = value;
                    this.SendPropertyChanged("IsJoinActivity");
                }
            }
        }

        [Column(Storage="_IsReal", DbType="Int NOT NULL")]
        public int IsReal
        {
            get
            {
                return this._IsReal;
            }
            set
            {
                if (this._IsReal != value)
                {
                    this.SendPropertyChanging();
                    this._IsReal = value;
                    this.SendPropertyChanged("IsReal");
                }
            }
        }

        [Column(Storage="_IsShipment", DbType="Int NOT NULL")]
        public int IsShipment
        {
            get
            {
                return this._IsShipment;
            }
            set
            {
                if (this._IsShipment != value)
                {
                    this.SendPropertyChanging();
                    this._IsShipment = value;
                    this.SendPropertyChanged("IsShipment");
                }
            }
        }

        [Column(Storage="_MarketPrice", DbType="Decimal(18,2) NOT NULL")]
        public decimal MarketPrice
        {
            get
            {
                return this._MarketPrice;
            }
            set
            {
                if (this._MarketPrice != value)
                {
                    this.SendPropertyChanging();
                    this._MarketPrice = value;
                    this.SendPropertyChanged("MarketPrice");
                }
            }
        }

        [Column(Storage="_MemLoginID", DbType="NVarChar(50)")]
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

        [Column(Storage="_Name", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
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

        [Column(Storage="_OrderInfoGuid", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string OrderInfoGuid
        {
            get
            {
                return this._OrderInfoGuid;
            }
            set
            {
                if (this._OrderInfoGuid != value)
                {
                    this.SendPropertyChanging();
                    this._OrderInfoGuid = value;
                    this.SendPropertyChanged("OrderInfoGuid");
                }
            }
        }

        [Column(Storage="_OrderType", DbType="Int")]
        public int? OrderType
        {
            get
            {
                return this._OrderType;
            }
            set
            {
                if (this._OrderType != value)
                {
                    this.SendPropertyChanging();
                    this._OrderType = value;
                    this.SendPropertyChanged("OrderType");
                }
            }
        }

        [Column(Storage="_ProductGuid", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ProductGuid
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

        [Column(Storage="_ProductImg", DbType="NVarChar(80)")]
        public string ProductImg
        {
            get
            {
                return this._ProductImg;
            }
            set
            {
                if (this._ProductImg != value)
                {
                    this.SendPropertyChanging();
                    this._ProductImg = value;
                    this.SendPropertyChanged("ProductImg");
                }
            }
        }

        [Column(Storage="_ProductName", DbType="VarChar(100)")]
        public string ProductName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                if (this._ProductName != value)
                {
                    this.SendPropertyChanging();
                    this._ProductName = value;
                    this.SendPropertyChanged("ProductName");
                }
            }
        }

        [Column(Storage="_RankScore", DbType="Int")]
        public int? RankScore
        {
            get
            {
                return this._RankScore;
            }
            set
            {
                if (this._RankScore != value)
                {
                    this.SendPropertyChanging();
                    this._RankScore = value;
                    this.SendPropertyChanged("RankScore");
                }
            }
        }

        [Column(Storage="_RepertoryNumber", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string RepertoryNumber
        {
            get
            {
                return this._RepertoryNumber;
            }
            set
            {
                if (this._RepertoryNumber != value)
                {
                    this.SendPropertyChanging();
                    this._RepertoryNumber = value;
                    this.SendPropertyChanged("RepertoryNumber");
                }
            }
        }

        [Column(Storage="_setStock", CanBeNull=false)]
        public string setStock
        {
            get
            {
                return this._setStock;
            }
            set
            {
                if (this._setStock != value)
                {
                    this.SendPropertyChanging();
                    this._setStock = value;
                    this.SendPropertyChanged("setStock");
                }
            }
        }

        [Column(Storage="_ShopID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ShopID
        {
            get
            {
                return this._ShopID;
            }
            set
            {
                if (this._ShopID != value)
                {
                    this.SendPropertyChanging();
                    this._ShopID = value;
                    this.SendPropertyChanged("ShopID");
                }
            }
        }

        [Column(Storage="_ShopPrice", DbType="Decimal(18,2) NOT NULL")]
        public decimal ShopPrice
        {
            get
            {
                return this._ShopPrice;
            }
            set
            {
                if (this._ShopPrice != value)
                {
                    this.SendPropertyChanging();
                    this._ShopPrice = value;
                    this.SendPropertyChanged("ShopPrice");
                }
            }
        }

        [Column(Storage="_SpecificationName", DbType="NVarChar(500)")]
        public string SpecificationName
        {
            get
            {
                return this._SpecificationName;
            }
            set
            {
                if (this._SpecificationName != value)
                {
                    this.SendPropertyChanging();
                    this._SpecificationName = value;
                    this.SendPropertyChanged("SpecificationName");
                }
            }
        }

        [Column(Storage="_SpecificationValue", DbType="NVarChar(500)")]
        public string SpecificationValue
        {
            get
            {
                return this._SpecificationValue;
            }
            set
            {
                if (this._SpecificationValue != value)
                {
                    this.SendPropertyChanging();
                    this._SpecificationValue = value;
                    this.SendPropertyChanged("SpecificationValue");
                }
            }
        }
    }
}

