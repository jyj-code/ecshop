namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_Refund")]
    public class ShopNum1_Refund
    {
        private string _AddressName;
        private string _AddressValue;
        private string _AdminContent;
        private DateTime _ApplyTime;
        private int _ID;
        private int _IsAdmin;
        private int _IsReceive;
        private string _MemLoginID;
        private DateTime? _ModifyTime;
        private string _ModifyUser;
        private string _OnPassImg;
        private string _OnPassReason;
        private string _OrderID;
        private Guid _ProductGuid;
        private string _RefundContent;
        private string _RefundID;
        private string _RefundImg;
        private decimal _RefundMoney;
        private string _RefundReason;
        private int _RefundStatus;
        private int _RefundType;
        private string _ShopID;

        [Column(Storage="_AddressName", DbType="NVarChar(250)")]
        public string AddressName
        {
            get
            {
                return this._AddressName;
            }
            set
            {
                if (this._AddressName != value)
                {
                    this._AddressName = value;
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
                    this._AddressValue = value;
                }
            }
        }

        [Column(Storage="_AdminContent", DbType="NVarChar(250)")]
        public string AdminContent
        {
            get
            {
                return this._AdminContent;
            }
            set
            {
                if (this._AdminContent != value)
                {
                    this._AdminContent = value;
                }
            }
        }

        [Column(Storage="_ApplyTime", DbType="DateTime NOT NULL")]
        public DateTime ApplyTime
        {
            get
            {
                return this._ApplyTime;
            }
            set
            {
                if (this._ApplyTime != value)
                {
                    this._ApplyTime = value;
                }
            }
        }

        [Column(Storage="_ID", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
        public int ID
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

        [Column(Storage="_IsAdmin", DbType="Int NOT NULL")]
        public int IsAdmin
        {
            get
            {
                return this._IsAdmin;
            }
            set
            {
                if (this._IsAdmin != value)
                {
                    this._IsAdmin = value;
                }
            }
        }

        [Column(Storage="_IsReceive", DbType="Int NOT NULL")]
        public int IsReceive
        {
            get
            {
                return this._IsReceive;
            }
            set
            {
                if (this._IsReceive != value)
                {
                    this._IsReceive = value;
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

        [Column(Storage="_OnPassImg", DbType="NVarChar(250)")]
        public string OnPassImg
        {
            get
            {
                return this._OnPassImg;
            }
            set
            {
                if (this._OnPassImg != value)
                {
                    this._OnPassImg = value;
                }
            }
        }

        [Column(Storage="_OnPassReason", DbType="NVarChar(250)")]
        public string OnPassReason
        {
            get
            {
                return this._OnPassReason;
            }
            set
            {
                if (this._OnPassReason != value)
                {
                    this._OnPassReason = value;
                }
            }
        }

        [Column(Storage="_OrderID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string OrderID
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

        [Column(Storage="_ProductGuid", DbType="UniqueIdentifier NOT NULL")]
        public Guid ProductGuid
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

        [Column(Storage="_RefundContent", DbType="NVarChar(250)")]
        public string RefundContent
        {
            get
            {
                return this._RefundContent;
            }
            set
            {
                if (this._RefundContent != value)
                {
                    this._RefundContent = value;
                }
            }
        }

        [Column(Storage="_RefundID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string RefundID
        {
            get
            {
                return this._RefundID;
            }
            set
            {
                if (this._RefundID != value)
                {
                    this._RefundID = value;
                }
            }
        }

        [Column(Storage="_RefundImg", DbType="NVarChar(250)")]
        public string RefundImg
        {
            get
            {
                return this._RefundImg;
            }
            set
            {
                if (this._RefundImg != value)
                {
                    this._RefundImg = value;
                }
            }
        }

        [Column(Storage="_RefundMoney", DbType="Decimal(18,2) NOT NULL")]
        public decimal RefundMoney
        {
            get
            {
                return this._RefundMoney;
            }
            set
            {
                if (this._RefundMoney != value)
                {
                    this._RefundMoney = value;
                }
            }
        }

        [Column(Storage="_RefundReason", DbType="NVarChar(250)")]
        public string RefundReason
        {
            get
            {
                return this._RefundReason;
            }
            set
            {
                if (this._RefundReason != value)
                {
                    this._RefundReason = value;
                }
            }
        }

        [Column(Storage="_RefundStatus", DbType="Int NOT NULL")]
        public int RefundStatus
        {
            get
            {
                return this._RefundStatus;
            }
            set
            {
                if (this._RefundStatus != value)
                {
                    this._RefundStatus = value;
                }
            }
        }

        [Column(Storage="_RefundType", DbType="Int NOT NULL")]
        public int RefundType
        {
            get
            {
                return this._RefundType;
            }
            set
            {
                if (this._RefundType != value)
                {
                    this._RefundType = value;
                }
            }
        }

        [Column(Storage="_ShopID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
    }
}

