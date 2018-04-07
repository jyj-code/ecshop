namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_GroupPageWebControl")]
    public class ShopNum1_GroupPageWebControl
    {
        private string _ControlID;
        private string _ControlType;
        private DateTime _CreateTime;
        private string _CreateUser;
        private System.Guid _GroupGuid;
        private System.Guid _Guid;
        private int _IsDeleted;
        private int _IsShow;
        private int _IsUse;
        private DateTime _ModifyTime;
        private string _ModifyUser;
        private System.Guid _PageGuid;
        private System.Guid _PageWebControlGuid;

        [Column(Storage="_ControlID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ControlID
        {
            get
            {
                return this._ControlID;
            }
            set
            {
                if (this._ControlID != value)
                {
                    this._ControlID = value;
                }
            }
        }

        [Column(Storage="_ControlType", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ControlType
        {
            get
            {
                return this._ControlType;
            }
            set
            {
                if (this._ControlType != value)
                {
                    this._ControlType = value;
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

        [Column(Storage="_GroupGuid", DbType="UniqueIdentifier NOT NULL")]
        public System.Guid GroupGuid
        {
            get
            {
                return this._GroupGuid;
            }
            set
            {
                if (this._GroupGuid != value)
                {
                    this._GroupGuid = value;
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

        [Column(Storage="_IsShow", DbType="Int NOT NULL")]
        public int IsShow
        {
            get
            {
                return this._IsShow;
            }
            set
            {
                if (this._IsShow != value)
                {
                    this._IsShow = value;
                }
            }
        }

        [Column(Storage="_IsUse", DbType="Int NOT NULL")]
        public int IsUse
        {
            get
            {
                return this._IsUse;
            }
            set
            {
                if (this._IsUse != value)
                {
                    this._IsUse = value;
                }
            }
        }

        [Column(Storage="_ModifyTime", DbType="DateTime NOT NULL")]
        public DateTime ModifyTime
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

        [Column(Storage="_ModifyUser", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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

        [Column(Storage="_PageGuid", DbType="UniqueIdentifier NOT NULL")]
        public System.Guid PageGuid
        {
            get
            {
                return this._PageGuid;
            }
            set
            {
                if (this._PageGuid != value)
                {
                    this._PageGuid = value;
                }
            }
        }

        [Column(Storage="_PageWebControlGuid", DbType="UniqueIdentifier NOT NULL")]
        public System.Guid PageWebControlGuid
        {
            get
            {
                return this._PageWebControlGuid;
            }
            set
            {
                if (this._PageWebControlGuid != value)
                {
                    this._PageWebControlGuid = value;
                }
            }
        }
    }
}

