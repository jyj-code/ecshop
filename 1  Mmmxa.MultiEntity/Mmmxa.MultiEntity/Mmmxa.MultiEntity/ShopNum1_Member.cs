namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_Member")]
    public class ShopNum1_Member : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _Address;
        private string _AddressCode;
        private string _AddressValue;
        private decimal? _AdvancePayment;
        private string _AlipayNumber;
        private string _Answer;
        private string _Area;
        private string _AuditFailedReason;
        private DateTime? _Birthday;
        private decimal? _CostMoney;
        private DateTime? _CreateTime;
        private string _CreateUser;
        private decimal? _CreditMoney;
        private string _Email;
        private string _Fax;
        private System.Guid _Guid;
        private int? _IdentificationIsAudit;
        private DateTime? _IdentificationTime;
        private string _IdentityCard;
        private string _IdentityCardBackImg;
        private string _IdentityCardImg;
        private byte _IsDeleted;
        private string _IsEmailActivation;
        private int? _IsForbid;
        private int? _IsMailActivation;
        private int _IsMobileActivation;
        private DateTime? _LastLoginDate;
        private string _LastLoginIP;
        private decimal? _LockAdvancePayment;
        private int? _LockSocre;
        private DateTime? _LoginDate;
        private int? _LoginTime;
        private DateTime? _MActiveTime;
        private int? _MemberRank;
        private System.Guid _MemberRankGuid;
        private int? _MemberType;
        private string _MemLoginID;
        private string _Mobile;
        private DateTime? _ModifyTime;
        private string _ModifyUser;
        private string _Msn;
        private string _Name;
        private string _PayPwd;
        private string _Photo;
        private string _Postalcode;
        private string _PromotionMemLoginID;
        private string _Pwd;
        private string _QQ;
        private string _Question;
        private int? _RankScore;
        private string _RealName;
        private DateTime? _RegDate;
        private DateTime? _RegeDate;
        private int _Score;
        private byte? _Sex;
        private byte? _Status;
        private DateTime? _TActiveTime;
        private string _Tel;
        private int? _TradeCount;
        private string _Vocation;
        private string _WebSite;
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

        [Column(Storage="_AddressCode", DbType="VarChar(9)")]
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

        [Column(Storage="_AdvancePayment", DbType="Decimal(18,2)")]
        public decimal? AdvancePayment
        {
            get
            {
                return this._AdvancePayment;
            }
            set
            {
                decimal? nullable = this._AdvancePayment;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._AdvancePayment = value;
                    this.SendPropertyChanged("AdvancePayment");
                }
            }
        }

        [Column(Storage="_AlipayNumber", DbType="NVarChar(100)")]
        public string AlipayNumber
        {
            get
            {
                return this._AlipayNumber;
            }
            set
            {
                if (this._AlipayNumber != value)
                {
                    this.SendPropertyChanging();
                    this._AlipayNumber = value;
                    this.SendPropertyChanged("AlipayNumber");
                }
            }
        }

        [Column(Storage="_Answer", DbType="NVarChar(50)")]
        public string Answer
        {
            get
            {
                return this._Answer;
            }
            set
            {
                if (this._Answer != value)
                {
                    this.SendPropertyChanging();
                    this._Answer = value;
                    this.SendPropertyChanged("Answer");
                }
            }
        }

        [Column(Storage="_Area", DbType="NVarChar(50)")]
        public string Area
        {
            get
            {
                return this._Area;
            }
            set
            {
                if (this._Area != value)
                {
                    this.SendPropertyChanging();
                    this._Area = value;
                    this.SendPropertyChanged("Area");
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

        [Column(Storage="_Birthday", DbType="DateTime")]
        public DateTime? Birthday
        {
            get
            {
                return this._Birthday;
            }
            set
            {
                if (this._Birthday != value)
                {
                    this.SendPropertyChanging();
                    this._Birthday = value;
                    this.SendPropertyChanged("Birthday");
                }
            }
        }

        [Column(Storage="_CostMoney", DbType="Decimal(18,2)")]
        public decimal? CostMoney
        {
            get
            {
                return this._CostMoney;
            }
            set
            {
                decimal? nullable = this._CostMoney;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._CostMoney = value;
                    this.SendPropertyChanged("CostMoney");
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

        [Column(Storage="_CreditMoney", DbType="Decimal(18,2)")]
        public decimal? CreditMoney
        {
            get
            {
                return this._CreditMoney;
            }
            set
            {
                decimal? nullable = this._CreditMoney;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._CreditMoney = value;
                    this.SendPropertyChanged("CreditMoney");
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

        [Column(Storage="_Fax", DbType="NVarChar(20)")]
        public string Fax
        {
            get
            {
                return this._Fax;
            }
            set
            {
                if (this._Fax != value)
                {
                    this.SendPropertyChanging();
                    this._Fax = value;
                    this.SendPropertyChanged("Fax");
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

        [Column(Storage="_IdentificationIsAudit", DbType="Int")]
        public int? IdentificationIsAudit
        {
            get
            {
                return this._IdentificationIsAudit;
            }
            set
            {
                if (this._IdentificationIsAudit != value)
                {
                    this.SendPropertyChanging();
                    this._IdentificationIsAudit = value;
                    this.SendPropertyChanged("IdentificationIsAudit");
                }
            }
        }

        [Column(Storage="_IdentificationTime", DbType="DateTime")]
        public DateTime? IdentificationTime
        {
            get
            {
                return this._IdentificationTime;
            }
            set
            {
                if (this._IdentificationTime != value)
                {
                    this.SendPropertyChanging();
                    this._IdentificationTime = value;
                    this.SendPropertyChanged("IdentificationTime");
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

        [Column(Storage="_IdentityCardBackImg", DbType="NVarChar(250)")]
        public string IdentityCardBackImg
        {
            get
            {
                return this._IdentityCardBackImg;
            }
            set
            {
                if (this._IdentityCardBackImg != value)
                {
                    this.SendPropertyChanging();
                    this._IdentityCardBackImg = value;
                    this.SendPropertyChanged("IdentityCardBackImg");
                }
            }
        }

        [Column(Storage="_IdentityCardImg", DbType="NVarChar(250)")]
        public string IdentityCardImg
        {
            get
            {
                return this._IdentityCardImg;
            }
            set
            {
                if (this._IdentityCardImg != value)
                {
                    this.SendPropertyChanging();
                    this._IdentityCardImg = value;
                    this.SendPropertyChanged("IdentityCardImg");
                }
            }
        }

        [Column(Storage="_IsDeleted", DbType="TinyInt NOT NULL")]
        public byte IsDeleted
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

        [Column(Storage="_IsEmailActivation", CanBeNull=false)]
        public string IsEmailActivation
        {
            get
            {
                return this._IsEmailActivation;
            }
            set
            {
                if (this._IsEmailActivation != value)
                {
                    this.SendPropertyChanging();
                    this._IsEmailActivation = value;
                    this.SendPropertyChanged("IsEmailActivation");
                }
            }
        }

        [Column(Storage="_IsForbid", DbType="Int")]
        public int? IsForbid
        {
            get
            {
                return this._IsForbid;
            }
            set
            {
                if (this._IsForbid != value)
                {
                    this.SendPropertyChanging();
                    this._IsForbid = value;
                    this.SendPropertyChanged("IsForbid");
                }
            }
        }

        [Column(Storage="_IsMailActivation", DbType="Int")]
        public int? IsMailActivation
        {
            get
            {
                return this._IsMailActivation;
            }
            set
            {
                if (this._IsMailActivation != value)
                {
                    this.SendPropertyChanging();
                    this._IsMailActivation = value;
                    this.SendPropertyChanged("IsMailActivation");
                }
            }
        }

        [Column(Storage="_IsMobileActivation", DbType="Int NOT NULL")]
        public int IsMobileActivation
        {
            get
            {
                return this._IsMobileActivation;
            }
            set
            {
                if (this._IsMobileActivation != value)
                {
                    this.SendPropertyChanging();
                    this._IsMobileActivation = value;
                    this.SendPropertyChanged("IsMobileActivation");
                }
            }
        }

        [Column(Storage="_LastLoginDate", DbType="DateTime")]
        public DateTime? LastLoginDate
        {
            get
            {
                return this._LastLoginDate;
            }
            set
            {
                if (this._LastLoginDate != value)
                {
                    this.SendPropertyChanging();
                    this._LastLoginDate = value;
                    this.SendPropertyChanged("LastLoginDate");
                }
            }
        }

        [Column(Storage="_LastLoginIP", DbType="NVarChar(25)")]
        public string LastLoginIP
        {
            get
            {
                return this._LastLoginIP;
            }
            set
            {
                if (this._LastLoginIP != value)
                {
                    this.SendPropertyChanging();
                    this._LastLoginIP = value;
                    this.SendPropertyChanged("LastLoginIP");
                }
            }
        }

        [Column(Storage="_LockAdvancePayment", DbType="Decimal(18,2)")]
        public decimal? LockAdvancePayment
        {
            get
            {
                return this._LockAdvancePayment;
            }
            set
            {
                decimal? nullable = this._LockAdvancePayment;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._LockAdvancePayment = value;
                    this.SendPropertyChanged("LockAdvancePayment");
                }
            }
        }

        [Column(Storage="_LockSocre", DbType="Int")]
        public int? LockSocre
        {
            get
            {
                return this._LockSocre;
            }
            set
            {
                if (this._LockSocre != value)
                {
                    this.SendPropertyChanging();
                    this._LockSocre = value;
                    this.SendPropertyChanged("LockSocre");
                }
            }
        }

        [Column(Storage="_LoginDate", DbType="DateTime")]
        public DateTime? LoginDate
        {
            get
            {
                return this._LoginDate;
            }
            set
            {
                if (this._LoginDate != value)
                {
                    this.SendPropertyChanging();
                    this._LoginDate = value;
                    this.SendPropertyChanged("LoginDate");
                }
            }
        }

        [Column(Storage="_LoginTime", DbType="Int")]
        public int? LoginTime
        {
            get
            {
                return this._LoginTime;
            }
            set
            {
                if (this._LoginTime != value)
                {
                    this.SendPropertyChanging();
                    this._LoginTime = value;
                    this.SendPropertyChanged("LoginTime");
                }
            }
        }

        [Column(Storage="_MActiveTime", DbType="DateTime")]
        public DateTime? MActiveTime
        {
            get
            {
                return this._MActiveTime;
            }
            set
            {
                if (this._MActiveTime != value)
                {
                    this.SendPropertyChanging();
                    this._MActiveTime = value;
                    this.SendPropertyChanged("MActiveTime");
                }
            }
        }

        [Column(Storage="_MemberRank", DbType="Int")]
        public int? MemberRank
        {
            get
            {
                return this._MemberRank;
            }
            set
            {
                if (this._MemberRank != value)
                {
                    this.SendPropertyChanging();
                    this._MemberRank = value;
                    this.SendPropertyChanged("MemberRank");
                }
            }
        }

        [Column(Storage="_MemberRankGuid")]
        public System.Guid MemberRankGuid
        {
            get
            {
                return this._MemberRankGuid;
            }
            set
            {
                if (this._MemberRankGuid != value)
                {
                    this.SendPropertyChanging();
                    this._MemberRankGuid = value;
                    this.SendPropertyChanged("MemberRankGuid");
                }
            }
        }

        [Column(Storage="_MemberType", DbType="Int")]
        public int? MemberType
        {
            get
            {
                return this._MemberType;
            }
            set
            {
                if (this._MemberType != value)
                {
                    this.SendPropertyChanging();
                    this._MemberType = value;
                    this.SendPropertyChanged("MemberType");
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

        [Column(Storage="_Msn", DbType="NVarChar(50)")]
        public string Msn
        {
            get
            {
                return this._Msn;
            }
            set
            {
                if (this._Msn != value)
                {
                    this.SendPropertyChanging();
                    this._Msn = value;
                    this.SendPropertyChanged("Msn");
                }
            }
        }

        [Column(Storage="_Name", DbType="NVarChar(20)")]
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

        [Column(Storage="_PayPwd", DbType="NVarChar(250)")]
        public string PayPwd
        {
            get
            {
                return this._PayPwd;
            }
            set
            {
                if (this._PayPwd != value)
                {
                    this.SendPropertyChanging();
                    this._PayPwd = value;
                    this.SendPropertyChanged("PayPwd");
                }
            }
        }

        [Column(Storage="_Photo", DbType="NVarChar(250)")]
        public string Photo
        {
            get
            {
                return this._Photo;
            }
            set
            {
                if (this._Photo != value)
                {
                    this.SendPropertyChanging();
                    this._Photo = value;
                    this.SendPropertyChanged("Photo");
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

        [Column(Storage="_PromotionMemLoginID", DbType="NVarChar(50)")]
        public string PromotionMemLoginID
        {
            get
            {
                return this._PromotionMemLoginID;
            }
            set
            {
                if (this._PromotionMemLoginID != value)
                {
                    this.SendPropertyChanging();
                    this._PromotionMemLoginID = value;
                    this.SendPropertyChanged("PromotionMemLoginID");
                }
            }
        }

        [Column(Storage="_Pwd", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
        public string Pwd
        {
            get
            {
                return this._Pwd;
            }
            set
            {
                if (this._Pwd != value)
                {
                    this.SendPropertyChanging();
                    this._Pwd = value;
                    this.SendPropertyChanged("Pwd");
                }
            }
        }

        [Column(Storage="_QQ", DbType="NVarChar(15)")]
        public string QQ
        {
            get
            {
                return this._QQ;
            }
            set
            {
                if (this._QQ != value)
                {
                    this.SendPropertyChanging();
                    this._QQ = value;
                    this.SendPropertyChanged("QQ");
                }
            }
        }

        [Column(Storage="_Question", DbType="NVarChar(50)")]
        public string Question
        {
            get
            {
                return this._Question;
            }
            set
            {
                if (this._Question != value)
                {
                    this.SendPropertyChanging();
                    this._Question = value;
                    this.SendPropertyChanged("Question");
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

        [Column(Storage="_RealName", DbType="NVarChar(50)")]
        public string RealName
        {
            get
            {
                return this._RealName;
            }
            set
            {
                if (this._RealName != value)
                {
                    this.SendPropertyChanging();
                    this._RealName = value;
                    this.SendPropertyChanged("RealName");
                }
            }
        }

        [Column(Storage="_RegDate", DbType="DateTime")]
        public DateTime? RegDate
        {
            get
            {
                return this._RegDate;
            }
            set
            {
                if (this._RegDate != value)
                {
                    this.SendPropertyChanging();
                    this._RegDate = value;
                    this.SendPropertyChanged("RegDate");
                }
            }
        }

        [Column(Storage="_RegeDate", DbType="DateTime")]
        public DateTime? RegeDate
        {
            get
            {
                return this._RegeDate;
            }
            set
            {
                if (this._RegeDate != value)
                {
                    this.SendPropertyChanging();
                    this._RegeDate = value;
                    this.SendPropertyChanged("RegeDate");
                }
            }
        }

        [Column(Storage="_Score", DbType="Int NOT NULL")]
        public int Score
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

        [Column(Storage="_Sex", DbType="TinyInt")]
        public byte? Sex
        {
            get
            {
                return this._Sex;
            }
            set
            {
                if (this._Sex != value)
                {
                    this.SendPropertyChanging();
                    this._Sex = value;
                    this.SendPropertyChanged("Sex");
                }
            }
        }

        [Column(Storage="_Status", DbType="TinyInt")]
        public byte? Status
        {
            get
            {
                return this._Status;
            }
            set
            {
                if (this._Status != value)
                {
                    this.SendPropertyChanging();
                    this._Status = value;
                    this.SendPropertyChanged("Status");
                }
            }
        }

        [Column(Storage="_TActiveTime", DbType="DateTime")]
        public DateTime? TActiveTime
        {
            get
            {
                return this._TActiveTime;
            }
            set
            {
                if (this._TActiveTime != value)
                {
                    this.SendPropertyChanging();
                    this._TActiveTime = value;
                    this.SendPropertyChanged("TActiveTime");
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

        [Column(Storage="_TradeCount", DbType="Int")]
        public int? TradeCount
        {
            get
            {
                return this._TradeCount;
            }
            set
            {
                if (this._TradeCount != value)
                {
                    this.SendPropertyChanging();
                    this._TradeCount = value;
                    this.SendPropertyChanged("TradeCount");
                }
            }
        }

        [Column(Storage="_Vocation", DbType="NVarChar(100)")]
        public string Vocation
        {
            get
            {
                return this._Vocation;
            }
            set
            {
                if (this._Vocation != value)
                {
                    this.SendPropertyChanging();
                    this._Vocation = value;
                    this.SendPropertyChanged("Vocation");
                }
            }
        }

        [Column(Storage="_WebSite", DbType="NVarChar(250)")]
        public string WebSite
        {
            get
            {
                return this._WebSite;
            }
            set
            {
                if (this._WebSite != value)
                {
                    this.SendPropertyChanging();
                    this._WebSite = value;
                    this.SendPropertyChanged("WebSite");
                }
            }
        }
    }
}

