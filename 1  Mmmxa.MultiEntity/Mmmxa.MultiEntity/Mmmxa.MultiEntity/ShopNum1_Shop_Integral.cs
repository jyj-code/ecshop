namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_Shop_Integral")]
    public class ShopNum1_Shop_Integral
    {
        private DateTime? _AddTime;
        private string _AgentLoginID;
        private DateTime _CreateTime;
        private System.Guid? _Guid;
        private int? _IsAudit;
        private string _MemLoginID;
        private string _Remark;
        private int? _Score;

        [Column(Storage="_AddTime", DbType="DateTime")]
        public DateTime? AddTime
        {
            get
            {
                return this._AddTime;
            }
            set
            {
                if (this._AddTime != value)
                {
                    this._AddTime = value;
                }
            }
        }

        [Column(Storage="_AgentLoginID", DbType="NVarChar(50)")]
        public string AgentLoginID
        {
            get
            {
                return this._AgentLoginID;
            }
            set
            {
                if (this._AgentLoginID != value)
                {
                    this._AgentLoginID = value;
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

        [Column(Storage="_IsAudit", DbType="Int")]
        public int? IsAudit
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

        [Column(Storage="_Remark", DbType="NVarChar(500)")]
        public string Remark
        {
            get
            {
                return this._Remark;
            }
            set
            {
                if (this._Remark != value)
                {
                    this._Remark = value;
                }
            }
        }

        [Column(Storage="_Score", DbType="Int")]
        public int? Score
        {
            get
            {
                return this._Score;
            }
            set
            {
                if (this._Score != value)
                {
                    this._Score = value;
                }
            }
        }
    }
}

