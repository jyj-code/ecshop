namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_Shop_Product")]
    public class ShopNum1_Shop_Product : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _AddressCode;
        private string _AddressValue;
        private System.Guid _BrandGuid;
        private string _BrandName;
        private int _BuyCount;
        private int _ClickCount;
        private int _CollectCount;
        private int _CommentCount;
        private DateTime? _CreateTime;
        private string _CreateUser;
        private int? _Ctype;
        private DateTime? _DeSaleTime;
        private string _Description;
        private string _Detail;
        private decimal _Ems_fee;
        private DateTime? _EndTime;
        private decimal _Express_fee;
        private int? _FeeTemplateID;
        private string _FeeTemplateName;
        private int _FeeType;
        private System.Guid _Guid;
        private long _Id;
        private string _Instruction;
        private int _IsAudit;
        private int? _IsBest;
        private int? _IsDeleted;
        private int? _IsHot;
        private int? _IsNew;
        private int? _IsPromotion;
        private int _IsReal;
        private int _IsRecommend;
        private int? _IsSaled;
        private int _IsSell;
        private int _IsShopGood;
        private int _IsShopHot;
        private int _IsShopNew;
        private int _IsShopPromotion;
        private int _IsShopRecommend;
        private int? _IsSystemHot;
        private int? _IsSystemRecommend;
        private string _Keywords;
        private decimal? _MarketPrice;
        private string _MemLoginID;
        private decimal _MinusFee;
        private DateTime? _ModifyTime;
        private string _ModifyUser;
        private int _MonthSale;
        private string _MultiImages;
        private string _Name;
        private int? _OrderID;
        private string _OriginalImage;
        private decimal _Post_fee;
        private string _ProductCategoryCode;
        private string _ProductCategoryName;
        private string _ProductNum;
        private string _ProductSeriesCode;
        private string _ProductSeriesName;
        private int? _ProductState;
        private int? _PulishType;
        private int? _RepertoryAlertCount;
        private int _RepertoryCount;
        private int _SaleNumber;
        private DateTime? _SaleTime;
        private int? _Score;
        private int? _SetStock;
        private string _ShopName;
        private decimal _ShopPrice;
        private string _SmallImage;
        private DateTime? _StartTime;
        private string _SubstationID;
        private int? _SystemOrderID;
        private string _ThumbImage;
        private string _UnitName;
        private string _Wap_desc;
        private string _Wap_detail_url;
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

        [Column(Storage="_AddressCode", DbType="NVarChar(250)")]
        public string AddressCode
        {
            get
            {
                return this._AddressCode;
            }
            set
            {
                if (this._AddressCode != value)
                {
                    this.SendPropertyChanging();
                    this._AddressCode = value;
                    this.SendPropertyChanged("AddressCode");
                }
            }
        }

        [Column(Storage="_AddressValue", DbType="NVarChar(250)")]
        public string AddressValue
        {
            get
            {
                return this._AddressValue;
            }
            set
            {
                if (this._AddressValue != value)
                {
                    this.SendPropertyChanging();
                    this._AddressValue = value;
                    this.SendPropertyChanged("AddressValue");
                }
            }
        }

        [Column(Storage="_BrandGuid", DbType="UniqueIdentifier NOT NULL")]
        public System.Guid BrandGuid
        {
            get
            {
                return this._BrandGuid;
            }
            set
            {
                if (this._BrandGuid != value)
                {
                    this.SendPropertyChanging();
                    this._BrandGuid = value;
                    this.SendPropertyChanged("BrandGuid");
                }
            }
        }

        [Column(Storage="_BrandName", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
        public string BrandName
        {
            get
            {
                return this._BrandName;
            }
            set
            {
                if (this._BrandName != value)
                {
                    this.SendPropertyChanging();
                    this._BrandName = value;
                    this.SendPropertyChanged("BrandName");
                }
            }
        }

        [Column(Storage="_BuyCount", DbType="Int NOT NULL")]
        public int BuyCount
        {
            get
            {
                return this._BuyCount;
            }
            set
            {
                if (this._BuyCount != value)
                {
                    this.SendPropertyChanging();
                    this._BuyCount = value;
                    this.SendPropertyChanged("BuyCount");
                }
            }
        }

        [Column(Storage="_ClickCount", DbType="Int NOT NULL")]
        public int ClickCount
        {
            get
            {
                return this._ClickCount;
            }
            set
            {
                if (this._ClickCount != value)
                {
                    this.SendPropertyChanging();
                    this._ClickCount = value;
                    this.SendPropertyChanged("ClickCount");
                }
            }
        }

        [Column(Storage="_CollectCount", DbType="Int NOT NULL")]
        public int CollectCount
        {
            get
            {
                return this._CollectCount;
            }
            set
            {
                if (this._CollectCount != value)
                {
                    this.SendPropertyChanging();
                    this._CollectCount = value;
                    this.SendPropertyChanged("CollectCount");
                }
            }
        }

        [Column(Storage="_CommentCount", DbType="Int NOT NULL")]
        public int CommentCount
        {
            get
            {
                return this._CommentCount;
            }
            set
            {
                if (this._CommentCount != value)
                {
                    this.SendPropertyChanging();
                    this._CommentCount = value;
                    this.SendPropertyChanged("CommentCount");
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
                    this.SendPropertyChanging();
                    this._CreateUser = value;
                    this.SendPropertyChanged("CreateUser");
                }
            }
        }

        [Column(Storage="_Ctype", DbType="Int")]
        public int? Ctype
        {
            get
            {
                return this._Ctype;
            }
            set
            {
                if (this._Ctype != value)
                {
                    this.SendPropertyChanging();
                    this._Ctype = value;
                    this.SendPropertyChanged("Ctype");
                }
            }
        }

        [Column(Storage="_DeSaleTime", DbType="DateTime")]
        public DateTime? DeSaleTime
        {
            get
            {
                return this._DeSaleTime;
            }
            set
            {
                if (this._DeSaleTime != value)
                {
                    this.SendPropertyChanging();
                    this._DeSaleTime = value;
                    this.SendPropertyChanged("DeSaleTime");
                }
            }
        }

        [Column(Storage="_Description", DbType="NVarChar(250)")]
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
                    this.SendPropertyChanging();
                    this._Description = value;
                    this.SendPropertyChanged("Description");
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
                    this.SendPropertyChanging();
                    this._Detail = value;
                    this.SendPropertyChanged("Detail");
                }
            }
        }

        [Column(Storage="_Ems_fee", DbType="Decimal(18,2) NOT NULL")]
        public decimal Ems_fee
        {
            get
            {
                return this._Ems_fee;
            }
            set
            {
                if (this._Ems_fee != value)
                {
                    this.SendPropertyChanging();
                    this._Ems_fee = value;
                    this.SendPropertyChanged("Ems_fee");
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

        [Column(Storage="_Express_fee", DbType="Decimal(18,2) NOT NULL")]
        public decimal Express_fee
        {
            get
            {
                return this._Express_fee;
            }
            set
            {
                if (this._Express_fee != value)
                {
                    this.SendPropertyChanging();
                    this._Express_fee = value;
                    this.SendPropertyChanged("Express_fee");
                }
            }
        }

        [Column(Storage="_FeeTemplateID", DbType="Int")]
        public int? FeeTemplateID
        {
            get
            {
                return this._FeeTemplateID;
            }
            set
            {
                if (this._FeeTemplateID != value)
                {
                    this.SendPropertyChanging();
                    this._FeeTemplateID = value;
                    this.SendPropertyChanged("FeeTemplateID");
                }
            }
        }

        [Column(Storage="_FeeTemplateName", DbType="NVarChar(50)")]
        public string FeeTemplateName
        {
            get
            {
                return this._FeeTemplateName;
            }
            set
            {
                if (this._FeeTemplateName != value)
                {
                    this.SendPropertyChanging();
                    this._FeeTemplateName = value;
                    this.SendPropertyChanged("FeeTemplateName");
                }
            }
        }

        [Column(Storage="_FeeType", DbType="Int NOT NULL")]
        public int FeeType
        {
            get
            {
                return this._FeeType;
            }
            set
            {
                if (this._FeeType != value)
                {
                    this.SendPropertyChanging();
                    this._FeeType = value;
                    this.SendPropertyChanged("FeeType");
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

        [Column(Storage="_Id", AutoSync=AutoSync.Always, DbType="BigInt NOT NULL IDENTITY", IsDbGenerated=true)]
        public long Id
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

        [Column(Storage="_Instruction", DbType="NVarChar(4000)")]
        public string Instruction
        {
            get
            {
                return this._Instruction;
            }
            set
            {
                if (this._Instruction != value)
                {
                    this.SendPropertyChanging();
                    this._Instruction = value;
                    this.SendPropertyChanged("Instruction");
                }
            }
        }

        [Column(Storage="_IsAudit", DbType="Int NOT NULL")]
        public int IsAudit
        {
            get
            {
                return this._IsAudit;
            }
            set
            {
                if (this._IsAudit != value)
                {
                    this.SendPropertyChanging();
                    this._IsAudit = value;
                    this.SendPropertyChanged("IsAudit");
                }
            }
        }

        [Column(Storage="_IsBest", DbType="Int")]
        public int? IsBest
        {
            get
            {
                return this._IsBest;
            }
            set
            {
                if (this._IsBest != value)
                {
                    this.SendPropertyChanging();
                    this._IsBest = value;
                    this.SendPropertyChanged("IsBest");
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
                    this.SendPropertyChanging();
                    this._IsDeleted = value;
                    this.SendPropertyChanged("IsDeleted");
                }
            }
        }

        [Column(Storage="_IsHot", DbType="Int")]
        public int? IsHot
        {
            get
            {
                return this._IsHot;
            }
            set
            {
                if (this._IsHot != value)
                {
                    this.SendPropertyChanging();
                    this._IsHot = value;
                    this.SendPropertyChanged("IsHot");
                }
            }
        }

        [Column(Storage="_IsNew", DbType="Int")]
        public int? IsNew
        {
            get
            {
                return this._IsNew;
            }
            set
            {
                if (this._IsNew != value)
                {
                    this.SendPropertyChanging();
                    this._IsNew = value;
                    this.SendPropertyChanged("IsNew");
                }
            }
        }

        [Column(Storage="_IsPromotion", DbType="Int")]
        public int? IsPromotion
        {
            get
            {
                return this._IsPromotion;
            }
            set
            {
                if (this._IsPromotion != value)
                {
                    this.SendPropertyChanging();
                    this._IsPromotion = value;
                    this.SendPropertyChanged("IsPromotion");
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

        [Column(Storage="_IsRecommend", DbType="Int NOT NULL")]
        public int IsRecommend
        {
            get
            {
                return this._IsRecommend;
            }
            set
            {
                if (this._IsRecommend != value)
                {
                    this.SendPropertyChanging();
                    this._IsRecommend = value;
                    this.SendPropertyChanged("IsRecommend");
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
                    this.SendPropertyChanging();
                    this._IsSaled = value;
                    this.SendPropertyChanged("IsSaled");
                }
            }
        }

        [Column(Storage="_IsSell", DbType="Int NOT NULL")]
        public int IsSell
        {
            get
            {
                return this._IsSell;
            }
            set
            {
                if (this._IsSell != value)
                {
                    this.SendPropertyChanging();
                    this._IsSell = value;
                    this.SendPropertyChanged("IsSell");
                }
            }
        }

        [Column(Storage="_IsShopGood", DbType="Int NOT NULL")]
        public int IsShopGood
        {
            get
            {
                return this._IsShopGood;
            }
            set
            {
                if (this._IsShopGood != value)
                {
                    this.SendPropertyChanging();
                    this._IsShopGood = value;
                    this.SendPropertyChanged("IsShopGood");
                }
            }
        }

        [Column(Storage="_IsShopHot", DbType="Int NOT NULL")]
        public int IsShopHot
        {
            get
            {
                return this._IsShopHot;
            }
            set
            {
                if (this._IsShopHot != value)
                {
                    this.SendPropertyChanging();
                    this._IsShopHot = value;
                    this.SendPropertyChanged("IsShopHot");
                }
            }
        }

        [Column(Storage="_IsShopNew", DbType="Int NOT NULL")]
        public int IsShopNew
        {
            get
            {
                return this._IsShopNew;
            }
            set
            {
                if (this._IsShopNew != value)
                {
                    this.SendPropertyChanging();
                    this._IsShopNew = value;
                    this.SendPropertyChanged("IsShopNew");
                }
            }
        }

        [Column(Storage="_IsShopPromotion", DbType="Int NOT NULL")]
        public int IsShopPromotion
        {
            get
            {
                return this._IsShopPromotion;
            }
            set
            {
                if (this._IsShopPromotion != value)
                {
                    this.SendPropertyChanging();
                    this._IsShopPromotion = value;
                    this.SendPropertyChanged("IsShopPromotion");
                }
            }
        }

        [Column(Storage="_IsShopRecommend", DbType="Int NOT NULL")]
        public int IsShopRecommend
        {
            get
            {
                return this._IsShopRecommend;
            }
            set
            {
                if (this._IsShopRecommend != value)
                {
                    this.SendPropertyChanging();
                    this._IsShopRecommend = value;
                    this.SendPropertyChanged("IsShopRecommend");
                }
            }
        }

        [Column(Storage="_IsSystemHot", DbType="Int")]
        public int? IsSystemHot
        {
            get
            {
                return this._IsSystemHot;
            }
            set
            {
                if (this._IsSystemHot != value)
                {
                    this.SendPropertyChanging();
                    this._IsSystemHot = value;
                    this.SendPropertyChanged("IsSystemHot");
                }
            }
        }

        [Column(Storage="_IsSystemRecommend", DbType="Int")]
        public int? IsSystemRecommend
        {
            get
            {
                return this._IsSystemRecommend;
            }
            set
            {
                if (this._IsSystemRecommend != value)
                {
                    this.SendPropertyChanging();
                    this._IsSystemRecommend = value;
                    this.SendPropertyChanged("IsSystemRecommend");
                }
            }
        }

        [Column(Storage="_Keywords", DbType="NVarChar(150)")]
        public string Keywords
        {
            get
            {
                return this._Keywords;
            }
            set
            {
                if (this._Keywords != value)
                {
                    this.SendPropertyChanging();
                    this._Keywords = value;
                    this.SendPropertyChanged("Keywords");
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

        [Column(Storage="_MinusFee", DbType="Decimal(18,2) NOT NULL")]
        public decimal MinusFee
        {
            get
            {
                return this._MinusFee;
            }
            set
            {
                if (this._MinusFee != value)
                {
                    this.SendPropertyChanging();
                    this._MinusFee = value;
                    this.SendPropertyChanged("MinusFee");
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
                    this.SendPropertyChanging();
                    this._ModifyTime = value;
                    this.SendPropertyChanged("ModifyTime");
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
                    this.SendPropertyChanging();
                    this._ModifyUser = value;
                    this.SendPropertyChanged("ModifyUser");
                }
            }
        }

        [Column(Storage="_MonthSale", DbType="Int NOT NULL")]
        public int MonthSale
        {
            get
            {
                return this._MonthSale;
            }
            set
            {
                if (this._MonthSale != value)
                {
                    this.SendPropertyChanging();
                    this._MonthSale = value;
                    this.SendPropertyChanged("MonthSale");
                }
            }
        }

        [Column(Storage="_MultiImages", DbType="NVarChar(800)")]
        public string MultiImages
        {
            get
            {
                return this._MultiImages;
            }
            set
            {
                if (this._MultiImages != value)
                {
                    this.SendPropertyChanging();
                    this._MultiImages = value;
                    this.SendPropertyChanged("MultiImages");
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
                    this.SendPropertyChanging();
                    this._OrderID = value;
                    this.SendPropertyChanged("OrderID");
                }
            }
        }

        [Column(Storage="_OriginalImage", DbType="NVarChar(150) NOT NULL", CanBeNull=false)]
        public string OriginalImage
        {
            get
            {
                return this._OriginalImage;
            }
            set
            {
                if (this._OriginalImage != value)
                {
                    this.SendPropertyChanging();
                    this._OriginalImage = value;
                    this.SendPropertyChanged("OriginalImage");
                }
            }
        }

        [Column(Storage="_Post_fee", DbType="Decimal(18,2) NOT NULL")]
        public decimal Post_fee
        {
            get
            {
                return this._Post_fee;
            }
            set
            {
                if (this._Post_fee != value)
                {
                    this.SendPropertyChanging();
                    this._Post_fee = value;
                    this.SendPropertyChanged("Post_fee");
                }
            }
        }

        [Column(Storage="_ProductCategoryCode", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
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
                    this.SendPropertyChanging();
                    this._ProductCategoryCode = value;
                    this.SendPropertyChanged("ProductCategoryCode");
                }
            }
        }

        [Column(Storage="_ProductCategoryName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
                    this.SendPropertyChanging();
                    this._ProductCategoryName = value;
                    this.SendPropertyChanged("ProductCategoryName");
                }
            }
        }

        [Column(Storage="_ProductNum", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
        public string ProductNum
        {
            get
            {
                return this._ProductNum;
            }
            set
            {
                if (this._ProductNum != value)
                {
                    this.SendPropertyChanging();
                    this._ProductNum = value;
                    this.SendPropertyChanged("ProductNum");
                }
            }
        }

        [Column(Storage="_ProductSeriesCode", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
        public string ProductSeriesCode
        {
            get
            {
                return this._ProductSeriesCode;
            }
            set
            {
                if (this._ProductSeriesCode != value)
                {
                    this.SendPropertyChanging();
                    this._ProductSeriesCode = value;
                    this.SendPropertyChanged("ProductSeriesCode");
                }
            }
        }

        [Column(Storage="_ProductSeriesName", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
        public string ProductSeriesName
        {
            get
            {
                return this._ProductSeriesName;
            }
            set
            {
                if (this._ProductSeriesName != value)
                {
                    this.SendPropertyChanging();
                    this._ProductSeriesName = value;
                    this.SendPropertyChanged("ProductSeriesName");
                }
            }
        }

        [Column(Storage="_ProductState", DbType="Int")]
        public int? ProductState
        {
            get
            {
                return this._ProductState;
            }
            set
            {
                if (this._ProductState != value)
                {
                    this.SendPropertyChanging();
                    this._ProductState = value;
                    this.SendPropertyChanged("ProductState");
                }
            }
        }

        [Column(Storage="_PulishType", DbType="Int")]
        public int? PulishType
        {
            get
            {
                return this._PulishType;
            }
            set
            {
                if (this._PulishType != value)
                {
                    this.SendPropertyChanging();
                    this._PulishType = value;
                    this.SendPropertyChanged("PulishType");
                }
            }
        }

        [Column(Storage="_RepertoryAlertCount", DbType="Int")]
        public int? RepertoryAlertCount
        {
            get
            {
                return this._RepertoryAlertCount;
            }
            set
            {
                if (this._RepertoryAlertCount != value)
                {
                    this.SendPropertyChanging();
                    this._RepertoryAlertCount = value;
                    this.SendPropertyChanged("RepertoryAlertCount");
                }
            }
        }

        [Column(Storage="_RepertoryCount", DbType="Int NOT NULL")]
        public int RepertoryCount
        {
            get
            {
                return this._RepertoryCount;
            }
            set
            {
                if (this._RepertoryCount != value)
                {
                    this.SendPropertyChanging();
                    this._RepertoryCount = value;
                    this.SendPropertyChanged("RepertoryCount");
                }
            }
        }

        [Column(Storage="_SaleNumber", DbType="Int NOT NULL")]
        public int SaleNumber
        {
            get
            {
                return this._SaleNumber;
            }
            set
            {
                if (this._SaleNumber != value)
                {
                    this.SendPropertyChanging();
                    this._SaleNumber = value;
                    this.SendPropertyChanged("SaleNumber");
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
                    this.SendPropertyChanging();
                    this._SaleTime = value;
                    this.SendPropertyChanged("SaleTime");
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
                    this.SendPropertyChanging();
                    this._Score = value;
                    this.SendPropertyChanged("Score");
                }
            }
        }

        [Column(Storage="_SetStock", DbType="Int")]
        public int? SetStock
        {
            get
            {
                return this._SetStock;
            }
            set
            {
                if (this._SetStock != value)
                {
                    this.SendPropertyChanging();
                    this._SetStock = value;
                    this.SendPropertyChanged("SetStock");
                }
            }
        }

        [Column(Storage="_ShopName", DbType="NVarChar(50)")]
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

        [Column(Storage="_SmallImage", DbType="NVarChar(150)")]
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
                    this.SendPropertyChanging();
                    this._SmallImage = value;
                    this.SendPropertyChanged("SmallImage");
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

        [Column(Storage="_SystemOrderID", DbType="Int")]
        public int? SystemOrderID
        {
            get
            {
                return this._SystemOrderID;
            }
            set
            {
                if (this._SystemOrderID != value)
                {
                    this.SendPropertyChanging();
                    this._SystemOrderID = value;
                    this.SendPropertyChanged("SystemOrderID");
                }
            }
        }

        [Column(Storage="_ThumbImage", DbType="NVarChar(150) NOT NULL", CanBeNull=false)]
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
                    this.SendPropertyChanging();
                    this._ThumbImage = value;
                    this.SendPropertyChanged("ThumbImage");
                }
            }
        }

        [Column(Storage="_UnitName", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
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
                    this.SendPropertyChanging();
                    this._UnitName = value;
                    this.SendPropertyChanged("UnitName");
                }
            }
        }

        [Column(Storage="_Wap_desc", DbType="VarChar(5000)")]
        public string Wap_desc
        {
            get
            {
                return this._Wap_desc;
            }
            set
            {
                if (this._Wap_desc != value)
                {
                    this.SendPropertyChanging();
                    this._Wap_desc = value;
                    this.SendPropertyChanged("Wap_desc");
                }
            }
        }

        [Column(Storage="_Wap_detail_url", DbType="VarChar(100)")]
        public string Wap_detail_url
        {
            get
            {
                return this._Wap_detail_url;
            }
            set
            {
                if (this._Wap_detail_url != value)
                {
                    this.SendPropertyChanging();
                    this._Wap_detail_url = value;
                    this.SendPropertyChanged("Wap_detail_url");
                }
            }
        }
    }
}

