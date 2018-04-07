namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_ServiceLog")]
    public class ShopNum1_ServiceLog
    {
        private DateTime _BuyTime;
        private string _CreateUser;
        private System.Guid _Guid;
        private string _Remark;
        private string _ServiceName;
        private string _ShopID;

        [Column(Storage="_BuyTime", DbType="DateTime NOT NULL")]
        public DateTime BuyTime
        {
            get
            {
                return this._BuyTime;
            }
            set
            {
                if (this._BuyTime != value)
                {
                    this._BuyTime = value;
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

        [Column(Storage="_Remark", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
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

        [Column(Storage="_ServiceName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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

