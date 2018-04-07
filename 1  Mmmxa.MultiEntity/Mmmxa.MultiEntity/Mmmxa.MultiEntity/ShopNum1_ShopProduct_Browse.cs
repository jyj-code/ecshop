namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_ShopProduct_Browse")]
    public class ShopNum1_ShopProduct_Browse
    {
        private DateTime? _BrowseDateTime;
        private int? _BrowseTimes;
        private System.Guid? _Guid;
        private string _MemLoginID;
        private string _Name;
        private System.Guid? _ProductGuid;
        private string _ProductImage;
        private string _ShopID;
        private decimal? _ShopPrice;

        [Column(Storage="_BrowseDateTime", DbType="DateTime")]
        public DateTime? BrowseDateTime
        {
            get
            {
                return this._BrowseDateTime;
            }
            set
            {
                if (this._BrowseDateTime != value)
                {
                    this._BrowseDateTime = value;
                }
            }
        }

        [Column(Storage="_BrowseTimes", DbType="Int")]
        public int? BrowseTimes
        {
            get
            {
                return this._BrowseTimes;
            }
            set
            {
                if (this._BrowseTimes != value)
                {
                    this._BrowseTimes = value;
                }
            }
        }

        [Column(Storage="_Guid", DbType="UniqueIdentifier")]
        public System.Guid? Guid
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
                    this._MemLoginID = value;
                }
            }
        }

        [Column(Storage="_Name", DbType="NVarChar(150)")]
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

        [Column(Storage="_ProductGuid", DbType="UniqueIdentifier")]
        public System.Guid? ProductGuid
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

        [Column(Storage="_ProductImage", DbType="NVarChar(200)")]
        public string ProductImage
        {
            get
            {
                return this._ProductImage;
            }
            set
            {
                if (this._ProductImage != value)
                {
                    this._ProductImage = value;
                }
            }
        }

        [Column(Storage="_ShopID", DbType="NVarChar(50)")]
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

        [Column(Storage="_ShopPrice", DbType="Decimal(18,2)")]
        public decimal? ShopPrice
        {
            get
            {
                return this._ShopPrice;
            }
            set
            {
                decimal? nullable = this._ShopPrice;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this._ShopPrice = value;
                }
            }
        }
    }
}

