namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_SignIn")]
    public class ShopNum1_SignIn
    {
        private DateTime _CreateTime;
        private Guid _guid;
        private string _MemLoginID;

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

        [Column(Storage="_guid", DbType="UniqueIdentifier NOT NULL")]
        public Guid guid
        {
            get
            {
                return this._guid;
            }
            set
            {
                if (this._guid != value)
                {
                    this._guid = value;
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
    }
}

