namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_ScoreOrderInfo")]
    public class ShopNum1_ScoreOrderInfo
    {
        private string _Address;
        private DateTime? _ConfirmTime;
        private DateTime? _CreateTime;
        private string _Email;
        private System.Guid? _Guid;
        private byte? _IsDeleted;
        private string _MemLoginID;
        private string _Mobile;
        private DateTime? _ModifyTime;
        private string _ModifyUser;
        private string _Name;
        private byte? _OderStatus;
        private string _OrderNumber;
        private string _Postalcode;
        private string _ShopMemLoginID;
        private string _ShopName;
        private string _SubstationID;
        private string _Tel;
        private int? _TotalScore;
        private string _UserMsg;

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
                    this._Address = value;
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
                    this._ConfirmTime = value;
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
                    this._Email = value;
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
                    this._IsDeleted = value;
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
                    this._Mobile = value;
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
                    this._Name = value;
                }
            }
        }

        [Column(Storage="_OderStatus", DbType="TinyInt")]
        public byte? OderStatus
        {
            get
            {
                return this._OderStatus;
            }
            set
            {
                if (this._OderStatus != value)
                {
                    this._OderStatus = value;
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

        [Column(Storage="_Postalcode", DbType="VarChar(20)")]
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
                    this._Postalcode = value;
                }
            }
        }

        [Column(Storage="_ShopMemLoginID", DbType="VarChar(50)")]
        public string ShopMemLoginID
        {
            get
            {
                return this._ShopMemLoginID;
            }
            set
            {
                if (this._ShopMemLoginID != value)
                {
                    this._ShopMemLoginID = value;
                }
            }
        }

        [Column(Storage="_ShopName", DbType="NVarChar(100)")]
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
                    this._ShopName = value;
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
                    this._Tel = value;
                }
            }
        }

        [Column(Storage="_TotalScore", DbType="Int")]
        public int? TotalScore
        {
            get
            {
                return this._TotalScore;
            }
            set
            {
                if (this._TotalScore != value)
                {
                    this._TotalScore = value;
                }
            }
        }

        [Column(Storage="_UserMsg", DbType="NVarChar(1000)")]
        public string UserMsg
        {
            get
            {
                return this._UserMsg;
            }
            set
            {
                if (this._UserMsg != value)
                {
                    this._UserMsg = value;
                }
            }
        }
    }
}

