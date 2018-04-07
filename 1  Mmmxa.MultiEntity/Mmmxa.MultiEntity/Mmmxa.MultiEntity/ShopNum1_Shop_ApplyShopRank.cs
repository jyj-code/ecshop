namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_Shop_ApplyShopRank")]
    public class ShopNum1_Shop_ApplyShopRank
    {
        private DateTime? _ApplyTime;
        private int _ID;
        private int _IsAudit;
        private int _IsPayMent;
        private string _MemberLoginID;
        private string _PaymentName;
        private Guid _PaymentType;
        private Guid _RankGuid;
        private string _RankName;
        private string _Remarks;
        private DateTime? _VerifyTime;

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
                    this._IsAudit = value;
                }
            }
        }

        [Column(Storage="_IsPayMent", DbType="Int NOT NULL")]
        public int IsPayMent
        {
            get
            {
                return this._IsPayMent;
            }
            set
            {
                if (this._IsPayMent != value)
                {
                    this._IsPayMent = value;
                }
            }
        }

        [Column(Storage="_MemberLoginID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string MemberLoginID
        {
            get
            {
                return this._MemberLoginID;
            }
            set
            {
                if (this._MemberLoginID != value)
                {
                    this._MemberLoginID = value;
                }
            }
        }

        [Column(Storage="_PaymentName", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
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

        [Column(Storage="_PaymentType", DbType="UniqueIdentifier NOT NULL")]
        public Guid PaymentType
        {
            get
            {
                return this._PaymentType;
            }
            set
            {
                if (this._PaymentType != value)
                {
                    this._PaymentType = value;
                }
            }
        }

        [Column(Storage="_RankGuid", DbType="UniqueIdentifier NOT NULL")]
        public Guid RankGuid
        {
            get
            {
                return this._RankGuid;
            }
            set
            {
                if (this._RankGuid != value)
                {
                    this._RankGuid = value;
                }
            }
        }

        [Column(Storage="_RankName", DbType="NVarChar(50)")]
        public string RankName
        {
            get
            {
                return this._RankName;
            }
            set
            {
                if (this._RankName != value)
                {
                    this._RankName = value;
                }
            }
        }

        [Column(Storage="_Remarks", DbType="NVarChar(MAX)")]
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

        [Column(Storage="_VerifyTime", DbType="DateTime")]
        public DateTime? VerifyTime
        {
            get
            {
                return this._VerifyTime;
            }
            set
            {
                if (this._VerifyTime != value)
                {
                    this._VerifyTime = value;
                }
            }
        }
    }
}

