namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_Shop_ScoreProduct")]
    public class ShopNum1_Shop_ScoreProduct
    {
        private string _Brief;
        private int? _ClickCount;
        private DateTime? _CreateTime;
        private string _CreateUser;
        private string _Detail;
        private System.Guid? _Guid;
        private int? _HaveSale;
        private byte? _IsAudit;
        private int? _IsDeleted;
        private byte? _IsHot;
        private byte? _IsNew;
        private byte? _IsRecommend;
        private int? _IsSaled;
        private decimal? _MarketPrice;
        private string _MemLoginID;
        private string _Meto_Description;
        private string _Meto_Keywords;
        private string _Meto_Title;
        private DateTime? _ModifyTime;
        private string _ModifyUser;
        private string _Name;
        private int? _OrderID;
        private string _OriginalImge;
        private string _ProductCategoryCode;
        private int? _ProductCategoryID;
        private string _ProductCategoryName;
        private int? _RepertoryCount;
        private string _RepertoryNumber;
        private int? _RepertoryWarnCount;
        private DateTime? _SaleTime;
        private int? _Score;
        private string _ShopID;
        private string _SmallImage;
        private string _SubstationID;
        private string _ThumbImage;
        private string _UnitName;
        private decimal? _Weight;

        [Column(Storage="_Brief", DbType="NVarChar(500)")]
        public string Brief
        {
            get
            {
                return this._Brief;
            }
            set
            {
                if (this._Brief != value)
                {
                    this._Brief = value;
                }
            }
        }

        [Column(Storage="_ClickCount", DbType="Int")]
        public int? ClickCount
        {
            get
            {
                return this._ClickCount;
            }
            set
            {
                if (this._ClickCount != value)
                {
                    this._ClickCount = value;
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
                    this._CreateTime = value;
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
                    this._CreateUser = value;
                }
            }
        }

        [Column(Storage="_Detail", DbType="NText", UpdateCheck=UpdateCheck.Never)]
        public string Detail
        {
            get
            {
                return this._Detail;
            }
            set
            {
                if (this._Detail != value)
                {
                    this._Detail = value;
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

        [Column(Storage="_HaveSale", DbType="Int")]
        public int? HaveSale
        {
            get
            {
                return this._HaveSale;
            }
            set
            {
                if (this._HaveSale != value)
                {
                    this._HaveSale = value;
                }
            }
        }

        [Column(Storage="_IsAudit", DbType="TinyInt")]
        public byte? IsAudit
        {
            get
            {
                return this._IsAudit;
            }
            set
            {
                if (this._IsAudit != value)
                {
                    this._IsAudit = value;
                }
            }
        }

        [Column(Storage="_IsDeleted", DbType="Int")]
        public int? IsDeleted
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

        [Column(Storage="_IsHot", DbType="TinyInt")]
        public byte? IsHot
        {
            get
            {
                return this._IsHot;
            }
            set
            {
                if (this._IsHot != value)
                {
                    this._IsHot = value;
                }
            }
        }

        [Column(Storage="_IsNew", DbType="TinyInt")]
        public byte? IsNew
        {
            get
            {
                return this._IsNew;
            }
            set
            {
                if (this._IsNew != value)
                {
                    this._IsNew = value;
                }
            }
        }

        [Column(Storage="_IsRecommend", DbType="TinyInt")]
        public byte? IsRecommend
        {
            get
            {
                return this._IsRecommend;
            }
            set
            {
                if (this._IsRecommend != value)
                {
                    this._IsRecommend = value;
                }
            }
        }

        [Column(Storage="_IsSaled", DbType="Int")]
        public int? IsSaled
        {
            get
            {
                return this._IsSaled;
            }
            set
            {
                if (this._IsSaled != value)
                {
                    this._IsSaled = value;
                }
            }
        }

        [Column(Storage="_MarketPrice", DbType="Decimal(18,2)")]
        public decimal? MarketPrice
        {
            get
            {
                return this._MarketPrice;
            }
            set
            {
                decimal? nullable = this._MarketPrice;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this._MarketPrice = value;
                }
            }
        }

        [Column(Storage="_MemLoginID", DbType="VarChar(100)")]
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

        [Column(Storage="_Meto_Description", DbType="NVarChar(150)")]
        public string Meto_Description
        {
            get
            {
                return this._Meto_Description;
            }
            set
            {
                if (this._Meto_Description != value)
                {
                    this._Meto_Description = value;
                }
            }
        }

        [Column(Storage="_Meto_Keywords", DbType="NVarChar(200)")]
        public string Meto_Keywords
        {
            get
            {
                return this._Meto_Keywords;
            }
            set
            {
                if (this._Meto_Keywords != value)
                {
                    this._Meto_Keywords = value;
                }
            }
        }

        [Column(Storage="_Meto_Title", DbType="NVarChar(150)")]
        public string Meto_Title
        {
            get
            {
                return this._Meto_Title;
            }
            set
            {
                if (this._Meto_Title != value)
                {
                    this._Meto_Title = value;
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
                    this._ModifyUser = value;
                }
            }
        }

        [Column(Storage="_Name", DbType="NVarChar(100)")]
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

        [Column(Storage="_OrderID", DbType="Int")]
        public int? OrderID
        {
            get
            {
                return this._OrderID;
            }
            set
            {
                if (this._OrderID != value)
                {
                    this._OrderID = value;
                }
            }
        }

        [Column(Storage="_OriginalImge", DbType="NVarChar(250)")]
        public string OriginalImge
        {
            get
            {
                return this._OriginalImge;
            }
            set
            {
                if (this._OriginalImge != value)
                {
                    this._OriginalImge = value;
                }
            }
        }

        [Column(Storage="_ProductCategoryCode", DbType="NVarChar(9)")]
        public string ProductCategoryCode
        {
            get
            {
                return this._ProductCategoryCode;
            }
            set
            {
                if (this._ProductCategoryCode != value)
                {
                    this._ProductCategoryCode = value;
                }
            }
        }

        [Column(Storage="_ProductCategoryID", DbType="Int")]
        public int? ProductCategoryID
        {
            get
            {
                return this._ProductCategoryID;
            }
            set
            {
                if (this._ProductCategoryID != value)
                {
                    this._ProductCategoryID = value;
                }
            }
        }

        [Column(Storage="_ProductCategoryName", DbType="NVarChar(500)")]
        public string ProductCategoryName
        {
            get
            {
                return this._ProductCategoryName;
            }
            set
            {
                if (this._ProductCategoryName != value)
                {
                    this._ProductCategoryName = value;
                }
            }
        }

        [Column(Storage="_RepertoryCount", DbType="Int")]
        public int? RepertoryCount
        {
            get
            {
                return this._RepertoryCount;
            }
            set
            {
                if (this._RepertoryCount != value)
                {
                    this._RepertoryCount = value;
                }
            }
        }

        [Column(Storage="_RepertoryNumber", DbType="NVarChar(50)")]
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
                    this._RepertoryNumber = value;
                }
            }
        }

        [Column(Storage="_RepertoryWarnCount", DbType="Int")]
        public int? RepertoryWarnCount
        {
            get
            {
                return this._RepertoryWarnCount;
            }
            set
            {
                if (this._RepertoryWarnCount != value)
                {
                    this._RepertoryWarnCount = value;
                }
            }
        }

        [Column(Storage="_SaleTime", DbType="DateTime")]
        public DateTime? SaleTime
        {
            get
            {
                return this._SaleTime;
            }
            set
            {
                if (this._SaleTime != value)
                {
                    this._SaleTime = value;
                }
            }
        }

        [Column(Storage="_Score", DbType="Int")]
        public int? Score
        {
            get
            {
                return this._Score;
            }
            set
            {
                if (this._Score != value)
                {
                    this._Score = value;
                }
            }
        }

        [Column(Storage="_ShopID", DbType="VarChar(100)")]
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

        [Column(Storage="_SmallImage", DbType="NVarChar(250)")]
        public string SmallImage
        {
            get
            {
                return this._SmallImage;
            }
            set
            {
                if (this._SmallImage != value)
                {
                    this._SmallImage = value;
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
                    this._SubstationID = value;
                }
            }
        }

        [Column(Storage="_ThumbImage", DbType="NVarChar(250)")]
        public string ThumbImage
        {
            get
            {
                return this._ThumbImage;
            }
            set
            {
                if (this._ThumbImage != value)
                {
                    this._ThumbImage = value;
                }
            }
        }

        [Column(Storage="_UnitName", DbType="NVarChar(20)")]
        public string UnitName
        {
            get
            {
                return this._UnitName;
            }
            set
            {
                if (this._UnitName != value)
                {
                    this._UnitName = value;
                }
            }
        }

        [Column(Storage="_Weight", DbType="Decimal(18,2)")]
        public decimal? Weight
        {
            get
            {
                return this._Weight;
            }
            set
            {
                decimal? nullable = this._Weight;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this._Weight = value;
                }
            }
        }
    }
}

