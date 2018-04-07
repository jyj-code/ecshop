namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_AgentPaymentApplyLog")]
    public class ShopNum1_AgentPaymentApplyLog
    {
        private string _Account;
        private string _Bank;
        private decimal _CurrentAdvancePayment;
        private DateTime _Date;
        private System.Guid _Guid;
        private int? _ID;
        private int _IsDeleted;
        private string _MemLoginID;
        private string _Memo;
        private decimal _OperateMoney;
        private int _OperateStatus;
        private string _OperateType;
        private string _OrderNumber;
        private int? _OrderStatus;
        private System.Guid? _PaymentGuid;
        private string _PaymentName;
        private string _SubstationID;
        private string _TrueName;
        private string _UserMemo;

        [Column(Storage="_Account", DbType="NVarChar(50)")]
        public string Account
        {
            get
            {
                return this._Account;
            }
            set
            {
                if (this._Account != value)
                {
                    this._Account = value;
                }
            }
        }

        [Column(Storage="_Bank", DbType="NVarChar(50)")]
        public string Bank
        {
            get
            {
                return this._Bank;
            }
            set
            {
                if (this._Bank != value)
                {
                    this._Bank = value;
                }
            }
        }

        [Column(Storage="_CurrentAdvancePayment", DbType="Decimal(18,2) NOT NULL")]
        public decimal CurrentAdvancePayment
        {
            get
            {
                return this._CurrentAdvancePayment;
            }
            set
            {
                if (this._CurrentAdvancePayment != value)
                {
                    this._CurrentAdvancePayment = value;
                }
            }
        }

        [Column(Storage="_Date", DbType="DateTime NOT NULL")]
        public DateTime Date
        {
            get
            {
                return this._Date;
            }
            set
            {
                if (this._Date != value)
                {
                    this._Date = value;
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

        [Column(Storage="_ID", DbType="Int")]
        public int? ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if (this._ID != value)
                {
                    this._ID = value;
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

        [Column(Storage="_Memo", DbType="NVarChar(4000)")]
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
                    this._Memo = value;
                }
            }
        }

        [Column(Storage="_OperateMoney", DbType="Decimal(18,2) NOT NULL")]
        public decimal OperateMoney
        {
            get
            {
                return this._OperateMoney;
            }
            set
            {
                if (this._OperateMoney != value)
                {
                    this._OperateMoney = value;
                }
            }
        }

        [Column(Storage="_OperateStatus", DbType="Int NOT NULL")]
        public int OperateStatus
        {
            get
            {
                return this._OperateStatus;
            }
            set
            {
                if (this._OperateStatus != value)
                {
                    this._OperateStatus = value;
                }
            }
        }

        [Column(Storage="_OperateType", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
        public string OperateType
        {
            get
            {
                return this._OperateType;
            }
            set
            {
                if (this._OperateType != value)
                {
                    this._OperateType = value;
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
                    this._OrderNumber = value;
                }
            }
        }

        [Column(Storage="_OrderStatus", DbType="Int")]
        public int? OrderStatus
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
                    this._PaymentGuid = value;
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
                    this._PaymentName = value;
                }
            }
        }

        [Column(Storage="_SubstationID", DbType="NVarChar(50)")]
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

        [Column(Storage="_TrueName", DbType="NVarChar(50)")]
        public string TrueName
        {
            get
            {
                return this._TrueName;
            }
            set
            {
                if (this._TrueName != value)
                {
                    this._TrueName = value;
                }
            }
        }

        [Column(Storage="_UserMemo", DbType="NVarChar(4000)")]
        public string UserMemo
        {
            get
            {
                return this._UserMemo;
            }
            set
            {
                if (this._UserMemo != value)
                {
                    this._UserMemo = value;
                }
            }
        }
    }
}

