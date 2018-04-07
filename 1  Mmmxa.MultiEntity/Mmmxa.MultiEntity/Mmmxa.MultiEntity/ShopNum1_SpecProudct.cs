namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_SpecProudct")]
    public class ShopNum1_SpecProudct
    {
        private DateTime? _CreateTime;
        private string _GoodColor;
        private string _GoodsNumber;
        private decimal? _GoodsPrice;
        private int? _GoodsStock;
        private string _ProductGuid;
        private int? _SalesCount;
        private string _ShopID;
        private string _SpecDetail;
        private string _SpecTotalId;
        private string _TbProp;

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
                    this._CreateTime = value;
                }
            }
        }

        [Column(Storage="_GoodColor", DbType="VarChar(20)")]
        public string GoodColor
        {
            get
            {
                return this._GoodColor;
            }
            set
            {
                if (this._GoodColor != value)
                {
                    this._GoodColor = value;
                }
            }
        }

        [Column(Storage="_GoodsNumber", DbType="VarChar(50)")]
        public string GoodsNumber
        {
            get
            {
                return this._GoodsNumber;
            }
            set
            {
                if (this._GoodsNumber != value)
                {
                    this._GoodsNumber = value;
                }
            }
        }

        [Column(Storage="_GoodsPrice", DbType="Decimal(18,0)")]
        public decimal? GoodsPrice
        {
            get
            {
                return this._GoodsPrice;
            }
            set
            {
                decimal? nullable = this._GoodsPrice;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this._GoodsPrice = value;
                }
            }
        }

        [Column(Storage="_GoodsStock", DbType="Int")]
        public int? GoodsStock
        {
            get
            {
                return this._GoodsStock;
            }
            set
            {
                if (this._GoodsStock != value)
                {
                    this._GoodsStock = value;
                }
            }
        }

        [Column(Storage="_ProductGuid", DbType="VarChar(50)")]
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
                    this._ProductGuid = value;
                }
            }
        }

        [Column(Storage="_SalesCount", DbType="Int")]
        public int? SalesCount
        {
            get
            {
                return this._SalesCount;
            }
            set
            {
                if (this._SalesCount != value)
                {
                    this._SalesCount = value;
                }
            }
        }

        [Column(Storage="_ShopID", DbType="VarChar(50)")]
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

        [Column(Storage="_SpecDetail", DbType="VarChar(500)")]
        public string SpecDetail
        {
            get
            {
                return this._SpecDetail;
            }
            set
            {
                if (this._SpecDetail != value)
                {
                    this._SpecDetail = value;
                }
            }
        }

        [Column(Storage="_SpecTotalId", DbType="VarChar(50)")]
        public string SpecTotalId
        {
            get
            {
                return this._SpecTotalId;
            }
            set
            {
                if (this._SpecTotalId != value)
                {
                    this._SpecTotalId = value;
                }
            }
        }

        [Column(Storage="_TbProp", DbType="VarChar(200)")]
        public string TbProp
        {
            get
            {
                return this._TbProp;
            }
            set
            {
                if (this._TbProp != value)
                {
                    this._TbProp = value;
                }
            }
        }
    }
}

