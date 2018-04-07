namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_OrderInfo")]
    public class ShopNum1_OrderInfo : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private System.Guid? _ActivityGuid;
        private string _ActvieContent;
        private string _Address;
        private long? _AlipayTradeId;
        private decimal _AlreadPayPrice;
        private string _BlessCardContent;
        private System.Guid? _BlessCardGuid;
        private string _BlessCardName;
        private decimal _BlessCardPrice;
        private byte? _BuyIsDeleted;
        private string _BuyType;
        private string _CancelReason;
        private string _ClientToSellerMsg;
        private DateTime? _ConfirmTime;
        private DateTime? _CreateTime;
        private decimal? _Deposit;
        private decimal _Discount;
        private decimal? _DispatchPrice;
        private DateTime? _DispatchTime;
        private int? _DispatchType;
        private string _Email;
        private DateTime? _EndTime;
        private int? _FeeType;
        private System.Guid? _FromAd;
        private string _FromUrl;
        private System.Guid _Guid;
        private string _identifycode;
        private string _InvoiceContent;
        private decimal _InvoiceTax;
        private string _InvoiceTitle;
        private string _InvoiceType;
        private byte? _IsBuyComment;
        private byte? _IsDeleted;
        private int? _IsLogistics;
        private int _IsMemdelay;
        private int _IsMinus;
        private byte? _IsSellComment;
        private int? _JoinActiveType;
        private string _LogisticsCompany;
        private string _LogisticsCompanyCode;
        private string _MemLoginID;
        private string _Mobile;
        private string _Name;
        private int _OderStatus;
        private string _OrderNumber;
        private byte? _OrderType;
        private string _OutOfStockOperate;
        private System.Guid? _PackGuid;
        private string _PackName;
        private decimal _PackPrice;
        private string _PayMemo;
        private System.Guid? _PaymentGuid;
        private string _PayMentMemLoginID;
        private string _PaymentName;
        private decimal? _PaymentPrice;
        private int _PaymentStatus;
        private DateTime? _PayTime;
        private string _Postalcode;
        private decimal? _ProductPrice;
        private DateTime? _ReceiptTime;
        private int _ReceivedDays;
        private decimal? _RecommendCommision;
        private int? _refundStatus;
        private string _RegionCode;
        private decimal? _ScorePrice;
        private string _SellerToClientMsg;
        private byte? _SellIsDeleted;
        private string _ShipmentNumber;
        private int _ShipmentStatus;
        private string _ShopID;
        private string _ShopName;
        private decimal? _ShouldPayPrice;
        private string _SubstationID;
        private decimal _SurplusPrice;
        private string _Tel;
        private string _TradeID;
        private string _UsedFavourTicket;
        private int _UseScore;
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

        [Column(Storage="_ActivityGuid", DbType="UniqueIdentifier")]
        public System.Guid? ActivityGuid
        {
            get
            {
                return this._ActivityGuid;
            }
            set
            {
                if (this._ActivityGuid != value)
                {
                    this.SendPropertyChanging();
                    this._ActivityGuid = value;
                    this.SendPropertyChanged("ActivityGuid");
                }
            }
        }

        [Column(Storage="_ActvieContent", DbType="NVarChar(50)")]
        public string ActvieContent
        {
            get
            {
                return this._ActvieContent;
            }
            set
            {
                if (this._ActvieContent != value)
                {
                    this.SendPropertyChanging();
                    this._ActvieContent = value;
                    this.SendPropertyChanged("ActvieContent");
                }
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

        [Column(Storage="_AlipayTradeId", DbType="BigInt")]
        public long? AlipayTradeId
        {
            get
            {
                return this._AlipayTradeId;
            }
            set
            {
                if (this._AlipayTradeId != value)
                {
                    this.SendPropertyChanging();
                    this._AlipayTradeId = value;
                    this.SendPropertyChanged("AlipayTradeId");
                }
            }
        }

        [Column(Storage="_AlreadPayPrice", DbType="Decimal(18,2) NOT NULL")]
        public decimal AlreadPayPrice
        {
            get
            {
                return this._AlreadPayPrice;
            }
            set
            {
                if (this._AlreadPayPrice != value)
                {
                    this.SendPropertyChanging();
                    this._AlreadPayPrice = value;
                    this.SendPropertyChanged("AlreadPayPrice");
                }
            }
        }

        [Column(Storage="_BlessCardContent", DbType="NVarChar(4000)")]
        public string BlessCardContent
        {
            get
            {
                return this._BlessCardContent;
            }
            set
            {
                if (this._BlessCardContent != value)
                {
                    this.SendPropertyChanging();
                    this._BlessCardContent = value;
                    this.SendPropertyChanged("BlessCardContent");
                }
            }
        }

        [Column(Storage="_BlessCardGuid", DbType="UniqueIdentifier")]
        public System.Guid? BlessCardGuid
        {
            get
            {
                return this._BlessCardGuid;
            }
            set
            {
                if (this._BlessCardGuid != value)
                {
                    this.SendPropertyChanging();
                    this._BlessCardGuid = value;
                    this.SendPropertyChanged("BlessCardGuid");
                }
            }
        }

        [Column(Storage="_BlessCardName", DbType="NVarChar(50)")]
        public string BlessCardName
        {
            get
            {
                return this._BlessCardName;
            }
            set
            {
                if (this._BlessCardName != value)
                {
                    this.SendPropertyChanging();
                    this._BlessCardName = value;
                    this.SendPropertyChanged("BlessCardName");
                }
            }
        }

        [Column(Storage="_BlessCardPrice", DbType="Decimal(18,2) NOT NULL")]
        public decimal BlessCardPrice
        {
            get
            {
                return this._BlessCardPrice;
            }
            set
            {
                if (this._BlessCardPrice != value)
                {
                    this.SendPropertyChanging();
                    this._BlessCardPrice = value;
                    this.SendPropertyChanged("BlessCardPrice");
                }
            }
        }

        [Column(Storage="_BuyIsDeleted", DbType="TinyInt")]
        public byte? BuyIsDeleted
        {
            get
            {
                return this._BuyIsDeleted;
            }
            set
            {
                if (this._BuyIsDeleted != value)
                {
                    this.SendPropertyChanging();
                    this._BuyIsDeleted = value;
                    this.SendPropertyChanged("BuyIsDeleted");
                }
            }
        }

        [Column(Storage="_BuyType", DbType="NVarChar(50)")]
        public string BuyType
        {
            get
            {
                return this._BuyType;
            }
            set
            {
                if (this._BuyType != value)
                {
                    this.SendPropertyChanging();
                    this._BuyType = value;
                    this.SendPropertyChanged("BuyType");
                }
            }
        }

        [Column(Storage="_CancelReason", DbType="NVarChar(500)")]
        public string CancelReason
        {
            get
            {
                return this._CancelReason;
            }
            set
            {
                if (this._CancelReason != value)
                {
                    this.SendPropertyChanging();
                    this._CancelReason = value;
                    this.SendPropertyChanged("CancelReason");
                }
            }
        }

        [Column(Storage="_ClientToSellerMsg", DbType="NVarChar(500)")]
        public string ClientToSellerMsg
        {
            get
            {
                return this._ClientToSellerMsg;
            }
            set
            {
                if (this._ClientToSellerMsg != value)
                {
                    this.SendPropertyChanging();
                    this._ClientToSellerMsg = value;
                    this.SendPropertyChanged("ClientToSellerMsg");
                }
            }
        }

        [Column(Storage="_ConfirmTime", DbType="DateTime")]
        public DateTime? ConfirmTime
        {
            get
            {
                return this._ConfirmTime;
            }
            set
            {
                if (this._ConfirmTime != value)
                {
                    this.SendPropertyChanging();
                    this._ConfirmTime = value;
                    this.SendPropertyChanged("ConfirmTime");
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

        [Column(Storage="_Deposit", DbType="Decimal(18,2)")]
        public decimal? Deposit
        {
            get
            {
                return this._Deposit;
            }
            set
            {
                decimal? nullable = this._Deposit;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._Deposit = value;
                    this.SendPropertyChanged("Deposit");
                }
            }
        }

        [Column(Storage="_Discount", DbType="Decimal(18,2) NOT NULL")]
        public decimal Discount
        {
            get
            {
                return this._Discount;
            }
            set
            {
                if (this._Discount != value)
                {
                    this.SendPropertyChanging();
                    this._Discount = value;
                    this.SendPropertyChanged("Discount");
                }
            }
        }

        [Column(Storage="_DispatchPrice", DbType="Decimal(18,2)")]
        public decimal? DispatchPrice
        {
            get
            {
                return this._DispatchPrice;
            }
            set
            {
                decimal? nullable = this._DispatchPrice;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._DispatchPrice = value;
                    this.SendPropertyChanged("DispatchPrice");
                }
            }
        }

        [Column(Storage="_DispatchTime", DbType="DateTime")]
        public DateTime? DispatchTime
        {
            get
            {
                return this._DispatchTime;
            }
            set
            {
                if (this._DispatchTime != value)
                {
                    this.SendPropertyChanging();
                    this._DispatchTime = value;
                    this.SendPropertyChanged("DispatchTime");
                }
            }
        }

        [Column(Storage="_DispatchType", DbType="Int")]
        public int? DispatchType
        {
            get
            {
                return this._DispatchType;
            }
            set
            {
                if (this._DispatchType != value)
                {
                    this.SendPropertyChanging();
                    this._DispatchType = value;
                    this.SendPropertyChanged("DispatchType");
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

        [Column(Storage="_FeeType", DbType="Int")]
        public int? FeeType
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

        [Column(Storage="_FromAd", DbType="UniqueIdentifier")]
        public System.Guid? FromAd
        {
            get
            {
                return this._FromAd;
            }
            set
            {
                if (this._FromAd != value)
                {
                    this.SendPropertyChanging();
                    this._FromAd = value;
                    this.SendPropertyChanged("FromAd");
                }
            }
        }

        [Column(Storage="_FromUrl", DbType="NVarChar(250)")]
        public string FromUrl
        {
            get
            {
                return this._FromUrl;
            }
            set
            {
                if (this._FromUrl != value)
                {
                    this.SendPropertyChanging();
                    this._FromUrl = value;
                    this.SendPropertyChanged("FromUrl");
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

        [Column(Storage="_identifycode", DbType="NVarChar(50)")]
        public string identifycode
        {
            get
            {
                return this._identifycode;
            }
            set
            {
                if (this._identifycode != value)
                {
                    this.SendPropertyChanging();
                    this._identifycode = value;
                    this.SendPropertyChanged("identifycode");
                }
            }
        }

        [Column(Storage="_InvoiceContent", DbType="NVarChar(50)")]
        public string InvoiceContent
        {
            get
            {
                return this._InvoiceContent;
            }
            set
            {
                if (this._InvoiceContent != value)
                {
                    this.SendPropertyChanging();
                    this._InvoiceContent = value;
                    this.SendPropertyChanged("InvoiceContent");
                }
            }
        }

        [Column(Storage="_InvoiceTax", DbType="Decimal(18,2) NOT NULL")]
        public decimal InvoiceTax
        {
            get
            {
                return this._InvoiceTax;
            }
            set
            {
                if (this._InvoiceTax != value)
                {
                    this.SendPropertyChanging();
                    this._InvoiceTax = value;
                    this.SendPropertyChanged("InvoiceTax");
                }
            }
        }

        [Column(Storage="_InvoiceTitle", DbType="NVarChar(50)")]
        public string InvoiceTitle
        {
            get
            {
                return this._InvoiceTitle;
            }
            set
            {
                if (this._InvoiceTitle != value)
                {
                    this.SendPropertyChanging();
                    this._InvoiceTitle = value;
                    this.SendPropertyChanged("InvoiceTitle");
                }
            }
        }

        [Column(Storage="_InvoiceType", DbType="NVarChar(50)")]
        public string InvoiceType
        {
            get
            {
                return this._InvoiceType;
            }
            set
            {
                if (this._InvoiceType != value)
                {
                    this.SendPropertyChanging();
                    this._InvoiceType = value;
                    this.SendPropertyChanged("InvoiceType");
                }
            }
        }

        [Column(Storage="_IsBuyComment", DbType="TinyInt")]
        public byte? IsBuyComment
        {
            get
            {
                return this._IsBuyComment;
            }
            set
            {
                if (this._IsBuyComment != value)
                {
                    this.SendPropertyChanging();
                    this._IsBuyComment = value;
                    this.SendPropertyChanged("IsBuyComment");
                }
            }
        }

        [Column(Storage="_IsDeleted", DbType="TinyInt")]
        public byte? IsDeleted
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

        [Column(Storage="_IsLogistics", DbType="Int")]
        public int? IsLogistics
        {
            get
            {
                return this._IsLogistics;
            }
            set
            {
                if (this._IsLogistics != value)
                {
                    this.SendPropertyChanging();
                    this._IsLogistics = value;
                    this.SendPropertyChanged("IsLogistics");
                }
            }
        }

        [Column(Storage="_IsMemdelay", DbType="Int NOT NULL")]
        public int IsMemdelay
        {
            get
            {
                return this._IsMemdelay;
            }
            set
            {
                if (this._IsMemdelay != value)
                {
                    this.SendPropertyChanging();
                    this._IsMemdelay = value;
                    this.SendPropertyChanged("IsMemdelay");
                }
            }
        }

        [Column(Storage="_IsMinus", DbType="Int NOT NULL")]
        public int IsMinus
        {
            get
            {
                return this._IsMinus;
            }
            set
            {
                if (this._IsMinus != value)
                {
                    this.SendPropertyChanging();
                    this._IsMinus = value;
                    this.SendPropertyChanged("IsMinus");
                }
            }
        }

        [Column(Storage="_IsSellComment", DbType="TinyInt")]
        public byte? IsSellComment
        {
            get
            {
                return this._IsSellComment;
            }
            set
            {
                if (this._IsSellComment != value)
                {
                    this.SendPropertyChanging();
                    this._IsSellComment = value;
                    this.SendPropertyChanged("IsSellComment");
                }
            }
        }

        [Column(Storage="_JoinActiveType", DbType="Int")]
        public int? JoinActiveType
        {
            get
            {
                return this._JoinActiveType;
            }
            set
            {
                if (this._JoinActiveType != value)
                {
                    this.SendPropertyChanging();
                    this._JoinActiveType = value;
                    this.SendPropertyChanged("JoinActiveType");
                }
            }
        }

        [Column(Storage="_LogisticsCompany", DbType="NVarChar(50)")]
        public string LogisticsCompany
        {
            get
            {
                return this._LogisticsCompany;
            }
            set
            {
                if (this._LogisticsCompany != value)
                {
                    this.SendPropertyChanging();
                    this._LogisticsCompany = value;
                    this.SendPropertyChanged("LogisticsCompany");
                }
            }
        }

        [Column(Storage="_LogisticsCompanyCode", DbType="NVarChar(50)")]
        public string LogisticsCompanyCode
        {
            get
            {
                return this._LogisticsCompanyCode;
            }
            set
            {
                if (this._LogisticsCompanyCode != value)
                {
                    this.SendPropertyChanging();
                    this._LogisticsCompanyCode = value;
                    this.SendPropertyChanged("LogisticsCompanyCode");
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

        [Column(Storage="_Mobile", DbType="NVarChar(20)")]
        public string Mobile
        {
            get
            {
                return this._Mobile;
            }
            set
            {
                if (this._Mobile != value)
                {
                    this.SendPropertyChanging();
                    this._Mobile = value;
                    this.SendPropertyChanged("Mobile");
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

        [Column(Storage="_OderStatus", DbType="Int NOT NULL")]
        public int OderStatus
        {
            get
            {
                return this._OderStatus;
            }
            set
            {
                if (this._OderStatus != value)
                {
                    this.SendPropertyChanging();
                    this._OderStatus = value;
                    this.SendPropertyChanged("OderStatus");
                }
            }
        }

        [Column(Storage="_OrderNumber", DbType="NVarChar(50)")]
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

        [Column(Storage="_OrderType", DbType="TinyInt")]
        public byte? OrderType
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

        [Column(Storage="_OutOfStockOperate", DbType="NVarChar(50)")]
        public string OutOfStockOperate
        {
            get
            {
                return this._OutOfStockOperate;
            }
            set
            {
                if (this._OutOfStockOperate != value)
                {
                    this.SendPropertyChanging();
                    this._OutOfStockOperate = value;
                    this.SendPropertyChanged("OutOfStockOperate");
                }
            }
        }

        [Column(Storage="_PackGuid", DbType="UniqueIdentifier")]
        public System.Guid? PackGuid
        {
            get
            {
                return this._PackGuid;
            }
            set
            {
                if (this._PackGuid != value)
                {
                    this.SendPropertyChanging();
                    this._PackGuid = value;
                    this.SendPropertyChanged("PackGuid");
                }
            }
        }

        [Column(Storage="_PackName", DbType="NVarChar(50)")]
        public string PackName
        {
            get
            {
                return this._PackName;
            }
            set
            {
                if (this._PackName != value)
                {
                    this.SendPropertyChanging();
                    this._PackName = value;
                    this.SendPropertyChanged("PackName");
                }
            }
        }

        [Column(Storage="_PackPrice", DbType="Decimal(18,2) NOT NULL")]
        public decimal PackPrice
        {
            get
            {
                return this._PackPrice;
            }
            set
            {
                if (this._PackPrice != value)
                {
                    this.SendPropertyChanging();
                    this._PackPrice = value;
                    this.SendPropertyChanged("PackPrice");
                }
            }
        }

        [Column(Storage="_PayMemo", DbType="NVarChar(500)")]
        public string PayMemo
        {
            get
            {
                return this._PayMemo;
            }
            set
            {
                if (this._PayMemo != value)
                {
                    this.SendPropertyChanging();
                    this._PayMemo = value;
                    this.SendPropertyChanged("PayMemo");
                }
            }
        }

        [Column(Storage="_PaymentGuid", DbType="UniqueIdentifier")]
        public System.Guid? PaymentGuid
        {
            get
            {
                return this._PaymentGuid;
            }
            set
            {
                if (this._PaymentGuid != value)
                {
                    this.SendPropertyChanging();
                    this._PaymentGuid = value;
                    this.SendPropertyChanged("PaymentGuid");
                }
            }
        }

        [Column(Storage="_PayMentMemLoginID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string PayMentMemLoginID
        {
            get
            {
                return this._PayMentMemLoginID;
            }
            set
            {
                if (this._PayMentMemLoginID != value)
                {
                    this.SendPropertyChanging();
                    this._PayMentMemLoginID = value;
                    this.SendPropertyChanged("PayMentMemLoginID");
                }
            }
        }

        [Column(Storage="_PaymentName", DbType="NVarChar(50)")]
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
                    this.SendPropertyChanging();
                    this._PaymentName = value;
                    this.SendPropertyChanged("PaymentName");
                }
            }
        }

        [Column(Storage="_PaymentPrice", DbType="Decimal(18,2)")]
        public decimal? PaymentPrice
        {
            get
            {
                return this._PaymentPrice;
            }
            set
            {
                decimal? nullable = this._PaymentPrice;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._PaymentPrice = value;
                    this.SendPropertyChanged("PaymentPrice");
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
                    this.SendPropertyChanging();
                    this._PaymentStatus = value;
                    this.SendPropertyChanged("PaymentStatus");
                }
            }
        }

        [Column(Storage="_PayTime", DbType="DateTime")]
        public DateTime? PayTime
        {
            get
            {
                return this._PayTime;
            }
            set
            {
                if (this._PayTime != value)
                {
                    this.SendPropertyChanging();
                    this._PayTime = value;
                    this.SendPropertyChanged("PayTime");
                }
            }
        }

        [Column(Storage="_Postalcode", DbType="NVarChar(20)")]
        public string Postalcode
        {
            get
            {
                return this._Postalcode;
            }
            set
            {
                if (this._Postalcode != value)
                {
                    this.SendPropertyChanging();
                    this._Postalcode = value;
                    this.SendPropertyChanged("Postalcode");
                }
            }
        }

        [Column(Storage="_ProductPrice", DbType="Decimal(18,2)")]
        public decimal? ProductPrice
        {
            get
            {
                return this._ProductPrice;
            }
            set
            {
                decimal? nullable = this._ProductPrice;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._ProductPrice = value;
                    this.SendPropertyChanged("ProductPrice");
                }
            }
        }

        [Column(Storage="_ReceiptTime", DbType="DateTime")]
        public DateTime? ReceiptTime
        {
            get
            {
                return this._ReceiptTime;
            }
            set
            {
                if (this._ReceiptTime != value)
                {
                    this.SendPropertyChanging();
                    this._ReceiptTime = value;
                    this.SendPropertyChanged("ReceiptTime");
                }
            }
        }

        [Column(Storage="_ReceivedDays", DbType="Int NOT NULL")]
        public int ReceivedDays
        {
            get
            {
                return this._ReceivedDays;
            }
            set
            {
                if (this._ReceivedDays != value)
                {
                    this.SendPropertyChanging();
                    this._ReceivedDays = value;
                    this.SendPropertyChanged("ReceivedDays");
                }
            }
        }

        [Column(Storage="_RecommendCommision", DbType="Decimal(18,2)")]
        public decimal? RecommendCommision
        {
            get
            {
                return this._RecommendCommision;
            }
            set
            {
                decimal? nullable = this._RecommendCommision;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._RecommendCommision = value;
                    this.SendPropertyChanged("RecommendCommision");
                }
            }
        }

        [Column(Storage="_refundStatus", DbType="Int")]
        public int? refundStatus
        {
            get
            {
                return this._refundStatus;
            }
            set
            {
                if (this._refundStatus != value)
                {
                    this.SendPropertyChanging();
                    this._refundStatus = value;
                    this.SendPropertyChanged("refundStatus");
                }
            }
        }

        [Column(Storage="_RegionCode", DbType="VarChar(50)")]
        public string RegionCode
        {
            get
            {
                return this._RegionCode;
            }
            set
            {
                if (this._RegionCode != value)
                {
                    this.SendPropertyChanging();
                    this._RegionCode = value;
                    this.SendPropertyChanged("RegionCode");
                }
            }
        }

        [Column(Storage="_ScorePrice", DbType="Decimal(18,2)")]
        public decimal? ScorePrice
        {
            get
            {
                return this._ScorePrice;
            }
            set
            {
                decimal? nullable = this._ScorePrice;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._ScorePrice = value;
                    this.SendPropertyChanged("ScorePrice");
                }
            }
        }

        [Column(Storage="_SellerToClientMsg", DbType="NVarChar(500)")]
        public string SellerToClientMsg
        {
            get
            {
                return this._SellerToClientMsg;
            }
            set
            {
                if (this._SellerToClientMsg != value)
                {
                    this.SendPropertyChanging();
                    this._SellerToClientMsg = value;
                    this.SendPropertyChanged("SellerToClientMsg");
                }
            }
        }

        [Column(Storage="_SellIsDeleted", DbType="TinyInt")]
        public byte? SellIsDeleted
        {
            get
            {
                return this._SellIsDeleted;
            }
            set
            {
                if (this._SellIsDeleted != value)
                {
                    this.SendPropertyChanging();
                    this._SellIsDeleted = value;
                    this.SendPropertyChanged("SellIsDeleted");
                }
            }
        }

        [Column(Storage="_ShipmentNumber", DbType="NVarChar(50)")]
        public string ShipmentNumber
        {
            get
            {
                return this._ShipmentNumber;
            }
            set
            {
                if (this._ShipmentNumber != value)
                {
                    this.SendPropertyChanging();
                    this._ShipmentNumber = value;
                    this.SendPropertyChanged("ShipmentNumber");
                }
            }
        }

        [Column(Storage="_ShipmentStatus", DbType="Int NOT NULL")]
        public int ShipmentStatus
        {
            get
            {
                return this._ShipmentStatus;
            }
            set
            {
                if (this._ShipmentStatus != value)
                {
                    this.SendPropertyChanging();
                    this._ShipmentStatus = value;
                    this.SendPropertyChanged("ShipmentStatus");
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
                    this.SendPropertyChanging();
                    this._ShopID = value;
                    this.SendPropertyChanged("ShopID");
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

        [Column(Storage="_ShouldPayPrice", DbType="Decimal(18,2)")]
        public decimal? ShouldPayPrice
        {
            get
            {
                return this._ShouldPayPrice;
            }
            set
            {
                decimal? nullable = this._ShouldPayPrice;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._ShouldPayPrice = value;
                    this.SendPropertyChanged("ShouldPayPrice");
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

        [Column(Storage="_SurplusPrice", DbType="Decimal(18,2) NOT NULL")]
        public decimal SurplusPrice
        {
            get
            {
                return this._SurplusPrice;
            }
            set
            {
                if (this._SurplusPrice != value)
                {
                    this.SendPropertyChanging();
                    this._SurplusPrice = value;
                    this.SendPropertyChanged("SurplusPrice");
                }
            }
        }

        [Column(Storage="_Tel", DbType="NVarChar(20)")]
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

        [Column(Storage="_TradeID", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
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
                    this.SendPropertyChanging();
                    this._TradeID = value;
                    this.SendPropertyChanged("TradeID");
                }
            }
        }

        [Column(Storage="_UsedFavourTicket", DbType="NVarChar(50)")]
        public string UsedFavourTicket
        {
            get
            {
                return this._UsedFavourTicket;
            }
            set
            {
                if (this._UsedFavourTicket != value)
                {
                    this.SendPropertyChanging();
                    this._UsedFavourTicket = value;
                    this.SendPropertyChanged("UsedFavourTicket");
                }
            }
        }

        [Column(Storage="_UseScore", DbType="Int NOT NULL")]
        public int UseScore
        {
            get
            {
                return this._UseScore;
            }
            set
            {
                if (this._UseScore != value)
                {
                    this.SendPropertyChanging();
                    this._UseScore = value;
                    this.SendPropertyChanged("UseScore");
                }
            }
        }
    }
}

