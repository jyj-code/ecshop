namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_MemberProductCollect")]
    public class ShopNum1_MemberProductCollect
    {
        private DateTime _CollectTime;
        private System.Guid _Guid;
        private int _IsAttention;
        private int _IsDeleted;
        private string _MemLoginID;
        private System.Guid _ProductGuid;
        private string _ProductName;
        private string _SellLoginID;
        private string _ShopID;
        private decimal _ShopPrice;

        [Column(Storage="_CollectTime", DbType="DateTime NOT NULL")]
        public DateTime CollectTime
        {
            get
            {
                return this._CollectTime;
            }
            set
            {
                if (this._CollectTime != value)
                {
                    this._CollectTime = value;
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

        [Column(Storage="_IsAttention", DbType="Int NOT NULL")]
        public int IsAttention
        {
            get
            {
                return this._IsAttention;
            }
            set
            {
                if (this._IsAttention != value)
                {
                    this._IsAttention = value;
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
                    this._IsDeleted = value;
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

        [Column(Storage="_ProductGuid", DbType="UniqueIdentifier NOT NULL")]
        public System.Guid ProductGuid
        {
            get
            {
                return this._ProductGuid;
            }
            set
            {
                if (this._ProductGuid != value)
                {
                    this._ProductGuid = value;
                }
            }
        }

        [Column(Storage="_ProductName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
                    this._ProductName = value;
                }
            }
        }

        [Column(Storage="_SellLoginID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string SellLoginID
        {
            get
            {
                return this._SellLoginID;
            }
            set
            {
                if (this._SellLoginID != value)
                {
                    this._SellLoginID = value;
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
                    this._ShopID = value;
                }
            }
        }

        [Column(Storage="_ShopPrice", DbType="Decimal(18,0) NOT NULL")]
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
                    this._ShopPrice = value;
                }
            }
        }
    }
}

