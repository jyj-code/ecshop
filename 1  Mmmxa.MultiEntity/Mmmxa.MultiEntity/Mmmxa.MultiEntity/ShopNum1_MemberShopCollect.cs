namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_MemberShopCollect")]
    public class ShopNum1_MemberShopCollect
    {
        private DateTime _CollectTime;
        private System.Guid _Guid;
        private int _IsAttention;
        private string _MemLoginID;
        private string _ShopID;

        [Column(Storage="_CollectTime", DbType="DateTime NOT NULL")]
        public DateTime CollectTime
        {
            get
            {
                return this._CollectTime;
            }
            set
            {
                if (this._CollectTime != value)
                {
                    this._CollectTime = value;
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

        [Column(Storage="_IsAttention", DbType="Int NOT NULL")]
        public int IsAttention
        {
            get
            {
                return this._IsAttention;
            }
            set
            {
                if (this._IsAttention != value)
                {
                    this._IsAttention = value;
                }
            }
        }

        [Column(Storage="_MemLoginID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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

