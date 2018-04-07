namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_ShopInfo")]
    public class ShopNum1_ShopInfo : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _Address;
        private string _AddressCode;
        private string _AddressValue;
        private DateTime? _ApplyTime;
        private string _AuditFailedReason;
        private DateTime? _AuditTime;
        private string _Banner;
        private string _BusinessLicense;
        private string _BusinessScope;
        private string _BusinessTerm;
        private string _CardImage;
        private int _ClickCount;
        private int _CollectCount;
        private string _CompanAuditFailedReason;
        private DateTime? _CompanAuditTime;
        private int _CompanIsAudit;
        private string _CompanName;
        private string _CompanyIntroduce;
        private string _Email;
        private string _EnsureID;
        private System.Guid _Guid;
        private DateTime? _IdentityAuditTime;
        private string _IdentityCard;
        private int _IdentityIsAudit;
        private byte _IsAudit;
        private int? _IsClose;
        private int? _IsDeleted;
        private int? _IsExpires;
        private byte? _IsHot;
        private int? _IsIntegralShop;
        private int _IsPayMentShop;
        private byte? _IsRecommend;
        private int _IsShowMap;
        private int? _IsSystemHot;
        private int? _IsSystemRecommend;
        private byte? _IsVisits;
        private int _IsWeiXin;
        private string _Latitude;
        private string _LegalPerson;
        private string _Longitude;
        private string _MainGoods;
        private int? _ManageBySite;
        private string _MemLoginID;
        private string _Memo;
        private DateTime? _ModifyTime;
        private string _ModifyUser;
        private string _Name;
        private DateTime? _OpenTime;
        private string _OperateUser;
        private int? _OrderID;
        private string _Phone;
        private string _PostalCode;
        private decimal _RegisteredCapital;
        private string _RegistrationNum;
        private string _SalesRange;
        private string _ShopBrandGuid;
        private string _ShopBrandName;
        private string _ShopCategory;
        private string _ShopCategoryID;
        private int _ShopID;
        private string _ShopIntroduce;
        private string _ShopName;
        private System.Guid _ShopRank;
        private int? _ShopReputation;
        private int? _ShopType;
        private string _ShopUrl;
        private string _SubstationID;
        private int? _SystemOrderID;
        private string _Tel;
        private string _TemplateType;
        private int? _wDepartTime;
        private DateTime? _wEndTime;
        private DateTime? _wOpenTime;
        private decimal? _wPayMoney;
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

        [Column(Storage="_Address", DbType="NVarChar(250)")]
        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                if (this._Address != value)
                {
                    this.SendPropertyChanging();
                    this._Address = value;
                    this.SendPropertyChanged("Address");
                }
            }
        }

        [Column(Storage="_AddressCode", DbType="NVarChar(50)")]
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

        [Column(Storage="_AddressValue", DbType="NVarChar(50)")]
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

        [Column(Storage="_ApplyTime", DbType="DateTime")]
        public DateTime? ApplyTime
        {
            get
            {
                return this._ApplyTime;
            }
            set
            {
                if (this._ApplyTime != value)
                {
                    this.SendPropertyChanging();
                    this._ApplyTime = value;
                    this.SendPropertyChanged("ApplyTime");
                }
            }
        }

        [Column(Storage="_AuditFailedReason", DbType="NVarChar(500)")]
        public string AuditFailedReason
        {
            get
            {
                return this._AuditFailedReason;
            }
            set
            {
                if (this._AuditFailedReason != value)
                {
                    this.SendPropertyChanging();
                    this._AuditFailedReason = value;
                    this.SendPropertyChanged("AuditFailedReason");
                }
            }
        }

        [Column(Storage="_AuditTime", DbType="DateTime")]
        public DateTime? AuditTime
        {
            get
            {
                return this._AuditTime;
            }
            set
            {
                if (this._AuditTime != value)
                {
                    this.SendPropertyChanging();
                    this._AuditTime = value;
                    this.SendPropertyChanged("AuditTime");
                }
            }
        }

        [Column(Storage="_Banner", DbType="NVarChar(250)")]
        public string Banner
        {
            get
            {
                return this._Banner;
            }
            set
            {
                if (this._Banner != value)
                {
                    this.SendPropertyChanging();
                    this._Banner = value;
                    this.SendPropertyChanged("Banner");
                }
            }
        }

        [Column(Storage="_BusinessLicense", DbType="NVarChar(500) NOT NULL", CanBeNull=false)]
        public string BusinessLicense
        {
            get
            {
                return this._BusinessLicense;
            }
            set
            {
                if (this._BusinessLicense != value)
                {
                    this.SendPropertyChanging();
                    this._BusinessLicense = value;
                    this.SendPropertyChanged("BusinessLicense");
                }
            }
        }

        [Column(Storage="_BusinessScope", DbType="NVarChar(200)")]
        public string BusinessScope
        {
            get
            {
                return this._BusinessScope;
            }
            set
            {
                if (this._BusinessScope != value)
                {
                    this.SendPropertyChanging();
                    this._BusinessScope = value;
                    this.SendPropertyChanged("BusinessScope");
                }
            }
        }

        [Column(Storage="_BusinessTerm", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string BusinessTerm
        {
            get
            {
                return this._BusinessTerm;
            }
            set
            {
                if (this._BusinessTerm != value)
                {
                    this.SendPropertyChanging();
                    this._BusinessTerm = value;
                    this.SendPropertyChanged("BusinessTerm");
                }
            }
        }

        [Column(Storage="_CardImage", DbType="NVarChar(50)")]
        public string CardImage
        {
            get
            {
                return this._CardImage;
            }
            set
            {
                if (this._CardImage != value)
                {
                    this.SendPropertyChanging();
                    this._CardImage = value;
                    this.SendPropertyChanged("CardImage");
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

        [Column(Storage="_CompanAuditFailedReason", DbType="NVarChar(800)")]
        public string CompanAuditFailedReason
        {
            get
            {
                return this._CompanAuditFailedReason;
            }
            set
            {
                if (this._CompanAuditFailedReason != value)
                {
                    this.SendPropertyChanging();
                    this._CompanAuditFailedReason = value;
                    this.SendPropertyChanged("CompanAuditFailedReason");
                }
            }
        }

        [Column(Storage="_CompanAuditTime", DbType="DateTime")]
        public DateTime? CompanAuditTime
        {
            get
            {
                return this._CompanAuditTime;
            }
            set
            {
                if (this._CompanAuditTime != value)
                {
                    this.SendPropertyChanging();
                    this._CompanAuditTime = value;
                    this.SendPropertyChanged("CompanAuditTime");
                }
            }
        }

        [Column(Storage="_CompanIsAudit", DbType="Int NOT NULL")]
        public int CompanIsAudit
        {
            get
            {
                return this._CompanIsAudit;
            }
            set
            {
                if (this._CompanIsAudit != value)
                {
                    this.SendPropertyChanging();
                    this._CompanIsAudit = value;
                    this.SendPropertyChanged("CompanIsAudit");
                }
            }
        }

        [Column(Storage="_CompanName", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
        public string CompanName
        {
            get
            {
                return this._CompanName;
            }
            set
            {
                if (this._CompanName != value)
                {
                    this.SendPropertyChanging();
                    this._CompanName = value;
                    this.SendPropertyChanged("CompanName");
                }
            }
        }

        [Column(Storage="_CompanyIntroduce", DbType="NVarChar(MAX)")]
        public string CompanyIntroduce
        {
            get
            {
                return this._CompanyIntroduce;
            }
            set
            {
                if (this._CompanyIntroduce != value)
                {
                    this.SendPropertyChanging();
                    this._CompanyIntroduce = value;
                    this.SendPropertyChanged("CompanyIntroduce");
                }
            }
        }

        [Column(Storage="_Email", DbType="NVarChar(100)")]
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                if (this._Email != value)
                {
                    this.SendPropertyChanging();
                    this._Email = value;
                    this.SendPropertyChanged("Email");
                }
            }
        }

        [Column(Storage="_EnsureID", DbType="NVarChar(50)")]
        public string EnsureID
        {
            get
            {
                return this._EnsureID;
            }
            set
            {
                if (this._EnsureID != value)
                {
                    this.SendPropertyChanging();
                    this._EnsureID = value;
                    this.SendPropertyChanged("EnsureID");
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

        [Column(Storage="_IdentityAuditTime", DbType="DateTime")]
        public DateTime? IdentityAuditTime
        {
            get
            {
                return this._IdentityAuditTime;
            }
            set
            {
                if (this._IdentityAuditTime != value)
                {
                    this.SendPropertyChanging();
                    this._IdentityAuditTime = value;
                    this.SendPropertyChanged("IdentityAuditTime");
                }
            }
        }

        [Column(Storage="_IdentityCard", DbType="NVarChar(50)")]
        public string IdentityCard
        {
            get
            {
                return this._IdentityCard;
            }
            set
            {
                if (this._IdentityCard != value)
                {
                    this.SendPropertyChanging();
                    this._IdentityCard = value;
                    this.SendPropertyChanged("IdentityCard");
                }
            }
        }

        [Column(Storage="_IdentityIsAudit", DbType="Int NOT NULL")]
        public int IdentityIsAudit
        {
            get
            {
                return this._IdentityIsAudit;
            }
            set
            {
                if (this._IdentityIsAudit != value)
                {
                    this.SendPropertyChanging();
                    this._IdentityIsAudit = value;
                    this.SendPropertyChanged("IdentityIsAudit");
                }
            }
        }

        [Column(Storage="_IsAudit", DbType="TinyInt NOT NULL")]
        public byte IsAudit
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

        [Column(Storage="_IsClose", DbType="Int")]
        public int? IsClose
        {
            get
            {
                return this._IsClose;
            }
            set
            {
                if (this._IsClose != value)
                {
                    this.SendPropertyChanging();
                    this._IsClose = value;
                    this.SendPropertyChanged("IsClose");
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

        [Column(Storage="_IsExpires", DbType="Int")]
        public int? IsExpires
        {
            get
            {
                return this._IsExpires;
            }
            set
            {
                if (this._IsExpires != value)
                {
                    this.SendPropertyChanging();
                    this._IsExpires = value;
                    this.SendPropertyChanged("IsExpires");
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
                    this.SendPropertyChanging();
                    this._IsHot = value;
                    this.SendPropertyChanged("IsHot");
                }
            }
        }

        [Column(Storage="_IsIntegralShop", DbType="Int")]
        public int? IsIntegralShop
        {
            get
            {
                return this._IsIntegralShop;
            }
            set
            {
                if (this._IsIntegralShop != value)
                {
                    this.SendPropertyChanging();
                    this._IsIntegralShop = value;
                    this.SendPropertyChanged("IsIntegralShop");
                }
            }
        }

        [Column(Storage="_IsPayMentShop", DbType="Int NOT NULL")]
        public int IsPayMentShop
        {
            get
            {
                return this._IsPayMentShop;
            }
            set
            {
                if (this._IsPayMentShop != value)
                {
                    this.SendPropertyChanging();
                    this._IsPayMentShop = value;
                    this.SendPropertyChanged("IsPayMentShop");
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
                    this.SendPropertyChanging();
                    this._IsRecommend = value;
                    this.SendPropertyChanged("IsRecommend");
                }
            }
        }

        [Column(Storage="_IsShowMap", DbType="Int NOT NULL")]
        public int IsShowMap
        {
            get
            {
                return this._IsShowMap;
            }
            set
            {
                if (this._IsShowMap != value)
                {
                    this.SendPropertyChanging();
                    this._IsShowMap = value;
                    this.SendPropertyChanged("IsShowMap");
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

        [Column(Storage="_IsVisits", DbType="TinyInt")]
        public byte? IsVisits
        {
            get
            {
                return this._IsVisits;
            }
            set
            {
                if (this._IsVisits != value)
                {
                    this.SendPropertyChanging();
                    this._IsVisits = value;
                    this.SendPropertyChanged("IsVisits");
                }
            }
        }

        [Column(Storage="_IsWeiXin", DbType="Int NOT NULL")]
        public int IsWeiXin
        {
            get
            {
                return this._IsWeiXin;
            }
            set
            {
                if (this._IsWeiXin != value)
                {
                    this.SendPropertyChanging();
                    this._IsWeiXin = value;
                    this.SendPropertyChanged("IsWeiXin");
                }
            }
        }

        [Column(Storage="_Latitude", DbType="NVarChar(50)")]
        public string Latitude
        {
            get
            {
                return this._Latitude;
            }
            set
            {
                if (this._Latitude != value)
                {
                    this.SendPropertyChanging();
                    this._Latitude = value;
                    this.SendPropertyChanged("Latitude");
                }
            }
        }

        [Column(Storage="_LegalPerson", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string LegalPerson
        {
            get
            {
                return this._LegalPerson;
            }
            set
            {
                if (this._LegalPerson != value)
                {
                    this.SendPropertyChanging();
                    this._LegalPerson = value;
                    this.SendPropertyChanged("LegalPerson");
                }
            }
        }

        [Column(Storage="_Longitude", DbType="NVarChar(50)")]
        public string Longitude
        {
            get
            {
                return this._Longitude;
            }
            set
            {
                if (this._Longitude != value)
                {
                    this.SendPropertyChanging();
                    this._Longitude = value;
                    this.SendPropertyChanged("Longitude");
                }
            }
        }

        [Column(Storage="_MainGoods", DbType="NVarChar(MAX)")]
        public string MainGoods
        {
            get
            {
                return this._MainGoods;
            }
            set
            {
                if (this._MainGoods != value)
                {
                    this.SendPropertyChanging();
                    this._MainGoods = value;
                    this.SendPropertyChanged("MainGoods");
                }
            }
        }

        [Column(Storage="_ManageBySite", DbType="Int")]
        public int? ManageBySite
        {
            get
            {
                return this._ManageBySite;
            }
            set
            {
                if (this._ManageBySite != value)
                {
                    this.SendPropertyChanging();
                    this._ManageBySite = value;
                    this.SendPropertyChanged("ManageBySite");
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

        [Column(Storage="_Memo", DbType="NVarChar(1000)")]
        public string Memo
        {
            get
            {
                return this._Memo;
            }
            set
            {
                if (this._Memo != value)
                {
                    this.SendPropertyChanging();
                    this._Memo = value;
                    this.SendPropertyChanged("Memo");
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

        [Column(Storage="_Name", DbType="NVarChar(50)")]
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

        [Column(Storage="_OpenTime", DbType="DateTime")]
        public DateTime? OpenTime
        {
            get
            {
                return this._OpenTime;
            }
            set
            {
                if (this._OpenTime != value)
                {
                    this.SendPropertyChanging();
                    this._OpenTime = value;
                    this.SendPropertyChanged("OpenTime");
                }
            }
        }

        [Column(Storage="_OperateUser", DbType="NVarChar(50)")]
        public string OperateUser
        {
            get
            {
                return this._OperateUser;
            }
            set
            {
                if (this._OperateUser != value)
                {
                    this.SendPropertyChanging();
                    this._OperateUser = value;
                    this.SendPropertyChanged("OperateUser");
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

        [Column(Storage="_Phone", DbType="NVarChar(25)")]
        public string Phone
        {
            get
            {
                return this._Phone;
            }
            set
            {
                if (this._Phone != value)
                {
                    this.SendPropertyChanging();
                    this._Phone = value;
                    this.SendPropertyChanged("Phone");
                }
            }
        }

        [Column(Storage="_PostalCode", DbType="NVarChar(50)")]
        public string PostalCode
        {
            get
            {
                return this._PostalCode;
            }
            set
            {
                if (this._PostalCode != value)
                {
                    this.SendPropertyChanging();
                    this._PostalCode = value;
                    this.SendPropertyChanged("PostalCode");
                }
            }
        }

        [Column(Storage="_RegisteredCapital", DbType="Decimal(18,2) NOT NULL")]
        public decimal RegisteredCapital
        {
            get
            {
                return this._RegisteredCapital;
            }
            set
            {
                if (this._RegisteredCapital != value)
                {
                    this.SendPropertyChanging();
                    this._RegisteredCapital = value;
                    this.SendPropertyChanged("RegisteredCapital");
                }
            }
        }

        [Column(Storage="_RegistrationNum", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
        public string RegistrationNum
        {
            get
            {
                return this._RegistrationNum;
            }
            set
            {
                if (this._RegistrationNum != value)
                {
                    this.SendPropertyChanging();
                    this._RegistrationNum = value;
                    this.SendPropertyChanged("RegistrationNum");
                }
            }
        }

        [Column(Storage="_SalesRange", DbType="NVarChar(150) NOT NULL", CanBeNull=false)]
        public string SalesRange
        {
            get
            {
                return this._SalesRange;
            }
            set
            {
                if (this._SalesRange != value)
                {
                    this.SendPropertyChanging();
                    this._SalesRange = value;
                    this.SendPropertyChanged("SalesRange");
                }
            }
        }

        [Column(Storage="_ShopBrandGuid", DbType="NChar(50)")]
        public string ShopBrandGuid
        {
            get
            {
                return this._ShopBrandGuid;
            }
            set
            {
                if (this._ShopBrandGuid != value)
                {
                    this.SendPropertyChanging();
                    this._ShopBrandGuid = value;
                    this.SendPropertyChanged("ShopBrandGuid");
                }
            }
        }

        [Column(Storage="_ShopBrandName", DbType="NChar(100)")]
        public string ShopBrandName
        {
            get
            {
                return this._ShopBrandName;
            }
            set
            {
                if (this._ShopBrandName != value)
                {
                    this.SendPropertyChanging();
                    this._ShopBrandName = value;
                    this.SendPropertyChanged("ShopBrandName");
                }
            }
        }

        [Column(Storage="_ShopCategory", DbType="VarChar(50)")]
        public string ShopCategory
        {
            get
            {
                return this._ShopCategory;
            }
            set
            {
                if (this._ShopCategory != value)
                {
                    this.SendPropertyChanging();
                    this._ShopCategory = value;
                    this.SendPropertyChanged("ShopCategory");
                }
            }
        }

        [Column(Storage="_ShopCategoryID", DbType="NVarChar(50)")]
        public string ShopCategoryID
        {
            get
            {
                return this._ShopCategoryID;
            }
            set
            {
                if (this._ShopCategoryID != value)
                {
                    this.SendPropertyChanging();
                    this._ShopCategoryID = value;
                    this.SendPropertyChanged("ShopCategoryID");
                }
            }
        }

        [Column(Storage="_ShopID", DbType="Int NOT NULL")]
        public int ShopID
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

        [Column(Storage="_ShopIntroduce", DbType="NText", UpdateCheck=UpdateCheck.Never)]
        public string ShopIntroduce
        {
            get
            {
                return this._ShopIntroduce;
            }
            set
            {
                if (this._ShopIntroduce != value)
                {
                    this.SendPropertyChanging();
                    this._ShopIntroduce = value;
                    this.SendPropertyChanged("ShopIntroduce");
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

        [Column(Storage="_ShopRank", DbType="UniqueIdentifier NOT NULL")]
        public System.Guid ShopRank
        {
            get
            {
                return this._ShopRank;
            }
            set
            {
                if (this._ShopRank != value)
                {
                    this.SendPropertyChanging();
                    this._ShopRank = value;
                    this.SendPropertyChanged("ShopRank");
                }
            }
        }

        [Column(Storage="_ShopReputation", DbType="Int")]
        public int? ShopReputation
        {
            get
            {
                return this._ShopReputation;
            }
            set
            {
                if (this._ShopReputation != value)
                {
                    this.SendPropertyChanging();
                    this._ShopReputation = value;
                    this.SendPropertyChanged("ShopReputation");
                }
            }
        }

        [Column(Storage="_ShopType", DbType="Int")]
        public int? ShopType
        {
            get
            {
                return this._ShopType;
            }
            set
            {
                if (this._ShopType != value)
                {
                    this.SendPropertyChanging();
                    this._ShopType = value;
                    this.SendPropertyChanged("ShopType");
                }
            }
        }

        [Column(Storage="_ShopUrl", DbType="VarChar(50)")]
        public string ShopUrl
        {
            get
            {
                return this._ShopUrl;
            }
            set
            {
                if (this._ShopUrl != value)
                {
                    this.SendPropertyChanging();
                    this._ShopUrl = value;
                    this.SendPropertyChanged("ShopUrl");
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

        [Column(Storage="_Tel", DbType="NVarChar(25)")]
        public string Tel
        {
            get
            {
                return this._Tel;
            }
            set
            {
                if (this._Tel != value)
                {
                    this.SendPropertyChanging();
                    this._Tel = value;
                    this.SendPropertyChanged("Tel");
                }
            }
        }

        [Column(Storage="_TemplateType", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string TemplateType
        {
            get
            {
                return this._TemplateType;
            }
            set
            {
                if (this._TemplateType != value)
                {
                    this.SendPropertyChanging();
                    this._TemplateType = value;
                    this.SendPropertyChanged("TemplateType");
                }
            }
        }

        [Column(Storage="_wDepartTime", DbType="Int")]
        public int? wDepartTime
        {
            get
            {
                return this._wDepartTime;
            }
            set
            {
                if (this._wDepartTime != value)
                {
                    this.SendPropertyChanging();
                    this._wDepartTime = value;
                    this.SendPropertyChanged("wDepartTime");
                }
            }
        }

        [Column(Storage="_wEndTime", DbType="DateTime")]
        public DateTime? wEndTime
        {
            get
            {
                return this._wEndTime;
            }
            set
            {
                if (this._wEndTime != value)
                {
                    this.SendPropertyChanging();
                    this._wEndTime = value;
                    this.SendPropertyChanged("wEndTime");
                }
            }
        }

        [Column(Storage="_wOpenTime", DbType="DateTime")]
        public DateTime? wOpenTime
        {
            get
            {
                return this._wOpenTime;
            }
            set
            {
                if (this._wOpenTime != value)
                {
                    this.SendPropertyChanging();
                    this._wOpenTime = value;
                    this.SendPropertyChanged("wOpenTime");
                }
            }
        }

        [Column(Storage="_wPayMoney", DbType="Decimal(18,2)")]
        public decimal? wPayMoney
        {
            get
            {
                return this._wPayMoney;
            }
            set
            {
                decimal? nullable = this._wPayMoney;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._wPayMoney = value;
                    this.SendPropertyChanged("wPayMoney");
                }
            }
        }
    }
}

