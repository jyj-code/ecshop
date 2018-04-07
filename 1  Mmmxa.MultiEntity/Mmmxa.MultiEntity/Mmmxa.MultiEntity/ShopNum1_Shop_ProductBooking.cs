namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_Shop_ProductBooking")]
    public class ShopNum1_Shop_ProductBooking
    {
        private string _Address;
        private string _Email;
        private System.Guid _Guid;
        private int _IsAudit;
        private string _MemLoginID;
        private string _Mobile;
        private string _Name;
        private string _Postalcode;
        private string _ProductGuid;
        private string _ProductName;
        private string _Rank;
        private DateTime _SendDate;
        private string _ShopID;
        private string _Tel;

        [Column(Storage="_Address", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                if (this._Address != value)
                {
                    this._Address = value;
                }
            }
        }

        [Column(Storage="_Email", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                if (this._Email != value)
                {
                    this._Email = value;
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

        [Column(Storage="_IsAudit", DbType="Int NOT NULL")]
        public int IsAudit
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

        [Column(Storage="_Mobile", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
        public string Mobile
        {
            get
            {
                return this._Mobile;
            }
            set
            {
                if (this._Mobile != value)
                {
                    this._Mobile = value;
                }
            }
        }

        [Column(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if (this._Name != value)
                {
                    this._Name = value;
                }
            }
        }

        [Column(Storage="_Postalcode", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
        public string Postalcode
        {
            get
            {
                return this._Postalcode;
            }
            set
            {
                if (this._Postalcode != value)
                {
                    this._Postalcode = value;
                }
            }
        }

        [Column(Storage="_ProductGuid", DbType="NVarChar(50)")]
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

        [Column(Storage="_Rank", DbType="NVarChar(500)")]
        public string Rank
        {
            get
            {
                return this._Rank;
            }
            set
            {
                if (this._Rank != value)
                {
                    this._Rank = value;
                }
            }
        }

        [Column(Storage="_SendDate", DbType="DateTime NOT NULL")]
        public DateTime SendDate
        {
            get
            {
                return this._SendDate;
            }
            set
            {
                if (this._SendDate != value)
                {
                    this._SendDate = value;
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

        [Column(Storage="_Tel", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
        public string Tel
        {
            get
            {
                return this._Tel;
            }
            set
            {
                if (this._Tel != value)
                {
                    this._Tel = value;
                }
            }
        }
    }
}

