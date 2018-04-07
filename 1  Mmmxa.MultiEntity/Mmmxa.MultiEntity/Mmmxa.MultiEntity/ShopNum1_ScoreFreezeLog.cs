namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_ScoreFreezeLog")]
    public class ShopNum1_ScoreFreezeLog
    {
        private string _CreateTime;
        private string _CreateUser;
        private string _CurrentScore;
        private string _Date;
        private string _Guid;
        private string _IsDeleted;
        private string _LastOperateScore;
        private string _MemLoginID;
        private string _Memo;
        private string _OperateScore;
        private string _OperateType;

        [Column(Storage="_CreateTime", DbType="NChar(10)")]
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

        [Column(Storage="_CreateUser", DbType="NChar(10)")]
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

        [Column(Storage="_CurrentScore", DbType="NChar(10)")]
        public string CurrentScore
        {
            get
            {
                return this._CurrentScore;
            }
            set
            {
                if (this._CurrentScore != value)
                {
                    this._CurrentScore = value;
                }
            }
        }

        [Column(Storage="_Date", DbType="NChar(10)")]
        public string Date
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

        [Column(Storage="_Guid", DbType="NChar(10)")]
        public string Guid
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

        [Column(Storage="_IsDeleted", DbType="NChar(10)")]
        public string IsDeleted
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

        [Column(Storage="_LastOperateScore", DbType="NChar(10)")]
        public string LastOperateScore
        {
            get
            {
                return this._LastOperateScore;
            }
            set
            {
                if (this._LastOperateScore != value)
                {
                    this._LastOperateScore = value;
                }
            }
        }

        [Column(Storage="_MemLoginID", DbType="NChar(10)")]
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

        [Column(Storage="_Memo", DbType="NChar(10)")]
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

        [Column(Storage="_OperateScore", DbType="NChar(10)")]
        public string OperateScore
        {
            get
            {
                return this._OperateScore;
            }
            set
            {
                if (this._OperateScore != value)
                {
                    this._OperateScore = value;
                }
            }
        }

        [Column(Storage="_OperateType", DbType="NChar(10)")]
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
    }
}

