namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_AdvancePaymentFreezeLog")]
    public class ShopNum1_AdvancePaymentFreezeLog
    {
        private string _CreateTime;
        private string _CreateUser;
        private decimal _CurrentAdvancePayment;
        private DateTime _Date;
        private System.Guid _Guid;
        private int? _IsDeleted;
        private decimal _LastOperateMoney;
        private string _MemLoginID;
        private string _Memo;
        private decimal _OperateMoney;
        private int _OperateType;

        [Column(Storage="_CreateTime", DbType="NVarChar(50)")]
        public string CreateTime
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

        [Column(Storage="_LastOperateMoney", DbType="Decimal(18,2) NOT NULL")]
        public decimal LastOperateMoney
        {
            get
            {
                return this._LastOperateMoney;
            }
            set
            {
                if (this._LastOperateMoney != value)
                {
                    this._LastOperateMoney = value;
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

        [Column(Storage="_Memo", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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

        [Column(Storage="_OperateType", DbType="Int NOT NULL")]
        public int OperateType
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
    }
}

