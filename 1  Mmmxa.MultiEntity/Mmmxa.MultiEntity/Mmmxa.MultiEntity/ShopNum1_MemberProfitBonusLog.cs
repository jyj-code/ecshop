namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_MemberProfitBonusLog")]
    public class ShopNum1_MemberProfitBonusLog
    {
        private decimal? _GroupPrice;
        private System.Guid _Guid;
        private System.Guid? _InstructorGuid;
        private string _InstructorName;
        private int _IsDeleted;
        private string _MemberLoginID;
        private string _OrderNumber;
        private System.Guid _ProductGuid;
        private string _ProductName;
        private DateTime? _RecordTime;

        [Column(Storage="_GroupPrice", DbType="Decimal(18,2)")]
        public decimal? GroupPrice
        {
            get
            {
                return this._GroupPrice;
            }
            set
            {
                decimal? nullable = this._GroupPrice;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this._GroupPrice = value;
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

        [Column(Storage="_InstructorGuid", DbType="UniqueIdentifier")]
        public System.Guid? InstructorGuid
        {
            get
            {
                return this._InstructorGuid;
            }
            set
            {
                if (this._InstructorGuid != value)
                {
                    this._InstructorGuid = value;
                }
            }
        }

        [Column(Storage="_InstructorName", DbType="NVarChar(50)")]
        public string InstructorName
        {
            get
            {
                return this._InstructorName;
            }
            set
            {
                if (this._InstructorName != value)
                {
                    this._InstructorName = value;
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

        [Column(Storage="_OrderNumber", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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

        [Column(Storage="_ProductGuid", DbType="UniqueIdentifier NOT NULL")]
        public System.Guid ProductGuid
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

        [Column(Storage="_ProductName", DbType="NVarChar(50)")]
        public string ProductName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                if (this._ProductName != value)
                {
                    this._ProductName = value;
                }
            }
        }

        [Column(Storage="_RecordTime", DbType="SmallDateTime")]
        public DateTime? RecordTime
        {
            get
            {
                return this._RecordTime;
            }
            set
            {
                if (this._RecordTime != value)
                {
                    this._RecordTime = value;
                }
            }
        }
    }
}

