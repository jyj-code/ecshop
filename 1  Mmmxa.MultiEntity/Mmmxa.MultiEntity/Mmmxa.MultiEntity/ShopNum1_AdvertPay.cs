namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_AdvertPay")]
    public class ShopNum1_AdvertPay
    {
        private int? _AdId;
        private int? _AdType;
        private int? _ApplyState;
        private DateTime? _BeginDate;
        private string _CityCode;
        private int? _ClickTime;
        private DateTime? _CreateTime;
        private string _CreateUser;
        private DateTime? _EndDate;
        private string _ExamineCase;
        private System.Guid? _Guid;
        private string _Image;
        private int? _IsCancel;
        private int? _IsDeleted;
        private int? _IsExamine;
        private string _MemLoginID;
        private DateTime? _ModifyTime;
        private string _ModifyUser;
        private decimal? _PayMoney;
        private string _Remarks;
        private string _Remarks1;
        private string _Remarks2;
        private string _SubstationID;
        private string _Website;
        private string _Website1;
        private string _Website2;

        [Column(Storage="_AdId", DbType="Int")]
        public int? AdId
        {
            get
            {
                return this._AdId;
            }
            set
            {
                if (this._AdId != value)
                {
                    this._AdId = value;
                }
            }
        }

        [Column(Storage="_AdType", DbType="Int")]
        public int? AdType
        {
            get
            {
                return this._AdType;
            }
            set
            {
                if (this._AdType != value)
                {
                    this._AdType = value;
                }
            }
        }

        [Column(Storage="_ApplyState", DbType="Int")]
        public int? ApplyState
        {
            get
            {
                return this._ApplyState;
            }
            set
            {
                if (this._ApplyState != value)
                {
                    this._ApplyState = value;
                }
            }
        }

        [Column(Storage="_BeginDate", DbType="DateTime")]
        public DateTime? BeginDate
        {
            get
            {
                return this._BeginDate;
            }
            set
            {
                if (this._BeginDate != value)
                {
                    this._BeginDate = value;
                }
            }
        }

        [Column(Storage="_CityCode", DbType="NVarChar(100)")]
        public string CityCode
        {
            get
            {
                return this._CityCode;
            }
            set
            {
                if (this._CityCode != value)
                {
                    this._CityCode = value;
                }
            }
        }

        [Column(Storage="_ClickTime", DbType="Int")]
        public int? ClickTime
        {
            get
            {
                return this._ClickTime;
            }
            set
            {
                if (this._ClickTime != value)
                {
                    this._ClickTime = value;
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

        [Column(Storage="_EndDate", DbType="DateTime")]
        public DateTime? EndDate
        {
            get
            {
                return this._EndDate;
            }
            set
            {
                if (this._EndDate != value)
                {
                    this._EndDate = value;
                }
            }
        }

        [Column(Storage="_ExamineCase", DbType="NVarChar(500)")]
        public string ExamineCase
        {
            get
            {
                return this._ExamineCase;
            }
            set
            {
                if (this._ExamineCase != value)
                {
                    this._ExamineCase = value;
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

        [Column(Storage="_Image", DbType="NVarChar(500)")]
        public string Image
        {
            get
            {
                return this._Image;
            }
            set
            {
                if (this._Image != value)
                {
                    this._Image = value;
                }
            }
        }

        [Column(Storage="_IsCancel", DbType="Int")]
        public int? IsCancel
        {
            get
            {
                return this._IsCancel;
            }
            set
            {
                if (this._IsCancel != value)
                {
                    this._IsCancel = value;
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

        [Column(Storage="_IsExamine", DbType="Int")]
        public int? IsExamine
        {
            get
            {
                return this._IsExamine;
            }
            set
            {
                if (this._IsExamine != value)
                {
                    this._IsExamine = value;
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

        [Column(Storage="_PayMoney", DbType="Decimal(18,2)")]
        public decimal? PayMoney
        {
            get
            {
                return this._PayMoney;
            }
            set
            {
                decimal? nullable = this._PayMoney;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this._PayMoney = value;
                }
            }
        }

        [Column(Storage="_Remarks", DbType="NVarChar(500)")]
        public string Remarks
        {
            get
            {
                return this._Remarks;
            }
            set
            {
                if (this._Remarks != value)
                {
                    this._Remarks = value;
                }
            }
        }

        [Column(Storage="_Remarks1", DbType="NVarChar(200)")]
        public string Remarks1
        {
            get
            {
                return this._Remarks1;
            }
            set
            {
                if (this._Remarks1 != value)
                {
                    this._Remarks1 = value;
                }
            }
        }

        [Column(Storage="_Remarks2", DbType="NVarChar(200)")]
        public string Remarks2
        {
            get
            {
                return this._Remarks2;
            }
            set
            {
                if (this._Remarks2 != value)
                {
                    this._Remarks2 = value;
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

        [Column(Storage="_Website", DbType="NVarChar(1000)")]
        public string Website
        {
            get
            {
                return this._Website;
            }
            set
            {
                if (this._Website != value)
                {
                    this._Website = value;
                }
            }
        }

        [Column(Storage="_Website1", DbType="NVarChar(500)")]
        public string Website1
        {
            get
            {
                return this._Website1;
            }
            set
            {
                if (this._Website1 != value)
                {
                    this._Website1 = value;
                }
            }
        }

        [Column(Storage="_Website2", DbType="NVarChar(500)")]
        public string Website2
        {
            get
            {
                return this._Website2;
            }
            set
            {
                if (this._Website2 != value)
                {
                    this._Website2 = value;
                }
            }
        }
    }
}

