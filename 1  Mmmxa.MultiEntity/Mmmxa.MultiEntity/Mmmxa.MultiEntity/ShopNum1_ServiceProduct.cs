namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_ServiceProduct")]
    public class ShopNum1_ServiceProduct
    {
        private DateTime? _CreateTime;
        private string _CreateUser;
        private System.Guid? _Guid;
        private int? _IsDeleted;
        private int _LimitCount;
        private DateTime? _ModifyTime;
        private string _ModifyUser;
        private string _Remark;
        private string _ServiceName;
        private decimal? _ServicePrice;
        private int _ServiceTime;
        private int? _ServiceType;

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

        [Column(Storage="_LimitCount", DbType="Int NOT NULL")]
        public int LimitCount
        {
            get
            {
                return this._LimitCount;
            }
            set
            {
                if (this._LimitCount != value)
                {
                    this._LimitCount = value;
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

        [Column(Storage="_Remark", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
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

        [Column(Storage="_ServiceName", DbType="NVarChar(50)")]
        public string ServiceName
        {
            get
            {
                return this._ServiceName;
            }
            set
            {
                if (this._ServiceName != value)
                {
                    this._ServiceName = value;
                }
            }
        }

        [Column(Storage="_ServicePrice", DbType="Decimal(18,2)")]
        public decimal? ServicePrice
        {
            get
            {
                return this._ServicePrice;
            }
            set
            {
                decimal? nullable = this._ServicePrice;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this._ServicePrice = value;
                }
            }
        }

        [Column(Storage="_ServiceTime", DbType="Int NOT NULL")]
        public int ServiceTime
        {
            get
            {
                return this._ServiceTime;
            }
            set
            {
                if (this._ServiceTime != value)
                {
                    this._ServiceTime = value;
                }
            }
        }

        [Column(Storage="_ServiceType", DbType="Int")]
        public int? ServiceType
        {
            get
            {
                return this._ServiceType;
            }
            set
            {
                if (this._ServiceType != value)
                {
                    this._ServiceType = value;
                }
            }
        }
    }
}

