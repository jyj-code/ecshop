namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_Shop_ApplyEnsure")]
    public class ShopNum1_Shop_ApplyEnsure
    {
        private DateTime _ApplyTime;
        private DateTime? _AudtiteTime;
        private DateTime _CreateTime;
        private string _CreateUser;
        private int _EnsureID;
        private System.Guid _Guid;
        private int _IsAudit;
        private int _IsPayMent;
        private string _MemberLoginID;
        private DateTime? _ModifyTime;
        private string _ModifyUser;
        private string _PaymentName;
        private System.Guid _PaymentType;
        private string _Remarks;
        private string _ShopID;

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

        [Column(Storage="_AudtiteTime", DbType="DateTime")]
        public DateTime? AudtiteTime
        {
            get
            {
                return this._AudtiteTime;
            }
            set
            {
                if (this._AudtiteTime != value)
                {
                    this._AudtiteTime = value;
                }
            }
        }

        [Column(Storage="_CreateTime", DbType="DateTime NOT NULL")]
        public DateTime CreateTime
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

        [Column(Storage="_CreateUser", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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

        [Column(Storage="_EnsureID", DbType="Int NOT NULL")]
        public int EnsureID
        {
            get
            {
                return this._EnsureID;
            }
            set
            {
                if (this._EnsureID != value)
                {
                    this._EnsureID = value;
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

        [Column(Storage="_PaymentName", DbType="NVarChar(100)")]
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
        public System.Guid PaymentType
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

