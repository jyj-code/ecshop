namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_PreventIp")]
    public class ShopNum1_PreventIp
    {
        private DateTime? _CreateTime;
        private string _CreateUser;
        private string _EndIp;
        private DateTime? _EndTime;
        private System.Guid? _Guid;
        private int? _IsDeleted;
        private int? _LockPeople;
        private string _Memo;
        private DateTime _ModifyTime;
        private string _ModifyUser;
        private string _StartIp;
        private DateTime? _StartTime;

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

        [Column(Storage="_EndIp", DbType="VarChar(30)")]
        public string EndIp
        {
            get
            {
                return this._EndIp;
            }
            set
            {
                if (this._EndIp != value)
                {
                    this._EndIp = value;
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
                    this._EndTime = value;
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

        [Column(Storage="_LockPeople", DbType="Int")]
        public int? LockPeople
        {
            get
            {
                return this._LockPeople;
            }
            set
            {
                if (this._LockPeople != value)
                {
                    this._LockPeople = value;
                }
            }
        }

        [Column(Storage="_Memo", DbType="VarChar(300)")]
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

        [Column(Storage="_StartIp", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
        public string StartIp
        {
            get
            {
                return this._StartIp;
            }
            set
            {
                if (this._StartIp != value)
                {
                    this._StartIp = value;
                }
            }
        }

        [Column(Storage="_StartTime", DbType="DateTime")]
        public DateTime? StartTime
        {
            get
            {
                return this._StartTime;
            }
            set
            {
                if (this._StartTime != value)
                {
                    this._StartTime = value;
                }
            }
        }
    }
}

