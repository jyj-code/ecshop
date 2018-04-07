namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_Shop_ProductSpell")]
    public class ShopNum1_Shop_ProductSpell
    {
        private int _BuyCount;
        private DateTime _BuyDate;
        private System.Guid _Guid;
        private string _MemberLoginID;
        private string _ProductGuid;

        [Column(Storage="_BuyCount", DbType="Int NOT NULL")]
        public int BuyCount
        {
            get
            {
                return this._BuyCount;
            }
            set
            {
                if (this._BuyCount != value)
                {
                    this._BuyCount = value;
                }
            }
        }

        [Column(Storage="_BuyDate", DbType="DateTime NOT NULL")]
        public DateTime BuyDate
        {
            get
            {
                return this._BuyDate;
            }
            set
            {
                if (this._BuyDate != value)
                {
                    this._BuyDate = value;
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

        [Column(Storage="_ProductGuid", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ProductGuid
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
    }
}

