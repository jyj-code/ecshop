namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_Shop_OtherOrderInfo")]
    public class ShopNum1_Shop_OtherOrderInfo
    {
        private int _BuyNumber;
        private DateTime _CreateTime;
        private string _Description;
        private System.Guid _Guid;
        private string _MemLoginID;
        private DateTime? _ModifyTime;
        private string _Name;
        private int _OrderStatus;
        private string _PaymentName;
        private int _PaymentStatus;
        private DateTime? _PaymentTime;
        private System.Guid _PaymentType;
        private string _RelevanceID;
        private decimal _TotalPrice;
        private string _TradeID;
        private string _Type;
        private decimal _UnitPrice;

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
                    this._BuyNumber = value;
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
                    this._CreateTime = value;
                }
            }
        }

        [Column(Storage="_Description", DbType="NVarChar(MAX)")]
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                if (this._Description != value)
                {
                    this._Description = value;
                }
            }
        }

        [Column(Storage="_Guid", DbType="UniqueIdentifier NOT NULL")]
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
                    this._Guid = value;
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
                    this._ModifyTime = value;
                }
            }
        }

        [Column(Storage="_Name", DbType="NChar(100) NOT NULL", CanBeNull=false)]
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
                    this._Name = value;
                }
            }
        }

        [Column(Storage="_OrderStatus", DbType="Int NOT NULL")]
        public int OrderStatus
        {
            get
            {
                return this._OrderStatus;
            }
            set
            {
                if (this._OrderStatus != value)
                {
                    this._OrderStatus = value;
                }
            }
        }

        [Column(Storage="_PaymentName", DbType="NChar(100) NOT NULL", CanBeNull=false)]
        public string PaymentName
        {
            get
            {
                return this._PaymentName;
            }
            set
            {
                if (this._PaymentName != value)
                {
                    this._PaymentName = value;
                }
            }
        }

        [Column(Storage="_PaymentStatus", DbType="Int NOT NULL")]
        public int PaymentStatus
        {
            get
            {
                return this._PaymentStatus;
            }
            set
            {
                if (this._PaymentStatus != value)
                {
                    this._PaymentStatus = value;
                }
            }
        }

        [Column(Storage="_PaymentTime", DbType="DateTime")]
        public DateTime? PaymentTime
        {
            get
            {
                return this._PaymentTime;
            }
            set
            {
                if (this._PaymentTime != value)
                {
                    this._PaymentTime = value;
                }
            }
        }

        [Column(Storage="_PaymentType", DbType="UniqueIdentifier NOT NULL")]
        public System.Guid PaymentType
        {
            get
            {
                return this._PaymentType;
            }
            set
            {
                if (this._PaymentType != value)
                {
                    this._PaymentType = value;
                }
            }
        }

        [Column(Storage="_RelevanceID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string RelevanceID
        {
            get
            {
                return this._RelevanceID;
            }
            set
            {
                if (this._RelevanceID != value)
                {
                    this._RelevanceID = value;
                }
            }
        }

        [Column(Storage="_TotalPrice", DbType="Decimal(18,2) NOT NULL")]
        public decimal TotalPrice
        {
            get
            {
                return this._TotalPrice;
            }
            set
            {
                if (this._TotalPrice != value)
                {
                    this._TotalPrice = value;
                }
            }
        }

        [Column(Storage="_TradeID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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

        [Column(Storage="_Type", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string Type
        {
            get
            {
                return this._Type;
            }
            set
            {
                if (this._Type != value)
                {
                    this._Type = value;
                }
            }
        }

        [Column(Storage="_UnitPrice", DbType="Decimal(18,2) NOT NULL")]
        public decimal UnitPrice
        {
            get
            {
                return this._UnitPrice;
            }
            set
            {
                if (this._UnitPrice != value)
                {
                    this._UnitPrice = value;
                }
            }
        }
    }
}

